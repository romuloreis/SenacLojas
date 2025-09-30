using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenacLojas.Data;
using SenacLojas.Migrations;
using SenacLojas.Models;
using SenacLojas.Models.ViewModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace SenacLojas.Controllers
{
    public class SellersController : Controller
    {
        public readonly SenacLojasContext _context;

        public SellersController(SenacLojasContext context) { 
            _context = context;
        }

        public IActionResult Index()
        {
            List<Seller> sellers = _context.Seller.ToList();
            return View(sellers);
        } 

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seller seller = _context.Seller
                                .Include("Department")
                                .FirstOrDefault(sr => sr.Id == id);

            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        public IActionResult Delete(int id) {
            if (id == null)
            {
                return NotFound();
            }
            Seller seller = _context.Seller
                            .Include("Department")
                            .FirstOrDefault(sr => sr.Id == id);
            if (seller == null)
            {
                return NotFound();
            }
            return View(seller);
        }
        [HttpPost]
        public IActionResult Delete(int? id) { 
            if(id == null)
            {
                return NotFound();
            }
            Seller seller = _context.Seller
                            .FirstOrDefault(sr => sr.Id == id);
            if (seller == null)
            {
                return NotFound();
            }
            _context.Remove(seller);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create() { 
            /*Cria um objeto view model e popula a 
             * lista de departamentos*/
            var viewModel = new SellerFormViewModel();
            viewModel.Departments = _context.Department.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Seller seller) {
            if (seller == null) { 
                return NotFound();
            }
            /*seller.Department = _context.Department.First();
            seller.DepartmentId = seller.Department.Id;*/
            /*_context.Seller.Add(seller);*/
            _context.Add(seller);
            _context.SaveChanges();
            return RedirectToAction("Index");                       
        }

        public IActionResult Edit(int id)
        {
            if (id == null) {
                return NotFound();
            }

            var seller = _context.Seller.First(sr => sr.Id == id);
            
            if (seller == null)
            {
                return NotFound();
            }

            SellerFormViewModel viewModel = new SellerFormViewModel();
            viewModel.Seller = seller;
            viewModel.Departments = _context.Department.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Seller seller) { 
            _context.Update(seller);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
