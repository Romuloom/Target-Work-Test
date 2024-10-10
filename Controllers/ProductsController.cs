using Cadastro.Interfaces;
using Cadastro.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductViewModelService _productViewModelService;
        private readonly IClientViewModelService _clientViewModelService;

        public ProductsController(IProductViewModelService productViewModelService, IClientViewModelService clientViewModelService)
        {
            _productViewModelService = productViewModelService;
            _clientViewModelService = clientViewModelService;
        }

        // GET: Products
        public ActionResult Index()
        {
            var products = _productViewModelService.GetAll();
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = _productViewModelService.Get(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            LoadClients();
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productViewModelService.Insert(viewModel);
                    return RedirectToAction(nameof(Index));
                }
                LoadClients();
                return View(viewModel);
            }
            catch
            {
                LoadClients();
                return View(viewModel);
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = _productViewModelService.Get(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            LoadClients();
            return View(viewModel);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productViewModelService.Update(viewModel);
                    return RedirectToAction(nameof(Index));
                }
                LoadClients();
                return View(viewModel);
            }
            catch
            {
                LoadClients();
                return View(viewModel);
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            var viewModel = _productViewModelService.Get(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _productViewModelService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var viewModel = _productViewModelService.Get(id);
                return View(viewModel);
            }
        }

        // Método auxiliar para carregar os clientes
        private void LoadClients()
        {
            var clients = _clientViewModelService.GetAll();
            ViewBag.Clients = new SelectList(clients, "Id", "Name");
        }
    }
}
