using SaveTheSnails.Data.Common.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheSnails.Data.Common.CodeFirstConventions
{
    public class IsUnicodeAttributeConvention : PrimitivePropertyAttributeConfigurationConvention<IsUnicodeAttribute>
    {
        public override void Apply(ConventionPrimitivePropertyConfiguration configuration, IsUnicodeAttribute attribute)
        {
            configuration.IsUnicode(attribute.IsUnicode);
        }
    }
}
