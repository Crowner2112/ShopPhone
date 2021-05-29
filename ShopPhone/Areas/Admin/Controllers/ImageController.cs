using Models.DAO;
using System.Web.Mvc;
using Image = Models.EF.Image;

namespace ShopPhone.Areas.Admin.Controllers
{
    public class ImageController : BaseController
    {
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new ImageDao();
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
            var Image = new ImageDao().ViewDetail(id);
            return View(Image);
        }
        [HttpPost]
        public ActionResult Create(Image Image)
        {
            if (ModelState.IsValid)
            {
                var dao = new ImageDao();
                var id = dao.Create(Image);
                if (id)
                {
                    return RedirectToAction("Index", "Image");
                }
                else
                {
                    ModelState.AddModelError("", "Add Image successfully");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ImageDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Image Image)
        {
            if (ModelState.IsValid)
            {
                var dao = new ImageDao();
                var result = dao.Update(Image);
                if (result)
                {
                    return RedirectToAction("Index", "Image");
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