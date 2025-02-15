namespace CustomerApi.Models
{
    public class AddCustomer
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string GeoLocation { get; set; }
    }
}
