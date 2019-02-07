using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WolfcomGlobal.CoreLib.Core.Repositories;
using WolfcomGlobal.CoreLib.Model;

namespace WolfcomGlobal.TechnicalTest.Controllers
{
    public class BillController : Controller
    {

        // GET: Bill
        private readonly IBill _bill;
        public BillController(IBill bill)
        {
            this._bill = bill;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BillCalculation(BillViewModel model)
        {
            BillResponseModel Result = new BillResponseModel();

            if (ModelState.IsValid)
            {
               Result= _bill.FindtheBilledAmount(model);
            }
            return Json(new { Result = Result }, JsonRequestBehavior.AllowGet);

        }
    }
}