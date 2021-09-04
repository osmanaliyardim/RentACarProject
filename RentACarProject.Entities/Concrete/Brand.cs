using RentACarProject.Core.Entity.Abstract;

namespace RentACarProject.Entity.Concrete
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
