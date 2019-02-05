using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfcomGlobal.CoreLib.Model;

namespace WolfcomGlobal.CoreLib.Helpers
{
   public class StringReplace
   {
        public static string ReplaceString(string input, BillViewModel model)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (input.Contains(Constants.NumberofCustomers))
                {
                    input = input.Replace(Constants.NumberofCustomers, model.NumberofCustomers.ToString()); ;
                }
                if (input.Contains(Constants.Price))
                {
                    input = input.Replace(Constants.Price, model.TotalPrice.ToString()); ;
                }
                if (input.Contains(Constants.PromocodeValue))
                {
                    input = input.Replace(Constants.PromocodeValue, model.PromoCode.ToString()); ;
                }
            }

            return input;
        }

        public static bool ComputeCondition(string value)
        {
            using (DataTable dt = new DataTable())
            {
                return (bool)(dt.Compute(value, null));
            }
        }
    }
}
