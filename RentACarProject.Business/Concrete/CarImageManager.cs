using Microsoft.AspNetCore.Http;
using RentACarProject.Business.Abstract;
using RentACarProject.Business.BusinessAspects.Autofac;
using RentACarProject.Business.Constants;
using RentACarProject.Core.Aspects.Autofac.Caching;
using RentACarProject.Core.Utilities.Business;
using RentACarProject.Core.Utilities.FileSystems;
using RentACarProject.Core.Utilities.Results.Abstract;
using RentACarProject.Core.Utilities.Results.Concrete;
using RentACarProject.DataAccess.Abstract;
using RentACarProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [SecuredOperation("carimage.add,admin,moderator")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            var result = BusinessRules.Run(CheckIfCountOfCarImageCorrect(carImage.CarId));
            if (result != null) return result;

            carImage.ImagePath = new FileManagerOnDisk().Add(file, CreateNewPath(file));
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }

        [SecuredOperation("carimage.delete,admin,moderator")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            new FileManagerOnDisk().Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.CarImageDeleted);
        }

        [SecuredOperation("carimage.getall,admin,moderator")]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<CarImage> GetById(int id)
        {
            var result = _carImageDal.Get(x => x.Id == id);

            BusinessRules.Run(IfCarImageNotExsistsAddDefault(ref result));

            return new SuccessDataResult<CarImage>(result);
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carId);

            BusinessRules.Run(IfCarImageNotExsistsAddDefault(ref result));

            return new SuccessDataResult<List<CarImage>>(result);
        }

        [SecuredOperation("carimage.update,admin,moderator")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(CarImage carImage, IFormFile file)
        {
            var carImageToUpdate = _carImageDal.Get(x => x.Id == carImage.Id);

            carImage.CarId = carImageToUpdate.CarId;
            carImage.ImagePath = new FileManagerOnDisk().Update(carImageToUpdate.ImagePath, file, CreateNewPath(file));
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.CarImageUpdated);
        }

        //İlgili araca ait 5'ten fazla foto var mı?, varsa ekleme yapma!
        private IResult CheckIfCountOfCarImageCorrect(int carId)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carId).Count;
            if (result >= 5) return new ErrorResult(Messages.CarImageCountWrong);

            return new SuccessResult();
        }

        //Dosya uzantısı alma ve yeni konum kaydı
        private string CreateNewPath(IFormFile file)
        {
            var fileInfo = new FileInfo(file.FileName);
            var newPath = $@"{Environment.CurrentDirectory}\Public\Images\CarImage\Upload\{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";

            return newPath;
        }

        private IResult IfCarImageNotExsistsAddDefault(ref CarImage result)
        {
            if (result != null) result = CreateDefaultCarImage();

            return new SuccessResult();
        }

        private IResult IfCarImageNotExsistsAddDefault(ref List<CarImage> result)
        {
            if (!result.Any()) result.Add(CreateDefaultCarImage());

            return new SuccessResult();
        }

        //Daha önce resim eklenmemişse, defaultu ekle
        private CarImage CreateDefaultCarImage()
        {
            var defaultCarImage = new CarImage
            {
                ImagePath =
                    $@"{Environment.CurrentDirectory}\Public\Images\CarImage\default-img.png",
                Date = DateTime.Now
            };

            return defaultCarImage;
        }
    }
}
