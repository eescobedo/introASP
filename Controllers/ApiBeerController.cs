using introASP.Models;
using introASP.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace introASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBeerController : ControllerBase
    {
        private readonly CursoMVCCoreContext _context;

        public ApiBeerController(CursoMVCCoreContext context)
        {
            _context = context;
        }

        public async Task<List<BeerBrandViewModel>> Get()
            => await _context.Beers.Include(b=> b.Brand)
            .Select(b=> new BeerBrandViewModel
            {
                Name = b.Name,
                Brand = b.Brand.Name
            }).ToListAsync();            
    }
}
