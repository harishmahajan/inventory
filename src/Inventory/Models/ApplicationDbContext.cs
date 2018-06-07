using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Inventory.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);           
                

        }
        public DbSet<Warehouses> Warehouses { get; set; }

        public DbSet<Suppliers> Suppliers { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<inbound_shipment> Inbshipment{ get; set; }

        public DbSet<outbound_shipment> Outbshipment { get; set; }

        public DbSet<stock_level> Stocklevel { get; set; }

        public DbSet<stock_level_byCategory> StocklevelbyCategory { get; set; }

        public DbSet<stock_level_byCategory> View_Temp { get; set; }

        public DbSet<stock_level_np> Stocklevelnp { get; set; }

        public DbSet<Stock_level_history> Stocklevelhistory { get; set; }

    }



}
