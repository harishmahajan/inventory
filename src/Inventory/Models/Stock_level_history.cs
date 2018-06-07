using System;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Stock_level_history
    {

        public int id { get; set; }

        [Display(Name = "Product Code")]
        public string product_code { get; set; }

        [Display(Name = "Desc.")]
        public string product_desc { get; set; }

        [Display(Name = "A00_OH")]
        public int a00_ohq { get; set; }

        [Display(Name = "A00_IN")]
        public int a00_inq { get; set; }

        [Display(Name = "A00_OU")]
        public int a00_ouq { get; set; }

        [Display(Name = "A00_OB")]
        public int a00_obqty { get; set; }

        [Display(Name = "A10_OH")]
        public int a10_ohq { get; set; }

        [Display(Name = "A10_IN")]
        public int a10_inq { get; set; }

        [Display(Name = "A10_OU")]
        public int a10_ouq { get; set; }

        [Display(Name = "A10_OB")]
        public int a10_obqty { get; set; }

        [Display(Name = "A11_OH")]
        public int a11_ohq { get; set; }

        [Display(Name = "A11_IN")]
        public int a11_inq { get; set; }

        [Display(Name = "A11_OU")]
        public int a11_ouq { get; set; }

        [Display(Name = "A11_OB")]
        public int a11_obqty { get; set; }

        [Display(Name = "A50_OH")]
        public int a50_ohq { get; set; }

        [Display(Name = "A50_IN")]
        public int a50_inq { get; set; }

        [Display(Name = "A50_OU")]
        public int a50_ouq { get; set; }

        [Display(Name = "A50_OB")]
        public int a50_obqty { get; set; }

        [Display(Name = "A99_OH")]
        public int a99_ohq { get; set; }

        [Display(Name = "A99_IN")]
        public int a99_inq { get; set; }

        [Display(Name = "A99_OU")]
        public int a99_ouq { get; set; }

        [Display(Name = "A99_OB")]
        public int a99_obqty { get; set; }

        [Display(Name = "G10_OH")]
        public int g10_ohq { get; set; }

        [Display(Name = "G10_IN")]
        public int g10_inq { get; set; }

        [Display(Name = "G10_OU")]
        public int g10_ouq { get; set; }

        [Display(Name = "G10_OB")]
        public int g10_obqty { get; set; }

        [Display(Name = "G50_OH")]
        public int g50_ohq { get; set; }

        [Display(Name = "G50_IN")]
        public int g50_inq { get; set; }

        [Display(Name = "G50_OU")]
        public int g50_ouq { get; set; }

        [Display(Name = "G50_OB")]
        public int g50_obqty { get; set; }

        [Display(Name = "G90_OH")]
        public int g90_ohq { get; set; }

        [Display(Name = "G90_IN")]
        public int g90_inq { get; set; }

        [Display(Name = "G90_OU")]
        public int g90_ouq { get; set; }

        [Display(Name = "G90_OB")]
        public int g90_obqty { get; set; }

        [Display(Name = "G99_OH")]
        public int g99_ohq { get; set; }

        [Display(Name = "G99_IN")]
        public int g99_inq { get; set; }

        [Display(Name = "G99_OU")]
        public int g99_ouq { get; set; }

        [Display(Name = "G99_OB")]
        public int g99_obqty { get; set; }

        [Display(Name = "H00_OH")]
        public int h00_ohq { get; set; }

        [Display(Name = "H00_IN")]
        public int h00_inq { get; set; }

        [Display(Name = "H00_OU")]
        public int h00_ouq { get; set; }

        [Display(Name = "H00_OB")]
        public int h00_obqty { get; set; }

        [Display(Name = "H01_OH")]
        public int h01_ohq { get; set; }

        [Display(Name = "H01_IN")]
        public int h01_inq { get; set; }

        [Display(Name = "H01_OU")]
        public int h01_ouq { get; set; }

        [Display(Name = "H01_OB")]
        public int h01_obqty { get; set; }

        [Display(Name = "H10_OH")]
        public int h10_ohq { get; set; }

        [Display(Name = "H10_IN")]
        public int h10_inq { get; set; }

        [Display(Name = "H10_OU")]
        public int h10_ouq { get; set; }

        [Display(Name = "H10_OB")]
        public int h10_obqty { get; set; }

        [Display(Name = "M10_OH")]
        public int m10_ohq { get; set; }

        [Display(Name = "M10_IN")]
        public int m10_inq { get; set; }

        [Display(Name = "M10_OU")]
        public int m10_ouq { get; set; }

        [Display(Name = "M10_OB")]
        public int m10_obqty { get; set; }

        [Display(Name = "T01_OH")]
        public int t01_ohq { get; set; }

        [Display(Name = "T01_IN")]
        public int t01_inq { get; set; }

        [Display(Name = "T01_OU")]
        public int t01_ouq { get; set; }

        [Display(Name = "T01_OB")]
        public int t01_obqty { get; set; }

        [Display(Name = "T02_OH")]
        public int t02_ohq { get; set; }

        [Display(Name = "T02_IN")]
        public int t02_inq { get; set; }

        [Display(Name = "T02_OU")]
        public int t02_ouq { get; set; }

        [Display(Name = "T02_OB")]
        public int t02_obqty { get; set; }

        [Display(Name = "U10_OH")]
        public int u10_ohq { get; set; }

        [Display(Name = "U10_IN")]
        public int u10_inq { get; set; }

        [Display(Name = "U10_OU")]
        public int u10_ouq { get; set; }

        [Display(Name = "U10_OB")]
        public int u10_obqty { get; set; }

        [Display(Name = "U50_OH")]
        public int u50_ohq { get; set; }

        [Display(Name = "U50_IN")]
        public int u50_inq { get; set; }

        [Display(Name = "U50_OU")]
        public int u50_ouq { get; set; }

        [Display(Name = "U50_OB")]
        public int u50_obqty { get; set; }

        [Display(Name = "U99_OH")]
        public int u99_ohq { get; set; }

        [Display(Name = "U99_IN")]
        public int u99_inq { get; set; }

        [Display(Name = "U99_OU")]
        public int u99_ouq { get; set; }

        [Display(Name = "U99_OB")]
        public int u99_obqty { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [Display(Name = "Snapshot Date")]
        [DataType(DataType.Date)]
        public DateTime snapshot_date { get; set; }

        
    }
}
