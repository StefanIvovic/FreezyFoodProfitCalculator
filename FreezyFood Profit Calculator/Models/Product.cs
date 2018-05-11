using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FreezyFood_Profit_Calculator.Models
{
    public class Product
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ime proizvoda je obavezno")]
        [Display(Name = "Naziv proizvoda")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Kupovna cena proizvoda je obavezna")]
        [Display(Name = "Kupovna cena /KG")]
        public decimal PricePerKGBuy { get; set; }

        [Required(ErrorMessage = "Cena proizvoda je obavezna")]
        [Display(Name = "Prodajna cena /KG")]
        public decimal PricePerKGSell { get; set; }

        //currently unused
        [Display(Name = "Procenat profita")]
        public decimal ProfitPercentage { get; set; }

    }
}