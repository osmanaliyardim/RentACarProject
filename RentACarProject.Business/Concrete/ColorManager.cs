using RentACarProject.Business.Abstract;
using RentACarProject.Core.Utilities.Results.Abstract;
using RentACarProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Business.Concrete
{
    public class ColorManager : IColorService
    {
        public IResult Add(Color color)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Color color)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Color>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Color> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Color color)
        {
            throw new NotImplementedException();
        }
    }
}
