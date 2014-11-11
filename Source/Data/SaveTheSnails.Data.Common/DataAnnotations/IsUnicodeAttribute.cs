using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheSnails.Data.Common.DataAnnotations
{
    public class IsUnicodeAttribute : Attribute
    {
        private readonly bool isUnicode;

        public IsUnicodeAttribute(bool isUnicode)
        {
            this.isUnicode = isUnicode;
        }

        public bool IsUnicode
        {
            get
            {
                return this.isUnicode;
            }
        }
    }
}
