using AutoMapper;
using Cadastro.Domain.Entities;
using Cadastro.Interfaces;
using Cadastro.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cadastro.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientViewModelService _clientViewModelService;
        private readonly IMapper _mapper;

        public ClientsController(IClientViewModelService clientViewModelService, IMapper mapper)
        {
            _clientViewModelService = clientViewModelService;
            _mapper = mapper;
        }

        // GET: Clients
        public ActionResult Index()
        {
            var list = _clientViewModelService.GetAll();
            return View(list);
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = _clientViewModelService.Get(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clientViewModelService.Insert(viewModel);
                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = _clientViewModelService.Get(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClientViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clientViewModelService.Update(viewModel);
                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int id)
        {
            var viewModel = _clientViewModelService.Get(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _clientViewModelService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var viewModel = _clientViewModelService.Get(id);
                return View(viewModel);
            }
        }
    }
}
