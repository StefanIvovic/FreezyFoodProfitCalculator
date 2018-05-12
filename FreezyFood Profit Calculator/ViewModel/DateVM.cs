using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FreezyFood_Profit_Calculator.ViewModel
{
    public class DateVM
    {
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{MM", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum od")]
        public DateTime DatumOd { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{MM}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum do")]
        public DateTime DatumDo { get; set; }
    }
}