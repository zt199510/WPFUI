using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Test.ValidationRuleS
{
    public class NumberRule : ValidationRule
    {
        public override System.Windows.Controls.ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int i;
            //  int.TryParse(value.ToString(), out i);
            if (!int.TryParse(value.ToString(), out i))
            {
                return new System.Windows.Controls.ValidationResult(false,
                       "字符串格式不对!");
            }
            if (i > 99999999)
            {
                return new System.Windows.Controls.ValidationResult(false,
                        "数值不能大于99999999!");
            }
            else
            {
                return new System.Windows.Controls.ValidationResult(true, null);
            }

        }
    }
}
