using Models.DAO;
using Models.EF;
using System.Web.Mvc;

namespace ShopPhone.Areas.Admin.Controllers
{
    public class OrderDetailController : BaseController
    {
        public ActionResult Index(int orderId, int page = 1, int pageSize = 10)
        {
            var dao = new OrderDetailDao();
            var model = dao.ListAllPaging(orderId, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(OrderDetail OrderDetail)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDetailDao();
                var id = dao.Create(OrderDetail);
                if (id)
                {
                    return RedirectToAction("Index", "OrderDetail");
                }
                else
                {
                    ModelState.AddModelError("", "Add OrderDetail successfully");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new OrderDetailDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(OrderDetail OrderDetail)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDetailDao();
                var result = dao.Update(OrderDetail);
                if (result)
                {
                    return RedirectToAction("Index", "OrderDetail");
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