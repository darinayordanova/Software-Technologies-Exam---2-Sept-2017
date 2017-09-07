using System.Linq;
using System.Web.Mvc;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    [ValidateInput(false)]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var database = new ShoppingListDbContext())
            {
                var products = database.Products.ToList();
                return View(products);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                using (var database = new ShoppingListDbContext())
                {
                    database.Products.Add(product);
                    database.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            using (var database = new ShoppingListDbContext())
            {
                var product = database.Products.Find(id);
                if (product == null)
                {
                    return RedirectToAction("Index");
                }
                return View(product);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Product productModel)
        {
            using (var database = new ShoppingListDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }

                Product taskFromDB = database.Products.Find(productModel.Id);

                if (taskFromDB == null)
                {
                    return new HttpNotFoundResult($"Cannot find Task with ID {id}");
                }

                taskFromDB.Priority = productModel.Priority;
                taskFromDB.Name = productModel.Name;
                taskFromDB.Quantity = productModel.Quantity;
                taskFromDB.Status = productModel.Status;
                database.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}