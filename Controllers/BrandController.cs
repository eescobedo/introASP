using introASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace introASP.Controllers
{
    public class BrandController : Controller
    {
        private readonly CursoMVCCoreContext _context;

        public BrandController(CursoMVCCoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Brands.ToListAsync());
        }
    }
}
