using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FreezyFood_Profit_Calculator.Models
{
    public class Unit
    {
        public Unit()
        {
            var date = DateTime.Now;
            DateOfPurchase = date.Date;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Ime proizvoda")]
        public string ProductName { get; set; }

        [Display(Name = "Prodata gramaza proizvoda")]
        public decimal SaleInGrams { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum prodaje")]
        public DateTime DateOfPurchase { get; set; }

        [Display(Name = "Izracunat profit")]
        public decimal CalculatedProfit { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}