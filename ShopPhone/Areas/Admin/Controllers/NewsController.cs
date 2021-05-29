using Models.DAO;
using Models.EF;
using System.Web.Mvc;

namespace ShopPhone.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new NewsDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(News News)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsDao();
                var result = dao.Update(News);
                if (result)
                {
                    return RedirectToAction("Index", "News");
                }
                else
                {
                    ModelState.AddModelError("", "Modify successfully");
                }
            }
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            var News = new NewsDao().ViewDetail(id);
            return View(News);
        }
        [HttpPost]
        public ActionResult Create(News News)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsDao();
                var id = dao.Create(News);
                if (id)
                {
                    return RedirectToAction("Index", "News");
                }
                else
                {
                    ModelState.AddModelError("", "Add News successfully");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new NewsDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}