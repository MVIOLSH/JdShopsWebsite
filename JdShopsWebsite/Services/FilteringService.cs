using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bunit.Extensions;
using JdShopsWebsite.Shared;

namespace JdShopsWebsite.Services
{
    public interface IFilteringService
    {
        bool IsVisible(ShopDto shopVis, string phrase);
    }

    public class FilteringService : IFilteringService
    {
        public bool IsVisible(ShopDto shopVis, string phrase)
        {
            if (phrase.IsNullOrEmpty())
            {
                return true;
            }

            if (shopVis.ShopNumber.ToString().Contains(phrase))
            {
                return true;

            }

            if (shopVis.Facia.Contains(phrase))
                return true;
            if (shopVis.Town.Contains(phrase))
                return true;

            return false;
        }
        
    }
}
