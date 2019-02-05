using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfcomGlobal.CoreLib.Model
{
    public class BillResponseModel
    {
        public decimal BilledAmount { get; set; }
        public string BilledDescription { get; set; }

        public BillResponseModel()
        {

        }
        public BillResponseModel(decimal _actualAmount, decimal _promotionAmount=0)
        {
            BilledAmount = _actualAmount- _promotionAmount;
        }
    }


}
