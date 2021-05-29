using Models.DAO;
using Models.EF;
using System.Web.Mvc;

namespace ShopPhone.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new ProductDao();
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
            var Product = new ProductDao().ViewDetail(id);
            return View(Product);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product Product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var id = dao.Create(Product);
                if (id)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Add Product successfully");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product Product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(Product);
                if (result)
                {
                    return RedirectToAction("Index", "Product");
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