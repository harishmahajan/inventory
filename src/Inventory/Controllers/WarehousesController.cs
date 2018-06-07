using System.Linq;
using Microsoft.AspNet.Mvc;
using Inventory.Models;
using System;
using Microsoft.AspNet.Mvc.Rendering;

namespace Inventory.Controllers
{
    public class WarehousesController : Controller
    {
        private ApplicationDbContext _context;
        int TotalRows;

        public WarehousesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Warehouses
        public IActionResult Index(string search )
        {
            TotalRows = _context.Warehouses
                       .Count();

            ViewData["TotalRows"] = TotalRows;

            var warehousesList = _context.Warehouses.ToList();

            if (!String.IsNullOrEmpty(search))
            {
                warehousesList = (warehousesList.Where(
                           s => s.country_name.ToLower().Contains(search.Trim().ToLower())
                           || s.warehouse_id.ToLower().Contains(search.Trim().ToLower())
                           || s.name.ToLower().Contains(search.Trim().ToLower())
                           )).ToList();
            }
            var countryDropdownList = (from m in _context.Warehouses
                                        select new SelectListItem
                                        {
                                            Text = m.country_name,
                                            Value = "./Warehouses?search="+m.country_name,
                                            Selected = search == m.country_name ? true : false
                                        }).Distinct().ToList();

            countryDropdownList.Insert(0, new SelectListItem
            {
                Text = "-- ALL --",
                Value = "./Warehouses?search=",
                Selected = search == "-- ALL --" ? true : false
            });
            ViewData["Search"] = search;
            ViewData["countryDropdownList"] = countryDropdownList;
            return View(warehousesList);
        }

        // GET: Warehouses/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Warehouses warehouses = _context.Warehouses.Single(m => m.id == id);
            if (warehouses == null)
            {
                return HttpNotFound();
            }

            return View(warehouses);
        }
        public IActionResult ProductsAtLocations(string search)
        {
            var warehouseList = (from m in _context.Warehouses
                                 where m.country_name.ToLower() == search.ToLower()
                                 select new Warehouses
                                 {
                                     warehouse_id = m.warehouse_id,
                                     name = m.name

                                 }).ToList();
            return View(warehouseList);
        }
        //// GET: Warehouses/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Warehouses/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Warehouses warehouses)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Warehouses.Add(warehouses);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(warehouses);
        //}

        //// GET: Warehouses/Edit/5
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    Warehouses warehouses = _context.Warehouses.Single(m => m.id == id);
        //    if (warehouses == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(warehouses);
        //}

        //// POST: Warehouses/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Warehouses warehouses)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Update(warehouses);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(warehouses);
        //}

        //// GET: Warehouses/Delete/5
        //[ActionName("Delete")]
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    Warehouses warehouses = _context.Warehouses.Single(m => m.id == id);
        //    if (warehouses == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(warehouses);
        //}

        //// POST: Warehouses/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    Warehouses warehouses = _context.Warehouses.Single(m => m.id == id);
        //    _context.Warehouses.Remove(warehouses);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
