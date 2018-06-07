using Inventory.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Controllers
{
    public class StocklevelhistoryController : Controller
    {
        private ApplicationDbContext _context;
        int PageSize = 50, TotalRows, TotalPages;

        public StocklevelhistoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index(string search, int p = 1)
        {
            // Check to see if page is less than 0
            if (p < 0) p = 0;

            var stocklevelhistory = from m in _context.Stocklevelhistory
                             select m;

            if (!String.IsNullOrEmpty(search))
            {
                stocklevelhistory = stocklevelhistory.Where(
                           s => s.product_code.Contains(search) ||
                           s.product_desc.Contains(search)

                           );
            }

            // query the total rows for calculating the total pages
            TotalRows = stocklevelhistory.Count();

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
            return View(stocklevelhistory.OrderBy(item => item.product_code).Skip((p - 1) * PageSize).Take(PageSize).ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Stock_level_history stocklevelhistory = _context.Stocklevelhistory.Single(m => m.id == id);
            if (stocklevelhistory == null)
            {
                return HttpNotFound();
            }

            return View(stocklevelhistory);
        }
    }
}
