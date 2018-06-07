using Inventory.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Controllers
{
    public class StocklevelController : Controller
    {

        private ApplicationDbContext _context;
        int PageSize = 50, TotalRows, TotalPages;

        public StocklevelController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index(string search, int p = 1)
        {
            
            // Check to see if page is less than 0
            if (p < 0) p = 0;

            var stocklevel = from m in _context.Stocklevel
                             select m;           
            

           
            //// Check to see if Category
            //if (!String.IsNullOrEmpty(Category))
            //{
            //    if(Category == "Others")
            //    {
            //        Category = null;
            //    }
            //    stocklevel =
            //                       from st in _context.Stocklevel
            //                       join pr in _context.Products on st.product_code equals pr.product_code
            //                       where pr.category10_desc == Category
            //                       select st;
            //}

            if (!String.IsNullOrEmpty(search))
            {
                stocklevel = stocklevel.Where(
                           s => s.product_code.Contains(search) ||
                           s.product_desc.Contains(search)
                           );
            }

            // query the total rows for calculating the total pages
            TotalRows = stocklevel.Count();

            TotalPages = (int)Math.Ceiling((Double)(TotalRows / PageSize));

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
                    Value = (String.IsNullOrEmpty(search)) ? "./Stocklevel?p=" + i.ToString() : "./Stocklevel?p=" + i.ToString() + "&search=" + search,
                    Selected = (p == i) ? true : false
                });
            }

            ViewData["PagesList"] = SelectionList;

            // return
            return View(stocklevel.OrderBy(item => item.product_code).Skip((p - 1) * PageSize).Take(PageSize).ToList());
        }

        // GET: Stock Level/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            stock_level stocklevel = _context.Stocklevel.Single(m => m.id == id);
            if (stocklevel == null)
            {
                return HttpNotFound();
            }

            return View(stocklevel);
        }
   
    }
}
