
namespace AzureFunction.Models
{
    public class TownShip
    {
        public TownShip(string name, string latitude, string longitude, int provinceId)
        {
            Name = name;
            Latitude = latitude;    
            Longitude = longitude;
            ProvinceId = provinceId;
        }
        public int TownshipId { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int ProvinceId { get; set; }
    }
}
