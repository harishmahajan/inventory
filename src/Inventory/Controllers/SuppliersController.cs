using System.Linq;
using Microsoft.AspNet.Mvc;
using Inventory.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNet.Mvc.Rendering;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Controllers
{
    public class SuppliersController : Controller
    {
        private ApplicationDbContext _context;
        int PageSize = 50, TotalRows, TotalPages;

        public SuppliersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index(string search, int p = 1)
        {
            // Check to see if page is less than 0
            if (p < 0) p = 0;

            var suppliers = from m in _context.Suppliers
                            where (!(m.name.ToLower().Contains("test")))
                            select m;

            if (!String.IsNullOrEmpty(search))
            {
                suppliers = suppliers.Where(
                            s => s.supplier_no.ToLower().Contains(search.ToLower()) ||
                            s.name.ToLower().Contains(search.ToLower()) ||
                            s.addr1.ToLower().Contains(search.ToLower()) ||
                            s.addr2.ToLower().Contains(search.ToLower()) ||
                            s.addr3.ToLower().Contains(search.ToLower()) ||
                            s.addr4.ToLower().Contains(search.ToLower()) ||
                            s.postal_code.ToLower().Contains(search.ToLower()) ||
                            s.country.ToLower().Contains(search.ToLower()) ||
                            s.internal_name.ToLower().Contains(search.ToLower()) ||
                            s.customer_supplier_no.ToString().Contains(search.ToLower())
                            );
            }

            // query the total rows for calculating the total pages
            TotalRows = suppliers.Count();

            TotalPages =  (int)Math.Ceiling((Double)(TotalRows / PageSize));

            // carrying parameters back to index page
            ViewData["TotalPages"] = TotalPages + 1;
            ViewData["p"] = p;
            ViewData["PreviousPage"] = (p > 1) ? p - 1 : 1;
            ViewData["NextPage"] = (p < TotalPages) ? p + 1 : TotalPages + 1;
            ViewData["TotalRows"] = TotalRows;
            ViewData["Search"] = search;

            //Generating the Page list selection
            List<SelectListItem> SelectionList = new List<SelectListItem>();

            for (int i = 1; i < TotalPages + 2; i++)
            {
                SelectionList.Add(new SelectListItem
                {
                    Text = i.ToString(),
                    Value = (String.IsNullOrEmpty(search)) ? "./suppliers?p=" + i.ToString() : "./suppliers?p=" + i.ToString() + "&search=" + search,
                    Selected = (p == i) ? true : false
                });
            }

            ViewData["PagesList"] = SelectionList;

            // return
            return View(suppliers.OrderBy(item => item.name).Skip((p - 1) * PageSize).Take(PageSize).ToList());
        }

        // GET: Warehouses/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Suppliers suppliers = _context.Suppliers.Single(m => m.id == id);
            if (suppliers == null)
            {
                return HttpNotFound();
            }

            return View(suppliers);
        }
    }
}