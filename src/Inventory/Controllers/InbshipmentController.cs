using System.Linq;
using Microsoft.AspNet.Mvc;
using Inventory.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNet.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Controllers
{
    public class InbshipmentController : Controller
    {

        private ApplicationDbContext _context;
        int PageSize = 50, TotalRows, TotalPages;

        public InbshipmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index(string search, int p = 1)
        {
            if (p < 0) p = 0;

            var inbshipment = from m in _context.Inbshipment
                              select m;

            if (!String.IsNullOrEmpty(search))
            {
                inbshipment = inbshipment.Where(
                            s => s.ship_no.ToString().Contains(search) ||
                            s.ship_agent.ToLower().Contains(search.ToLower()) ||
                            s.desc.ToLower().Contains(search.ToLower()) ||
                            s.to_warehouse.ToLower().Contains(search.ToLower()) ||
                            s.from_warehouse.ToLower().Contains(search.ToLower()) ||
                            s.handler.ToLower().Contains(search.ToLower()) ||
                            s.qty.ToString().ToLower().Contains(search.ToLower()) ||
                            s.amt_17_4.ToString().ToLower().Contains(search.ToLower()) ||
                            s.tot_gross_weight.ToString().ToLower().Contains(search.ToLower()) ||
                            s.tot_net_weight.ToString().ToLower().Contains(search.ToLower()) ||
                            s.total_gross_vol.ToString().ToLower().Contains(search.ToLower()) ||
                            s.total_net_vol.ToString().ToLower().Contains(search.ToLower()) ||
                            s.container_no.ToLower().Contains(search.ToLower()) ||
                            s.seal_no.ToLower().Contains(search.ToLower()) ||
                            s.order_no.ToString().ToLower().Contains(search.ToLower()) ||
                            s.product_code.ToLower().Contains(search.ToLower()) ||
                            s.gross_weight.ToString().ToLower().Contains(search.ToLower()) ||
                            s.gross_volume.ToString().ToLower().Contains(search.ToLower()) ||
                            s.net_weight.ToString().ToLower().Contains(search.ToLower()) ||
                            s.net_volume.ToString().ToLower().Contains(search.ToLower())
                            );
            }

            // query the total rows for calculating the total pages
            TotalRows = inbshipment.Count();

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
                    Value = (String.IsNullOrEmpty(search)) ? "./inbshipment?p=" + i.ToString() : "./inbshipment?p=" + i.ToString() + "&search=" + search,
                    Selected = (p == i) ? true : false
                });
            }

            ViewData["PagesList"] = SelectionList;

            // return
            return View(inbshipment.OrderBy(item => item.ship_no).Skip((p - 1) * PageSize).Take(PageSize).ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            inbound_shipment ibshipment = _context.Inbshipment.Single(m => m.id == id);
            if (ibshipment == null)
            {
                return HttpNotFound();
            }

            return View(ibshipment);
        }
    }
}
