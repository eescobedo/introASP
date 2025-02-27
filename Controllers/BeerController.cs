﻿using introASP.Models;
using introASP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace introASP.Controllers
{
    public class BeerController : Controller
    {
        private readonly CursoMVCCoreContext _context;

        public BeerController(CursoMVCCoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var beers = _context.Beers.Include(b => b.Brand);
            return View(await beers.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BeerViewModel model)
        {
            if (ModelState.IsValid){
                var beer = new Beer()
                {
                    Name = model.Name,
                    BrandId = model.BrandId,
                };
                
                _context.Add(beer);
                
                // save data to database
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name", model.BrandId);
            return View(model);
        }
    }
}
