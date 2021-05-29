using Models.DAO;
using Models.EF;
using System.Web.Mvc;

namespace ShopPhone.Areas.Admin.Controllers
{
    public class BrandController : BaseController
    {
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new BrandDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var Brand = new BrandDao().ViewDetail(id);
            return View(Brand);
        }
        [HttpPost]
        public ActionResult Create(Brand Brand)
        {
            if (ModelState.IsValid)
            {
                var dao = new BrandDao();
                var id = dao.Create(Brand);
                if (id)
                {
                    return RedirectToAction("Index", "Brand");
                }
                else
                {
                    ModelState.AddModelError("", "Add Brand successfully");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new BrandDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Brand Brand)
        {
            if (ModelState.IsValid)
            {
                var dao = new BrandDao();
                var result = dao.Update(Brand);
                if (result)
                {
                    return RedirectToAction("Index", "Brand");
                }
                else
                {
                    ModelState.AddModelError("", "Modify successfully");
                }
            }
            return View("Index");
        }
    }
}