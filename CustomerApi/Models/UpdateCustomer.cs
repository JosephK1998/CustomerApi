namespace CustomerApi.Models
{
    public class UpdateCustomer
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string GeoLocation { get; set; }
    }
}
