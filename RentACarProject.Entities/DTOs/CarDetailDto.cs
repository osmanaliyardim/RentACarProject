using RentACarProject.Core.Entity.Abstract;

namespace RentACarProject.Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public short ModelYear { get; set; }
    }
}
