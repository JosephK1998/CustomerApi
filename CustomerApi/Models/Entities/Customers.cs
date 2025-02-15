using System.ComponentModel.DataAnnotations;
namespace CustomerApi.Models.Entities
{
    public class Customers
    {
        [Key]
        public  int CustomerCode { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string GeoLocation { get; set; }

    }
}
