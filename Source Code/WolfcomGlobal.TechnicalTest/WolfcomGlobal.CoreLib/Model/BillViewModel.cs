using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfcomGlobal.CoreLib.Helpers;

namespace WolfcomGlobal.CoreLib.Model
{
    public class BillViewModel
    {
        [Required]
        public decimal AmountPerPerson { get; set; }
        [Required]
        public int NumberofCustomers { get; set; }
        public string PromoCode { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
