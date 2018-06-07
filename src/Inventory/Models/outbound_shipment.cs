using System;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class outbound_shipment
    {
        public int id { get; set; }

        [Display(Name = "Shipping Status")]
        public int shipping_status { get; set; }

        [Display(Name = "Shipping No.")]
        public int ship_no { get; set; }

        [Display(Name = "From")]
        public string from_warehouse { get; set; }

        [Display(Name = "User ID")]
        public string logged_user { get; set; }

        [Display(Name = "Dispatch Date")]
        [DataType(DataType.Date)]        
        public DateTime dispatch_date { get; set; }

        //[Display(Name = "Dispatch Time")]
        //public decimal dispatch_time { get; set; }

        [Display(Name = "Create Date")]        
        [DataType(DataType.Date)]
        public DateTime cre_date { get; set; }

        [Display(Name = "Vehicle ID")]
        public string vehicle_id { get; set; }

        [Display(Name = "Max. Weight")]
        public decimal max_weight { get; set; }

        [Display(Name = "Accumulated Weight")]
        public decimal accumulated_weight { get; set; }

        [Display(Name = "Calculated Weight")]
        public string calculated_weight { get; set; }

        [Display(Name = "Max. Volume")]
        public decimal max_volume { get; set; }

        [Display(Name = "Maintained By User ID")]
        public string maintained_by_user_id { get; set; }

        [Display(Name = "Loading Zone")]
        public string loading_zone { get; set; }

        [Display(Name = "Loading Location ID")]
        public string loading_location_id { get; set; }

        [Display(Name = "Handler")]
        public string handler { get; set; }

        [Display(Name = "Shipping Agent")]
        public string shipping_agent { get; set; }

        [Display(Name = "Manner Of Transport")]
        public string manner_of_transport { get; set; }

        [Display(Name = "Route ID")]
        public string route_id { get; set; }

        [Display(Name = "Despatch Shipped Date")]
        public decimal despatch_shipped_date { get; set; }

        [Display(Name = "Despatch Shipped Time")]
        public decimal despatch_shipped_time { get; set; }

        [Display(Name = "Manually Created")]
        public string manually_cre { get; set; }

        [Display(Name = "Customer With Placed Orders")]
        public decimal customer_with_placed_orders { get; set; }

        [Display(Name = "Lines With Status LT30")]
        public decimal lines_with_status_lt_30 { get; set; }

        [Display(Name = "Lines With Status EQ30")]
        public decimal lines_with_status_eq_30 { get; set; }

        [Display(Name = "Lines With Status GT30")]
        public decimal lines_with_status_gt_30 { get; set; }

        [Display(Name = "Cut Off Date")]
        public decimal cut_off_date { get; set; }

        [Display(Name = "Order Cut Off Time")]
        public decimal order_cut_off_time { get; set; }

        [Display(Name = "No. Of Containers Simulated")]
        public decimal no_of_containers_simulated { get; set; }

        [Display(Name = "No. Of Containers Assigned Open")]
        public decimal no_of_containers_assigned_open { get; set; }

        [Display(Name = "No. Of Containers Confirmed")]
        public decimal no_of_containers_confirmed { get; set; }

        [Display(Name = "Max. Value")]
        public decimal max_value { get; set; }

        [Display(Name = "Min. Value")]
        public decimal min_value { get; set; }

        [Display(Name = "Accumulated Value")]
        public decimal accumulated_value { get; set; }

        [Display(Name = "Calculated Value")]
        public string calculated_value { get; set; }

        [Display(Name = "Consignee")]
        public string consignee { get; set; }

        [Display(Name = "Notify Party")]
        public string notify_party { get; set; }

        [Display(Name = "Vessel Name")]
        public string vessel_name { get; set; }

        [Display(Name = "Receiving Place")]
        public string receiving_place { get; set; }

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

        [Display(Name = "L C No.")]
        public string l_c_no { get; set; }

        [Display(Name = "L C Date")]
        public decimal l_c_date { get; set; }

        [Display(Name = "Contact No.")]
        public string contact_no { get; set; }

        //[Display(Name = "ETD")]
        //[DataType(DataType.Date)]
        //public DateTime etd { get; set; }

        //[Display(Name = "ETA")]
        //[DataType(DataType.Date)]
        //public DateTime eta { get; set; }

        //[Display(Name = "Act. Ship Date")]
        //[DataType(DataType.Date)]
        //public DateTime act_ship_date { get; set; }

        [Display(Name = "To")]
        public string to_warehouse { get; set; }

        [Display(Name = "Addr. Seq. No.")]
        public decimal addr_seq_no { get; set; }

        [Display(Name = "Order No.")]
        public decimal order_no { get; set; }

        [Display(Name = "Order Line Number")]
        public decimal order_line_number { get; set; }

        [Display(Name = "Product Code")]
        public string product_code { get; set; }

        [Display(Name = "Total Weight")]
        public decimal total_weight { get; set; }

        [Display(Name = "Total Volume")]
        public decimal total_volume { get; set; }

        [Display(Name = "Freight Fee")]
        public decimal freight_fee { get; set; }

        [Display(Name = "Postage Fee")]
        public decimal postage_fee { get; set; }

        [Display(Name = "Insurance Fee")]
        public decimal insurance_fee { get; set; }

        [Display(Name = "Pick List No.")]
        public decimal pick_list_no { get; set; }

        [Display(Name = "Pick List Line No")]
        public decimal pick_list_line_no { get; set; }

        [Display(Name = "Pick Consolidation No.")]
        public decimal pick_consolidation_no { get; set; }

        [Display(Name = "Total Amt. In Sys Currency")]
        public decimal total_amt_in_sys_currency { get; set; }

        [Display(Name = "Remark")]
        public string remark { get; set; }


    }
}
