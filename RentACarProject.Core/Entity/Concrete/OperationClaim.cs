using RentACarProject.Core.Entity.Abstract;

namespace RentACarProject.Core.Entity.Concrete
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
