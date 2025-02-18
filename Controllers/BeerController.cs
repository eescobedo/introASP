using introASP.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
