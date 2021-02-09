using GenericRepository.Models;

namespace GenericRepository
{
    public class Cars : BaseEntity
    {
        public string Brand { get; set; }
        public string Type { get; set; }
        public int HorsePower { get; set; }
    }
}