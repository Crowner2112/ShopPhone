using Models.DAO;
using Models.EF;
using ShopPhone.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ShopPhone.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            var model = new Order();
            if (Session["user"] != null)
            {
                var user = Session["user"] as Account;
                model.OwnerName = user.Name;
                model.PhoneNumber = user.PhoneNumber;
                model.Address = user.Address;
            }
            Cart cart = Session["Cart"] as Cart;
            var listCart = cart.Items.ToList();
            ViewData["cart"] = listCart;
            return View(model);
        }

        [HttpPost]
        public ActionResult Execute(Order order)
        {
            if (ModelState.IsValid)
            {
                var orderDao = new OrderDao();
                order.CreatedDate = DateTime.Now;
                order.Status = false;
                order.TotalPrice = (int)Session["Total"] + 30000;
                var idOrder = orderDao.Insert(order);
                if (idOrder >= 0)
                {
                    Cart cart = Session["Cart"] as Cart;
                    var listCart = cart.Items.ToList();
                    foreach (var item in listCart)
                    {
                        var orderDetail = new OrderDetail();
                        orderDetail.OrderID = idOrder;
                        orderDetail.ProductID = item.ProductID;
                        orderDetail.Quantity = item.Quantity;
                        new OrderDetailDao().Create(orderDetail);
                    }
                    Session["Cart"] = new Cart();
                }
                return new ContentResult()
                {
                    Content = "<script language='javascript' type='text/javascript'>alert('Đơn hàng được tạo thành công! Cảm ơn quý khách hàng!');location.href='/'</script>"
                };
            }
            else
            {
                return RedirectToAction("Index", "Payment");
            }
        }
    }
}