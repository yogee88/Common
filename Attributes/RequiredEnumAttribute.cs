using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Attributes
{
    public class RequiredEnumAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || (int)value == 0) return false;
            var type = value.GetType();
            return type.IsEnum && Enum.IsDefined(type, value); ;
        }
    }
}
