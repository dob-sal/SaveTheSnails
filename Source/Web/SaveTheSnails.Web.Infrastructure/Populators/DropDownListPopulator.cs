using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using SaveTheSnails.Data;
using SaveTheSnails.Web.Infrastructure.Caching;

namespace SaveTheSnails.Web.Infrastructure.Populators
{
    public class DropDownListPopulator : IDropDownListPopulator
    {
        private IAppData data;
        private ICacheService cache;

        public DropDownListPopulator(IAppData data, ICacheService cache)
        {
            this.data = data;
            this.cache = cache;
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            var categories = this.cache.Get<IEnumerable<SelectListItem>>("categories",
                () =>
                {
                    return this.data.Categories
                       .All()
                       .Select(c => new SelectListItem
                       {
                           Value = c.Id.ToString(),
                           Text = c.Name
                       })
                       .ToList();
                });

            return categories;
        }
    }
}
