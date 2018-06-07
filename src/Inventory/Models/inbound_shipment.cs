using System;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class inbound_shipment
    {
        public int id { get; set; }

        [Display(Name = "Shipping Status")]
        public int ship_status { get; set; }

        [Display(Name = "Shipping No.")]
        public int ship_no { get; set; }

        [Display(Name = "Shipping Agent")]
        public string ship_agent { get; set; }

        [Display(Name = "Supplier No.")]
        public string supplier_no { get; set; }

        [Display(Name = "Description")]
        public string desc { get; set; }

        [Display(Name = "To")]
        public string to_warehouse { get; set; }

        [Display(Name = "Handler")]
        public string handler { get; set; }

        [Display(Name = "Create Date")]
        [DataType(DataType.Date)]
        public DateTime creation_date { get; set; }

        [Display(Name = "User ID")]
        public string user_id { get; set; }

        [Display(Name = "Pick List No.")]
        public int pick_list_no { get; set; }

        [Display(Name = "Goods Reception Program")]
        public string goods_reception_prog { get; set; }

        [Display(Name = "Allocation Required")]
        public string allocation_required { get; set; }

        [Display(Name = "Pre-receipt Qty Update Required")]
        public string pre_receipt_qty_update_required { get; set; }

        [Display(Name = "Await Cost Check")]
        public string await_cost_check { get; set; }

        [Display(Name = "Reception Processed")]
        public string receception_processed { get; set; }

        [Display(Name = "Total No. of Lines")]
        public int total_no_of_lines { get; set; }

        [Display(Name = "Qty.")]
        public int qty { get; set; }

        [Display(Name = "Amount 17 4")]
        public decimal amt_17_4 { get; set; }

        [Display(Name = "Total Gross Weight")]
        public decimal tot_gross_weight { get; set; }

        [Display(Name = "Total Net Weight")]
        public decimal tot_net_weight { get; set; }

        [Display(Name = "Total Gross Volume")]
        public decimal total_gross_vol { get; set; }

        [Display(Name = "Total Net Volume")]
        public decimal total_net_vol { get; set; }

        [Display(Name = "Landed Costs Required")]
        public string landed_costs_required { get; set; }

        [Display(Name = "Dispatch Date")]
        public decimal dispatch_date { get; set; }

        [Display(Name = "Transport Time")]
        public decimal transport_time { get; set; }

        [Display(Name = "Arrival Date")]
        public decimal arrival_date { get; set; }

        [Display(Name = "Supplier Dispatch ID")]
        public string supplier_dispatch_id { get; set; }

        [Display(Name = "Consolidated To")]
        public decimal consolidated_to { get; set; }

        [Display(Name = "Consignee")]
        public string consignee { get; set; }

        [Display(Name = "Notify Party")]
        public string notify_party { get; set; }

        [Display(Name = "Vessel Name")]
        public string vessel_name { get; set; }

        [Display(Name = "Place of Receive")]
        public string place_of_receive { get; set; }

        [Display(Name = "Loading Port")]
        public string loading_port { get; set; }

        [Display(Name = "Discharge Port")]
        public string discharge_port { get; set; }

        [Display(Name = "Destination Port")]
        public string destination_port { get; set; }

        [Display(Name = "Container No.")]
        public string container_no { get; set; }

        [Display(Name = "Container Size")]
        public string container_size { get; set; }

        [Display(Name = "Seal No.")]
        public string seal_no { get; set; }

        [Display(Name = "LC No.")]
        public string lc_no { get; set; }

        [Display(Name = "LC Date")]
        public decimal lc_date { get; set; }

        [Display(Name = "Contact No.")]
        public string contact_no { get; set; }

        [Display(Name = "ETD")]
        [DataType(DataType.Date)]
        public DateTime etd { get; set; }

        [Display(Name = "ETA")]
        [DataType(DataType.Date)]
        public DateTime eta { get; set; }

        [Display(Name = "Act. Ship Date")]
        public decimal act_ship_date { get; set; }

        [Display(Name = "Order No.")]
        public int order_no { get; set; }

        [Display(Name = "Order Line Number")]
        public decimal order_line_number { get; set; }

        [Display(Name = "From")]
        public string from_warehouse { get; set; }

        [Display(Name = "Ship Line No.")]
        public decimal ship_line_no { get; set; }

        [Display(Name = "Product Code")]
        public string product_code { get; set; }

        [Display(Name = "Quality Stock Unit")]
        public int qty_stock_unit { get; set; }

        [Display(Name = "Discounted Sales Price in System Currency")]
        public decimal disc_sales_price_in_sys_currency { get; set; }

        [Display(Name = "Gross Weight")]
        public decimal gross_weight { get; set; }

        [Display(Name = "Net Weight")]
        public decimal net_weight { get; set; }

        [Display(Name = "Gross Volume")]
        public decimal gross_volume { get; set; }

        [Display(Name = "Net Volume")]
        public decimal net_volume { get; set; }

        [Display(Name = "Qty Purchase Unit")]
        public int qty_purchase_unit { get; set; }

        [Display(Name = "Unit")]
        public string unit { get; set; }

        [Display(Name = "Ship Cost Amount")]
        public decimal ship_cost_amt { get; set; }

        [Display(Name = "Qty Received YTD")]
        public int qty_received_ytd { get; set; }

        [Display(Name = "Transport Note No. from Supplier")]
        public string transport_note_no_from_supplier { get; set; }

        [Display(Name = "Remark")]
        public string remark { get; set; }
    }
}
