using RentACarProject.Core.Entity.Abstract;

namespace RentACarProject.Entity.Concrete
{
    public class Findeks : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string NatinonalIdentity { get; set; }
        public short Score { get; set; }
    }
}
