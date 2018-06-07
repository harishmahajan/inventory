using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
    public class Products
    {
        public int id { get; set; }

        [Display(Name = "Status")]
        public string status { get; set; }

        [Display(Name = "Handling Status")]
        public string handling_status { get; set; }

        [Display(Name = "Account Group")]
        public string account_group_desc { get; set; }

        [Display(Name = "Item Group")]
        public string item_group_desc { get; set; }

        [Display(Name = "Launch Venue")]
        public string launch_venue { get; set; }

        [Display(Name = "Account Group")]
        public string account_group { get; set; }

        [Display(Name = "Item Group")]
        public string item_group { get; set; }
    
        [Display(Name = "Product Code")]
        public string product_code { get; set; }

        [Display(Name = "Packing Qty")]
        public int packing_qty { get; set; }

        [Display(Name = "Creation Date")]
        [DataType(DataType.Date)]
        public DateTime creation_date { get; set; }

        [Display(Name = "Supplier")]
        public string main_supplier { get; set; }

        [Display(Name = "Old P. Code")]
        public string old_code { get; set; }

        [Display(Name = "Category1")]
        public string Category1 { get; set; }

        [Display(Name = "Category1 Desc")]
        public string category1_desc { get; set; }

        [Display(Name = "Category2")]
        public string category2 { get; set; }

        [Display(Name = "Category2 Desc")]
        public string category2_desc { get; set; }

        [Display(Name = "Category3")]
        public string category3 { get; set; }

        [Display(Name = "Category3 Desc")]
        public string category3_desc { get; set; }

        [Display(Name = "Category4")]
        public string category4 { get; set; }

        [Display(Name = "Category4 Desc")]
        public string category4_desc { get; set; }

        [Display(Name = "Category5")]
        public string category5 { get; set; }

        [Display(Name = "Category5 Desc")]
        public string category5_desc { get; set; }

        [Display(Name = "Category6")]
        public string category6 { get; set; }

        [Display(Name = "Category6 Desc")]
        public string category6_desc { get; set; }

        [Display(Name = "Country Code")]
        public string country_code { get; set; }

        [Display(Name = "Category7")]
        public string category7 { get; set; }

        [Display(Name = "Category7 Desc")]
        public string category7_desc { get; set; }

        [Display(Name = "Category8")]
        public string category8 { get; set; }

        [Display(Name = "Category8 Desc")]
        public string category8_desc { get; set; }

        [Display(Name = "Category9")]
        public string category9 { get; set; }

        [Display(Name = "Category9 Desc")]
        public string category9_desc { get; set; }

        [Display(Name = "Category10")]
        public string category10 { get; set; }

        [Display(Name = "Category10 Desc")]
        public string category10_desc { get; set; }

        [Display(Name = "Category11")]
        public string category11 { get; set; }

        [Display(Name = "Category11 Desc")]
        public string category11_desc { get; set; }

        [Display(Name = "Category12")]
        public string category12 { get; set; }

        [Display(Name = "Category12 Desc")]
        public string category12_desc { get; set; }

        [Display(Name = "Category15")]
        public string category15 { get; set; }

        [Display(Name = "Category15 Desc")]
        public string category15_desc { get; set; }

        [Display(Name = "Category16")]
        public string category16 { get; set; }

        [Display(Name = "Category16 Desc")]
        public string category16_desc { get; set; }

        [Display(Name = "Description30")]
        public string description30 { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Description20")]
        public string description20 { get; set; }

        [Display(Name = "Description40")]
        public string description40 { get; set; }

        [Display(Name = "Image")]
        public string image { get; set; }

        [Display(Name = "Item Family")]
        public string item_family { get; set; }

        [Display(Name = "Item Family Desc")]
        public string item_family_desc { get; set; }

        [Display(Name = "Item Sector")]
        public string item_sector { get; set; }

        [Display(Name = "Item Sector Desc")]
        public string item_sector_desc { get; set; }

        [Display(Name = "Commodity Code")]
        public string commodity_code { get; set; }

        [Display(Name = "Leather Usage")]
        public int leather_usage { get; set; }

        [Display(Name = "Other Material Usage")]
        public int other_material_usage { get; set; }

        [Display(Name = "Plastic Waste")]
        public int plastic_waste { get; set; }

        [Display(Name = "Metal Waste")]
        public int metal_waste { get; set; }

        [Display(Name = "Carboard Waste")]
        public int carboard_waste { get; set; }

        [Display(Name = "Net Weight")]
        public int net_weight { get; set; }

        [Display(Name = "Gross Weight")]
        public int gross_weight { get; set; }

        [Display(Name = "Lengh")]
        public int lengh { get; set; }

        [Display(Name = "Width")]
        public int width { get; set; }

        [Display(Name = "Height")]
        public int height { get; set; }

        [Display(Name = "CBM")]
        public int cbm { get; set; }

        [Display(Name = "Manufacturer")]
        public string manufacturer { get; set; }

        [Display(Name = "Cartons")]
        public int cartons { get; set; }

        [Display(Name = "UK CAT1")]
        public string uk_cat1 { get; set; }

        [Display(Name = "UK CAT2")]
        public string uk_cat2 { get; set; }

        [Display(Name = "UK CAT3")]
        public string uk_cat3 { get; set; }

        [Display(Name = "UK CAT4")]
        public string uk_cat4 { get; set; }

        [Display(Name = "InfoStatus")]
        public string infostatus { get; set; }

        [Display(Name = "CostStatus")]
        public string coststatus { get; set; }

        [Display(Name = "EANCODE")]
        public string eancode { get; set; }

        [Display(Name = "FOB")]
        public decimal fob { get; set; }


    }
}
