using RentACarProject.Core.Utilities.Results.Abstract;
using RentACarProject.Entity.Concrete;
using System.Collections.Generic;

namespace RentACarProject.Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int id);
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
    }
}
