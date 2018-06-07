using Inventory.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Services;
using Newtonsoft.Json;
using Microsoft.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;





// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Controllers
{
    public class StocklevelbyCategoryController : Controller
    {
        private ApplicationDbContext _context;
        int PageSize = 50, TotalRows, TotalPages;
        public string json = "";

        public StocklevelbyCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/

        public IActionResult Index(string search, string sortBy, string sortOrder, int p = 1)
        {
            // Check to see if page is less than 0
            if (p < 0) p = 0;
            PageSize = 20;
            //_context.Database.ExecuteSqlCommand("proc_load_stock_level_byCategory_job");

            //var stocklevelbycategory1 = (from m in _context.View_Temp select new stock_level_np
            //{
            //    id=m.id,
            //    product_desc=m.Category_Name,
            //    stock_count=m.Stock_Count
            //}).ToList();


            int srno = 0;
            //var result = (from pr in _context.Products
            //              join sl in _context.Stocklevel on pr.product_code equals sl.product_code
            //              join sln in _context.Stocklevelnp on pr.product_code equals sln.product_code
            //              select new
            //              {
            //                  sl.product_code,
            //                  category10_desc=pr.category10_desc==null?"Others": pr.category10_desc,
            //                  sl.a00_ohq,
            //                  sl.a10_ohq,
            //                  sl.a11_ohq,
            //                  sl.a50_ohq,
            //                  sl.a99_ohq,
            //                  sl.g10_ohq,
            //                  sl.g50_ohq,
            //                  sl.g90_ohq,
            //                  sl.g99_ohq,
            //                  sl.h00_ohq,
            //                  sl.h01_ohq,
            //                  sl.h10_ohq,
            //                  sl.m10_ohq,
            //                  sl.t01_ohq,
            //                  sl.t02_ohq,
            //                  sl.u10_ohq,
            //                  sl.u50_ohq,
            //                  sl.u99_ohq,
            //                  fob = pr.fob == null ? 0 : pr.fob * sln.on_hand_qty
            //              }).ToList();
            var result = (from sl in _context.Stocklevelnp
                          join pr in _context.Products on sl.product_code equals pr.product_code
                          where sl.on_hand_qty > 0
                          select new
                          {
                              sl.product_code,
                              category10_desc = pr.category10_desc == null ? "Others" : pr.category10_desc,
                              sl.on_hand_qty,
                              fob = pr.fob == null ? 0 : pr.fob * sl.on_hand_qty

                          }).ToList();
            var stocklevelbycategory = (from m in result
                                        where m.on_hand_qty > 0
                                        orderby m.category10_desc
                                        group m by m.category10_desc into g
                                        select new stock_level_byCategory
                                        {
                                            id = HelperService.IncrementX(ref srno, 1),
                                            Category_Name = g.Key,
                                            Stock_Count = g.Sum(sln => sln.on_hand_qty),
                                            fob = g.Sum(pr => pr.fob)
                                        }).ToList();

            //var stocklevelbycategory = (from m in result
            //                            group m by m.category10_desc into g
            //                            select new stock_level_byCategory
            //                            {
            //                                id = HelperService.IncrementX(ref srno, 1),
            //                                Category_Name = g.Key,
            //                                Stock_Count =
            //                                g.Sum(sl => sl.a00_ohq) +
            //                                g.Sum(sl => sl.a10_ohq) +
            //                                g.Sum(sl => sl.a11_ohq) +
            //                                g.Sum(sl => sl.a50_ohq) +
            //                                g.Sum(sl => sl.a99_ohq) +
            //                                g.Sum(sl => sl.g10_ohq) +
            //                                g.Sum(sl => sl.g50_ohq) +
            //                                g.Sum(sl => sl.g90_ohq) +
            //                                g.Sum(sl => sl.g99_ohq) +
            //                                g.Sum(sl => sl.h00_ohq) +
            //                                g.Sum(sl => sl.h01_ohq) +
            //                                g.Sum(sl => sl.h10_ohq) +
            //                                g.Sum(sl => sl.m10_ohq) +
            //                                g.Sum(sl => sl.t01_ohq) +
            //                                g.Sum(sl => sl.t02_ohq) +
            //                                g.Sum(sl => sl.u10_ohq) +
            //                                g.Sum(sl => sl.u50_ohq) +
            //                                g.Sum(sl => sl.u99_ohq),
            //                                fob = g.Sum(pr => pr.fob)
            //                            }).OrderBy(o => o.Category_Name).ToList();

            if (!String.IsNullOrEmpty(search))
            {
                stocklevelbycategory = stocklevelbycategory.Where(
                           s => s.Category_Name.ToLower().Contains(search.ToLower())
                           ).ToList();
            }


            // query the total rows for calculating the total pages
            TotalRows = stocklevelbycategory.Count();

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
                    Value = (String.IsNullOrEmpty(search)) ? "/StocklevelbyCategory?p=" + i.ToString() : "/StocklevelbyCategory?p=" + i.ToString() + "&search=" + search,
                    Selected = (p == i) ? true : false
                });
            }

            ViewData["PagesList"] = SelectionList;

            List<SelectListItem> lstSortBy = new List<SelectListItem>();
            lstSortBy.Add(new SelectListItem
                {
                Text= "Category",
                Value= "Category"
            });
            lstSortBy.Add(new SelectListItem
            {
                Text = "Qty",
                Value = "Qty"
            });
            lstSortBy.Add(new SelectListItem
            {
                Text = "FOB",
                Value = "FOB"
            });

            List<SelectListItem> lstSortOrder = new List<SelectListItem>();
            lstSortOrder.Add(new SelectListItem
            {
                Text = "Ascending",
                Value = "Ascending"
            });
            lstSortOrder.Add(new SelectListItem
            {
                Text = "Descending",
                Value = "Descending"
            });

            
            if(string.IsNullOrEmpty(sortBy))
                sortBy = "Category";
            if (string.IsNullOrEmpty(sortOrder))
                sortOrder = "Ascending";
            string sortyByOrder = sortBy + "_" + sortOrder;
            switch (sortyByOrder)
            {
                case "Qty_Descending":
                stocklevelbycategory = stocklevelbycategory.OrderByDescending(item => item.Stock_Count).Skip((p - 1) * PageSize).Take(PageSize).ToList();
                    
                    break;
                case "Qty_Ascending":
                stocklevelbycategory = stocklevelbycategory.OrderBy(item => item.Stock_Count).Skip((p - 1) * PageSize).Take(PageSize).ToList();
                    
                    break;
                case "FOB_Descending":
                    stocklevelbycategory = stocklevelbycategory.OrderByDescending(item => item.fob).Skip((p - 1) * PageSize).Take(PageSize).ToList();
                    
                    break;
                case "FOB_Ascending":
                    stocklevelbycategory = stocklevelbycategory.OrderBy(item => item.fob).Skip((p - 1) * PageSize).Take(PageSize).ToList();
                    
                    break;
                case "Category_Descending":
                    stocklevelbycategory = stocklevelbycategory.OrderByDescending(item => item.Category_Name).Skip((p - 1) * PageSize).Take(PageSize).ToList();
                    break;
                default:
                    stocklevelbycategory = stocklevelbycategory.OrderBy(item => item.Category_Name).Skip((p - 1) * PageSize).Take(PageSize).ToList();
                    break;

            }

            var SortBySelected = lstSortBy.Where(x => x.Value == sortBy).First();
            SortBySelected.Selected = true;
            var OrderBySelected = lstSortOrder.Where(x => x.Value == sortOrder).First();
            OrderBySelected.Selected = true;

            ViewData["lstSortBy"] = lstSortBy;
            ViewData["lstSortOrder"] = lstSortOrder;

            ViewData["chartJson"] = JsonConvert.SerializeObject(stocklevelbycategory, Formatting.None);
            ViewData["ChartTooltipJson"]= JsonConvert.SerializeObject(getChartTooltipData(), Formatting.None);
            // return
            return View(stocklevelbycategory);
        }
        
        public List<TreeChartTooltipData> getChartTooltipData()
        {
            var result = (from m in _context.Stocklevelnp
                          join pr in _context.Products on m.product_code equals pr.product_code
                          join w in _context.Warehouses on m.warehouse equals w.warehouse_id
                          where m.on_hand_qty > 0
                          select new TreeChartTooltipData
                          {
                              category10_desc=string.IsNullOrEmpty(pr.category10_desc)? "Others" : pr.category10_desc,
                              continentName = HelperService.getContinentFromCountry(w.country),
                              value = m.on_hand_qty < 0 ? 0 : Convert.ToDecimal(m.on_hand_qty),                              
                              countryName = w.country_name
                          }).ToList();
            var stocklevelbynp = (from m in result
                                  group m by new {m.category10_desc, m.continentName, m.countryName } into g
                                  select new TreeChartTooltipData
                                  {
                                      category10_desc=g.Key.category10_desc,
                                      continentName = g.Key.continentName,
                                      countryName=g.Key.countryName,
                                      value = g.Sum(sl => sl.value),
                                  }).ToList();
            stocklevelbynp.RemoveAll(x => x.value == 0);
            stocklevelbynp = stocklevelbynp.OrderBy(x => x.category10_desc).ToList();
            return stocklevelbynp;
        }
        [HttpGet]
        public JsonResult getProducsStocklevelnptByCategory(string Category)
        {
            int srno = 0;
            if (Category == "Others")
            {
                Category = null;
            }
            var result = (from m in _context.Stocklevelnp
                          join pr in _context.Products on m.product_code equals pr.product_code
                          join w in _context.Warehouses on m.warehouse equals w.warehouse_id
                          where pr.category10_desc == Category && m.on_hand_qty>0
                          select new TreeChartData
                          {
                              
                              continentName = HelperService.getContinentFromCountry(w.country),
                              value = m.on_hand_qty<0?0:Convert.ToDecimal(m.on_hand_qty),
                              color = HelperService.IncrementX(ref srno, 1).ToString()
                              
                          }).ToList();

            var stocklevelbynp = (from m in result
                                  group m by m.continentName into g
                                  select new TreeChartData
                                  {
                                      continentName = g.Key,
                                      value = g.Sum(sl => sl.value),
                                      color = ""
                                  }).ToList();
            stocklevelbynp.RemoveAll(x=>x.value==0);
            int i = 1;
            stocklevelbynp = stocklevelbynp.OrderByDescending(x => x.value).ToList();
            foreach (TreeChartData item in stocklevelbynp)
            {
                item.color = HelperService.getContinentColor(i);
                i++;
            }
            return (Json(stocklevelbynp));
        }

        
        public IActionResult Stock_level_np(string search, string Category, int p = 1)
        {
            // Check to see if page is less than 0
            if (p < 0) p = 0;


            if (Category == "Others")
            {
                Category = "";
            }
           

            List< stock_level_np> result = (from m in _context.Stocklevelnp
                                 join pr in _context.Products on m.product_code equals pr.product_code
                                 join w in _context.Warehouses on m.warehouse equals w.warehouse_id
                                 where pr.category10_desc == Category && m.on_hand_qty>0 
                                 select new stock_level_np
                                 {
                                     id = m.id,
                                     product_code = m.product_code,
                                     product_desc = m.product_desc,
                                     status = m.status,
                                     warehouseID=w.warehouse_id.ToString(),
                                     warehouse = w.name,
                                     on_hand_qty = m.on_hand_qty,
                                     incoming_qty = m.incoming_qty,
                                     outgoing_qty = m.outgoing_qty,
                                     ob_outgoing_qty = m.ob_outgoing_qty,
                                     na_qty = m.na_qty,
                                     stock_count = m.stock_count,
                                     remark = m.remark,
                                     fob = pr.fob==null?0:pr.fob,
                                     cbm=pr.cbm
                                    
                                 }).ToList();
            List<stock_level_np> stocklevelbynp = result.GroupBy(g => new {
                g.warehouseID 
                ,g.product_code
                ,g.product_desc
                ,g.id
                ,g.status
                ,g.warehouse
                ,g.on_hand_qty
                ,g.incoming_qty
                ,g.outgoing_qty
                ,g.ob_outgoing_qty
                ,g.na_qty
                ,g.stock_count
                ,g.remark
                ,g.fob
                ,g.cbm
            }).Select(m => new stock_level_np {
                id = m.Key.id,
                product_code = m.Key.product_code,
                product_desc = m.Key.product_desc,
                status = m.Key.status,
                warehouseID = m.Key.warehouseID.ToString(),
                warehouse = m.Key.warehouse,
                on_hand_qty = m.Key.on_hand_qty,
                incoming_qty = m.Key.incoming_qty,
                outgoing_qty = m.Key.outgoing_qty,
                ob_outgoing_qty = m.Key.ob_outgoing_qty,
                na_qty = m.Key.na_qty,
                stock_count = m.Key.stock_count,
                remark = m.Key.remark,
                fob = m.Key.fob,
                cbm=m.Key.cbm
            })
            .OrderBy(o=>o.warehouse).ToList() ;

            if (!String.IsNullOrEmpty(search))
            {
                stocklevelbynp = (stocklevelbynp.Where(
                           s => s.product_code.ToLower().Contains(search.Trim().ToLower()) 
                           ||s.product_desc.ToLower().Contains(search.Trim().ToLower()) ||
                           s.warehouse.ToLower().Contains(search.Trim().ToLower())||
                           s.warehouseID.ToLower().Contains(search.Trim().ToLower())
                           )).ToList();
            }

            // query the total rows for calculating the total pages
            TotalRows = stocklevelbynp.Count();

            TotalPages = (int)Math.Ceiling((Double)(TotalRows / PageSize));

            // carrying parameters back to index page
            ViewData["TotalPages"] = TotalPages + 1;
            ViewData["p"] = p;
            ViewData["PreviousPage"] = (p > 1) ? p - 1 : 1;
            ViewData["NextPage"] = (p < TotalPages) ? p + 1 : TotalPages + 1;
            ViewData["TotalRows"] = TotalRows;
            ViewData["Search"] = search;
            ViewData["Category"] = Category;

            //Generating the Page list selection
            List<SelectListItem> SelectionList = new List<SelectListItem>();

            for (int i = 1; i < TotalPages + 2; i++)
            {
                SelectionList.Add(new SelectListItem
                {
                    Text = i.ToString(),
                    Value = (String.IsNullOrEmpty(search)) ? "./Stock_level_np?p=" + i.ToString()+ "&Category="+Category : "./Stock_level_np?p=" + i.ToString() + "&search=" + search+ "&Category="+Category,
                    Selected = (p == i) ? true : false
                });
            }

            var warehouseList = (from m in _context.Stocklevelnp
                                 join pr in _context.Products on m.product_code equals pr.product_code
                                 join w in _context.Warehouses on m.warehouse equals w.warehouse_id
                                 where pr.category10_desc == Category && m.on_hand_qty > 0
                                 select new SelectListItem
                                 {
                                     Text = string.Format("{0}{1}{2}", w.warehouse_id.PadLeft(10)," - ".PadLeft(10) , w.name),
                                     Value = "./Stock_level_np?p=" + 1 + "&search=" + w.name + "&Category=" + Category,
                                     Selected = search == w.name ? true : false
                                 }).Distinct().ToList();

            //var warehouseList = (_context.Warehouses.Where(a => _context.Stocklevelnp.Any(x => x.warehouse == a.warehouse_id && x.on_hand_qty>0))
            //    .Select(s => new SelectListItem
            //    {
            //        Text = s.warehouse_id + " -- " + s.name,
            //        Value = "./Stock_level_np?p=" + p + "&search=" + s.name + "&Category=" + Category,
            //        Selected = search == s.name ? true : false
            //    })).OrderBy(o=> o.Text).ToList();


            warehouseList.Insert(0, new SelectListItem {
                Text = "-- ALL --",
                Value = "./Stock_level_np?p=" + 1 + "&search="  + "&Category=" + Category,
                Selected = search == "-- ALL --" ? true : false
            });
            ViewData["WarehouseList"] = warehouseList;
            ViewData["PagesList"] = SelectionList;

            // return
            //ViewBag.Stocklevelnp = _context.Stocklevelnp.OrderBy(item => item.product_code).Skip((p - 1) * PageSize).Take(PageSize).ToList();
            //ViewBag.Products = _context.Products;
            //return View();
            return View(stocklevelbynp.OrderBy(item => item.warehouse).Skip((p - 1) * PageSize).Take(PageSize).ToList());
        }

        // GET: Stock Level by Category/Details
        public IActionResult Details(int? id, string Category,int? P,string Search)
        {
            ViewData["Category"] = Category;
            ViewData["P"] = P;
            ViewData["Search"] = Search;
            if (id == null)
            {
                return HttpNotFound();
            }

            //stock_level_np stocklevelnp = _context.Stocklevelnp.Single(m => m.id == id);
            stock_level_np stocklevelnp = (from m in _context.Stocklevelnp
                                           join pr in _context.Products on m.product_code equals pr.product_code
                                           where m.id == id
                                           select new stock_level_np
                                           {
                                               id = m.id,
                                               product_code = m.product_code,
                                               product_desc = m.product_desc,
                                               status = m.status,
                                               warehouse = m.warehouse,
                                               on_hand_qty = m.on_hand_qty,
                                               incoming_qty = m.incoming_qty,
                                               outgoing_qty = m.outgoing_qty,
                                               ob_outgoing_qty = m.ob_outgoing_qty,
                                               na_qty = m.na_qty,
                                               stock_count = m.stock_count,
                                               remark = m.remark,
                                               fob = pr.fob
                                           }).FirstOrDefault();
            if (stocklevelnp == null)
            {
                return HttpNotFound();
            }

            return View(stocklevelnp);
        }
    }
}
