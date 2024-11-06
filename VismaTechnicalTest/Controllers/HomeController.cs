using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VismaTechnicalTest.Abstractions;
using VismaTechnicalTest.Models;

namespace VismaTechnicalTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDiscountService _discountService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        public HomeController(ILogger<HomeController> logger, IDiscountService discountService, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _logger = logger;
            _discountService = discountService;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var customers = _customerRepository.GetCustomers();
            var viewModel = new CustomerSelectionViewModel
            {
                Customers = customers
            };
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult SelectCustomer(CustomerSelectionViewModel viewModel)
        {
            viewModel.Customers = _customerRepository.GetCustomers();

            var selectedCustomer = viewModel.Customers.FirstOrDefault(c => c.Id == viewModel.SelectedCustomerId);
            if (selectedCustomer == null)
            {
                ModelState.AddModelError("SelectedCustomerId", "Please select a valid customer.");
                return View("Index", viewModel);
            }

            TempData["SelectedCustomerId"] = selectedCustomer.Id;
            TempData["SelectedCustomerName"] = selectedCustomer.Name;
            return RedirectToAction("SelectProducts", new { customerId = selectedCustomer.Id });

        }

        public IActionResult SelectProducts(int customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            if (customer == null) return NotFound();

            var products = _productRepository.GetProducts(); 

            var viewModel = new ProductSelectionViewModel
            {
                CustomerId = customer.Id,
                CustomerName = customer.Name,
                ProductsToOrder = products.Select(p => new ProductToOrder
                {
                    Id = p.Id,
                    Name = p.Name,
                    StandardPrice = p.StandardPrice,
                    HasSpecialDiscount = p.HasSpecialDiscount,
                    SpecialDiscount = p.SpecialDiscount,
                    Quantity = 0
                }).ToList()
            };

            return View(viewModel);
        }



        [HttpPost]
        public IActionResult CalculatePrice(ProductSelectionViewModel viewModel)
        {
            viewModel.ProductsToOrder = viewModel.ProductsToOrder.Where(x => x.Quantity > 0).ToList();
            var customer = _customerRepository.GetCustomerById(viewModel.CustomerId);
            if (customer == null) return NotFound();

            decimal standardTotalPrice = 0;
            decimal discountedTotalPrice = 0;

            foreach (var product in viewModel.ProductsToOrder)
            {
                var finalPrice = _discountService.CalculatePrice(customer, product);
                product.DiscountedPrice = finalPrice;
                standardTotalPrice += product.StandardPrice * product.Quantity;
                discountedTotalPrice += finalPrice * product.Quantity;
            }

            ViewBag.CustomerName = customer.Name;
            ViewBag.StandardTotalPrice = standardTotalPrice;
            ViewBag.DiscountedTotalPrice = discountedTotalPrice;

            return View("Summary", viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
