using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBAPITEST.src.Infrastructure.Data;

namespace WEBAPITEST.Controllers
{
    public class StudentsController : Controller
    {
       /* private readonly SchoolContext _context;
        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> GetAll()
        {
            return View(await _context.Students.ToListAsync());
        }*/
    }
}
