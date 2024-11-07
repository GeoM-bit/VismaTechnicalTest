using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VismaTechnicalTest.Abstractions;
using VismaTechnicalTest.Models;

namespace VismaTechnicalTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public HomeController(IDiscountService discountService, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
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
        public IActionResult SelectCustomer(int selectedCustomerId)
        {
            var customer = _customerRepository.GetCustomerById(selectedCustomerId);
            if (customer == null) return NotFound();

            return RedirectToAction("SelectProducts", new { customerId = selectedCustomerId });
        }

        public IActionResult SelectProducts(int customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            if (customer == null) return NotFound();
            var viewModel = new ProductSelectionViewModel
            {
                CustomerId = customer.Id,
                CustomerName = customer.Name,
                AvailableDiscounts = _customerRepository.GetDiscountTypesForCustomer(customerId),
                ProductsToOrder = _productRepository.GetProducts().Select(p => new ProductToOrder
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
            decimal standardTotalPrice = 0;
            decimal discountedTotalPrice = 0;

            foreach (var product in viewModel.ProductsToOrder)
            {
                var finalPrice = _discountService.CalculatePrice(viewModel.CustomerId, product);
                product.DiscountedPrice = finalPrice;
                standardTotalPrice += product.StandardPrice * product.Quantity;
                discountedTotalPrice += finalPrice * product.Quantity;
            }

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
