using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfcomGlobal.CoreLib.Model;

namespace WolfcomGlobal.CoreLib.Core.Repositories
{
    public interface IBill
    {
        #region Billing
        BillResponseModel FindtheBilledAmount(BillViewModel Model);
        #endregion
    }
}
