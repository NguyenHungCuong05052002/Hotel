using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDACS.Models;
using WebDACS.Models.EF;

namespace WebDACS.Controllers
{
    public class AdvController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Adv
        public ActionResult Index(int? page)
        {
            var pageSize = 1;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Adv> items = db.Advs.OrderByDescending(x => x.CreatedDate);
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult Detail(int id)
        {
            var item = db.Advs.Find(id);
            return View(item);
        }
    }
}