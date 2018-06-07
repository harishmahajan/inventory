using Inventory.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;
        int PageSize = 50, TotalRows, TotalPages;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index(string search, int p = 1)
        {
            // Check to see if page is less than 0
            if (p < 0) p = 0;

            var products = from m in _context.Products
                           where (!(m.status.Contains("D")))                           
                           select m;

            if (!String.IsNullOrEmpty(search))
            {
                products = products.Where(
                           s => s.product_code.Contains(search) ||
                           s.description.Contains(search) ||
                           s.old_code.Contains(search)
                           );
            }

            // query the total rows for calculating the total pages
            TotalRows = products.Count();

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
                    Value = (String.IsNullOrEmpty(search)) ? "./products?p=" + i.ToString() : "./products?p=" + i.ToString() + "&search=" + search,
                    Selected = (p == i) ? true : false
                });
            }

            ViewData["PagesList"] = SelectionList;

            // return
            return View(products.OrderBy(item => item.product_code).Skip((p - 1) * PageSize).Take(PageSize).ToList());
        }

        // GET: Warehouses/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Products product = _context.Products.Single(m => m.id == id);

            if (product == null)
            {
                return HttpNotFound();
            }

            //var @PicPath = "http://10.123.99.4:8081/items/" + product.product_code + ".bmp";
            //bool exists;

            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(PicPath);
            //request.Method = "HEAD";

            //try
            //{
            //    request.GetResponse();
            //    exists = true;
            //}
            //catch
            //{
            //    exists = false;
            //}

            //if (exists)
            //{
            //    ViewData["PicPath"] = "<img src = " + @PicPath + "/>";
            //}

            return View(product);
        }
    }
}
