using RentACarProject.Core.Entity.Abstract;

namespace RentACarProject.Entity.Concrete
{
    public class Color : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
