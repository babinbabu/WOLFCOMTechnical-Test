using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfcomGlobal.CoreLib.Model;

namespace WolfcomGlobal.CoreLib.Helpers
{
    public class BillCalculation
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PromotionList"></param>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static BillResponseModel ExecuteBillCalculation(List<Entity.PromoCodeDetail> PromotionList, BillViewModel Model)
        {
            BillResponseModel ResponseResult = new BillResponseModel();
            List<decimal> PromtionList = new List<decimal>();
            decimal DiscountedAmount = 0;
            try
            {
                foreach (var Promotion in PromotionList)
                {

                    string value = StringReplace.ReplaceString(Promotion.PromoCodeRule, Model);
                    if (string.IsNullOrEmpty(value) || StringReplace.ComputeCondition(value))
                    {
                        string discount = StringReplace.ReplaceString(Promotion.PromoCodeDiscount, Model);
                        string DiscountAmount = new DataTable().Compute(discount, null).ToString();
                        PromtionList.Add(Convert.ToDecimal(DiscountAmount));

                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("This is an error message" + ex);
                return null;
            }
            DiscountedAmount = PromtionList.Count() == 0 ? 0 : PromtionList.Max();
            return new BillResponseModel(Model.TotalPrice, DiscountedAmount);
        }
    }
}
