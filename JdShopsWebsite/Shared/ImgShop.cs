using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JdShopsWebsite.Shared
{
    public class ImgShop
    {
        public int Id { get; set; }
        public string ShopNumber { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public int AddAddressId { get; set; }
    }
}
