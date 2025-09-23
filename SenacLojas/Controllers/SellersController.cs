using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenacLojas.Data;
using SenacLojas.Migrations;
using SenacLojas.Models;
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

    }
}
