using System.Linq;
using Microsoft.AspNet.Mvc;
using Inventory.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNet.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Controllers
{

    public class OutbshipmentController : Controller
    {
        private ApplicationDbContext _context;
        int PageSize = 50, TotalRows, TotalPages;

        public OutbshipmentController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index(string search, int p = 1)
        {
            if (p < 0) p = 0;

            var outbshipment = from m in _context.Outbshipment
                              select m;

            if (!String.IsNullOrEmpty(search))
            {
                outbshipment = outbshipment.Where(
                            s => s.product_code.ToString().ToLower().Contains(search.ToLower()) ||
                            s.ship_no.ToString().Contains(search) ||
                            s.shipping_status.ToString().ToLower().Contains(search.ToLower()) ||
                            //s.cre_date.ToString().Contains(search.ToLower()) ||
                            s.from_warehouse.ToString().ToLower().Contains(search.ToLower()) ||
                            s.to_warehouse.ToString().ToLower().Contains(search.ToLower()) ||
                            s.container_no.ToString().ToLower().Contains(search.ToLower()) ||
                            s.destination_port.ToString().ToLower().Contains(search.ToLower()) ||
                            //s.etd.ToString().Contains(search.ToLower()) ||
                            //s.eta.ToString().Contains(search.ToLower()) ||
                            s.order_no.ToString().ToLower().Contains(search.ToLower())
                            );
            }

            // query the total rows for calculating the total pages
            TotalRows = outbshipment.Count();

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
                    Value = (String.IsNullOrEmpty(search)) ? "./outbshipment?p=" + i.ToString() : "./outbshipment?p=" + i.ToString() + "&search=" + search,
                    Selected = (p == i) ? true : false
                });
            }

            ViewData["PagesList"] = SelectionList;

            // return
            return View(outbshipment.OrderBy(item => item.ship_no).Skip((p - 1) * PageSize).Take(PageSize).ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            outbound_shipment obshipment = _context.Outbshipment.Single(m => m.id == id);
            if (obshipment == null)
            {
                return HttpNotFound();
            }

            return View(obshipment);
        }
    }
}
