using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SaveTheSnails.Web.Infrastructure.Populators
{
    public interface IDropDownListPopulator
    {
        IEnumerable<SelectListItem> GetCategories();
    }
}
