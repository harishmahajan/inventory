using System;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class stock_level
    {
        public int id { get; set; }

        [Display(Name = "Product Code")]
        public string product_code { get; set; }

        [Display(Name = "Desc.")]
        public string product_desc { get; set; }

        [Display(Name = "A00OH")]
        public int a00_ohq { get; set; }

        [Display(Name = "A00IN")]
        public int a00_inq { get; set; }

        [Display(Name = "A00OU")]
        public int a00_ouq { get; set; }

        [Display(Name = "A00OB")]
        public int a00_obqty { get; set; }

        [Display(Name = "A10OH")]
        public int a10_ohq { get; set; }

        [Display(Name = "A10IN")]
        public int a10_inq { get; set; }

        [Display(Name = "A10OU")]
        public int a10_ouq { get; set; }

        [Display(Name = "A10OB")]
        public int a10_obqty { get; set; }

        [Display(Name = "A11OH")]
        public int a11_ohq { get; set; }

        [Display(Name = "A11IN")]
        public int a11_inq { get; set; }

        [Display(Name = "A11OU")]
        public int a11_ouq { get; set; }

        [Display(Name = "A11OB")]
        public int a11_obqty { get; set; }

        [Display(Name = "A50OH")]
        public int a50_ohq { get; set; }

        [Display(Name = "A50IN")]
        public int a50_inq { get; set; }

        [Display(Name = "A50OU")]
        public int a50_ouq { get; set; }

        [Display(Name = "A50OB")]
        public int a50_obqty { get; set; }

        [Display(Name = "A99OH")]
        public int a99_ohq { get; set; }

        [Display(Name = "A99IN")]
        public int a99_inq { get; set; }

        [Display(Name = "A99OU")]
        public int a99_ouq { get; set; }

        [Display(Name = "A99OB")]
        public int a99_obqty { get; set; }

        [Display(Name = "G10OH")]
        public int g10_ohq { get; set; }

        [Display(Name = "G10IN")]
        public int g10_inq { get; set; }

        [Display(Name = "G10OU")]
        public int g10_ouq { get; set; }

        [Display(Name = "G10_OB")]
        public int g10_obqty { get; set; }

        [Display(Name = "G50OH")]
        public int g50_ohq { get; set; }

        [Display(Name = "G50IN")]
        public int g50_inq { get; set; }

        [Display(Name = "G50OU")]
        public int g50_ouq { get; set; }

        [Display(Name = "G50OB")]
        public int g50_obqty { get; set; }

        [Display(Name = "G90OH")]
        public int g90_ohq { get; set; }

        [Display(Name = "G90IN")]
        public int g90_inq { get; set; }

        [Display(Name = "G90OU")]
        public int g90_ouq { get; set; }

        [Display(Name = "G90OB")]
        public int g90_obqty { get; set; }

        [Display(Name = "G99OH")]
        public int g99_ohq { get; set; }

        [Display(Name = "G99IN")]
        public int g99_inq { get; set; }

        [Display(Name = "G99OU")]
        public int g99_ouq { get; set; }

        [Display(Name = "G99OB")]
        public int g99_obqty { get; set; }

        [Display(Name = "H00OH")]
        public int h00_ohq { get; set; }

        [Display(Name = "H00IN")]
        public int h00_inq { get; set; }

        [Display(Name = "H00OU")]
        public int h00_ouq { get; set; }

        [Display(Name = "H00OB")]
        public int h00_obqty { get; set; }

        [Display(Name = "H01OH")]
        public int h01_ohq { get; set; }

        [Display(Name = "H01IN")]
        public int h01_inq { get; set; }

        [Display(Name = "H01OU")]
        public int h01_ouq { get; set; }

        [Display(Name = "H01OB")]
        public int h01_obqty { get; set; }

        [Display(Name = "H10OH")]
        public int h10_ohq { get; set; }

        [Display(Name = "H10IN")]
        public int h10_inq { get; set; }

        [Display(Name = "H10OU")]
        public int h10_ouq { get; set; }

        [Display(Name = "H10OB")]
        public int h10_obqty { get; set; }

        [Display(Name = "M10OH")]
        public int m10_ohq { get; set; }

        [Display(Name = "M10IN")]
        public int m10_inq { get; set; }

        [Display(Name = "M10OU")]
        public int m10_ouq { get; set; }

        [Display(Name = "M10OB")]
        public int m10_obqty { get; set; }

        [Display(Name = "T01OH")]
        public int t01_ohq { get; set; }

        [Display(Name = "T01IN")]
        public int t01_inq { get; set; }

        [Display(Name = "T01OU")]
        public int t01_ouq { get; set; }

        [Display(Name = "T01OB")]
        public int t01_obqty { get; set; }

        [Display(Name = "T02OH")]
        public int t02_ohq { get; set; }

        [Display(Name = "T02IN")]
        public int t02_inq { get; set; }

        [Display(Name = "T02OU")]
        public int t02_ouq { get; set; }

        [Display(Name = "T02OB")]
        public int t02_obqty { get; set; }

        [Display(Name = "U10OH")]
        public int u10_ohq { get; set; }

        [Display(Name = "U10IN")]
        public int u10_inq { get; set; }

        [Display(Name = "U10OU")]
        public int u10_ouq { get; set; }

        [Display(Name = "U10OB")]
        public int u10_obqty { get; set; }

        [Display(Name = "U50OH")]
        public int u50_ohq { get; set; }

        [Display(Name = "U50IN")]
        public int u50_inq { get; set; }

        [Display(Name = "U50OU")]
        public int u50_ouq { get; set; }

        [Display(Name = "U50OB")]
        public int u50_obqty { get; set; }

        [Display(Name = "U99OH")]
        public int u99_ohq { get; set; }

        [Display(Name = "U99IN")]
        public int u99_inq { get; set; }

        [Display(Name = "U99OU")]
        public int u99_ouq { get; set; }

        [Display(Name = "U99OB")]
        public int u99_obqty { get; set; }
    }
}