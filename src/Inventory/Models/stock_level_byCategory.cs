using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
    public class TreeChartTooltipData
    {
        public string category10_desc { get; set; }
        public string continentName { get; set; }
        public decimal value { get; set; }
        public string countryName { get; set; }
    }
    public class TreeChartData
    {
        public string continentName { get; set; }
        public decimal value { get; set; }
        public string color { get; set; }
    }
    public class stock_level_byCategory
    {
        public int id { get; set; }

        [Display(Name = "Category desc.")]
        public string Category_Name { get; set; }

        [Display(Name = "Stock count.")]
        public int Stock_Count { get; set; }

        [Display(Name = "FOB")]
        public decimal fob { get; set; }
    }

    public class stock_level_np
    {
        public int id { get; set; }

        [Display(Name = "Product Code")]
        public string product_code { get; set; }

        [Display(Name = "Product Desc.")]
        public string product_desc { get; set; }
        
        [Display(Name = "Status")]
        public string status { get; set; }

        [Display(Name = "WarehouseID")]
        public string warehouseID { get; set; }

        [Display(Name = "Warehouse")]
        public string warehouse { get; set; }

        [Display(Name = "Qty on hand")]
        public int on_hand_qty { get; set; }

        [Display(Name = "Qty incoming")]
        public int incoming_qty { get; set; }

        [Display(Name = "Qty outgoing")]
        public int outgoing_qty { get; set; }

        [Display(Name = "Qty OB")]
        public int ob_outgoing_qty { get; set; }

        [Display(Name = "Qty na")]
        public int na_qty { get; set; }

        [Display(Name = "Stock Count")]
        public int stock_count { get; set; }

        [Display(Name = "Remarks")]
        public string remark { get; set; }

        //new property added by harish
        [Display(Name = "FOB")]
        public decimal fob { get; set; }

        [Display(Name = "CBM")]
        public decimal cbm { get; set; }

    }
}
