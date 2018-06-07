using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Suppliers
    {
        public int id { get; set; }

        [Display(Name = "Supplier No.")]
        public string supplier_no { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Alias")]
        public string alias { get; set; }

        [Display(Name = "Address 1")]
        public string addr1 { get; set; }

        [Display(Name = "Address 2")]
        public string addr2 { get; set; }

        [Display(Name = "Address 3")]
        public string addr3 { get; set; }

        [Display(Name = "Address 4")]
        public string addr4 { get; set; }

        [Display(Name = "Postal Code")]
        public string postal_code { get; set; }

        [Display(Name = "Province/State")]
        public string province_state { get; set; }

        [Display(Name = "Country")]
        public string country { get; set; }

        [Display(Name = "Internal Name")]
        public string internal_name { get; set; }

        [Display(Name = "Vat Reg. No.")]
        public string vat_registration_no { get; set; }

        [Display(Name = "Create Date")]
        [DataType(DataType.Date)]
        public DateTime cre_date { get; set; }

        [Display(Name = "Customer Supplier No.")]
        public int customer_supplier_no { get; set; }

        [Display(Name = "AR Main Salesman Handler")]
        public string ar_main_salesman_handler { get; set; }

    }
}
