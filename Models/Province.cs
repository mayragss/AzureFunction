using System;
using System.Collections.Generic; 

namespace AzureFunction.Models
{
    public class Province
    {
        public Province() { }

        public Province(string name, DateTime creationDate, DateTime updateDate)
        {
            Name = name;
            CreationDate = creationDate;    
            UpdateDate = updateDate;
        }

        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public List<Province> GetProvinces { get => CreateProvinces(); }

        private static List<Province> CreateProvinces()
        {
            DateTime currentDate = new();
            return new List<Province>()
            {
                new Province("Malange", currentDate, currentDate),
                new Province("Benguela", currentDate, currentDate),
                new Province("Lubango", currentDate, currentDate),
                new Province("Moxico", currentDate, currentDate),
                new Province("Huila", currentDate, currentDate),
            };
        }
    }
}
