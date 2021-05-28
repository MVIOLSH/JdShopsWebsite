using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JdShopsWebsite.Shared
{
    public class AdditionalAddreessesDto
    {
        public int Id { get; set; }
        public float ShopNumber { get; set; }
        public string Description { get; set; }
        public string DeliveryInfo { get; set; }
        public string MapCoordinatesLongitude { get; set; }
        public string MapCoordinatesLatitude { get; set; }
    }
}
