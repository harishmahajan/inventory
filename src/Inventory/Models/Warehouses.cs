using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Warehouses
    {
        public int id { get; set; }

        [Display(Name = "Warehouse")]
        public string warehouse_id { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Description")]
        public string desc { get; set; }

        [Display(Name = "Transport Type")]
        public string type_of_transport { get; set; }

        [Display(Name = "Addr1")]
        public string addr1 { get; set; }

        [Display(Name = "Addr2")]
        public string addr2 { get; set; }

        [Display(Name = "Addr3")]
        public string addr3 { get; set; }

        [Display(Name = "Addr4")]
        public string addr4 { get; set; }

        [Display(Name = "Postal Code")]
        public string post_code { get; set; }

        [Display(Name = "Country")]
        public string country { get; set; }

        [Display(Name = "Country Name")]
        public string country_name { get; set; }
    }
}
