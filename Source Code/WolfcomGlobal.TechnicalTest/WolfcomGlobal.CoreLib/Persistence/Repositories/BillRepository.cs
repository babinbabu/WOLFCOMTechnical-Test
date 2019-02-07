using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfcomGlobal.CoreLib.Core.Repositories;
using WolfcomGlobal.CoreLib.Entity;
using WolfcomGlobal.CoreLib.Helpers;
using WolfcomGlobal.CoreLib.Model;

namespace WolfcomGlobal.CoreLib.Persistence.Repositories
{
    public class BillRepository : IBill
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #region BillingRepositorie
        public BillResponseModel FindtheBilledAmount(BillViewModel Model)
        {

            BillResponseModel Result = new BillResponseModel();
            Model.TotalPrice = Model.AmountPerPerson * Model.NumberofCustomers;
            try
            {
                if (Model.PromoCode == Constants.NonePromoCode || string.IsNullOrEmpty(Model.PromoCode))
                {
                    using (WOLFCOMTechnicalTestEntities db = new WOLFCOMTechnicalTestEntities())
                    {
                        var WithoutPromoCodeList = db.PromoCodeDetails.Where(x => (x.CanAvailWithoutPromoCode == true) && (x.Status == true)).ToList();

                        if (WithoutPromoCodeList.Count() == 0)
                            return new BillResponseModel(Model.TotalPrice);

                        Result = BillCalculation.ExecuteBillCalculation(WithoutPromoCodeList, Model);

                    }
                }
                else
                {
                    using (WOLFCOMTechnicalTestEntities db = new WOLFCOMTechnicalTestEntities())
                    {

                        var WithPromoCodeList = db.PromoCodeDetails.Where(x => (x.CanAvailWithoutPromoCode == true || x.PromoCode == Model.PromoCode) && (x.Status == true)).ToList();
                        if (WithPromoCodeList.Count() == 0)
                            return new BillResponseModel(Model.TotalPrice);

                        Result = BillCalculation.ExecuteBillCalculation(WithPromoCodeList, Model);

                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("This is an error message" + ex);
                return null;
            }
            return Result;
        }
        #endregion
    }
}
