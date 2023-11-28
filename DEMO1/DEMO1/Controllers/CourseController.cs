using DEMO1.DataDBContext;
using DEMO1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DEMO1.Controllers
{
    public class CourseController : Controller
    {
        private readonly TrainingDBContext _dbContext;

        public CourseController(TrainingDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            CourseDetail course = new CourseDetail();
            var categoryList = _dbContext.Categories
                .Where(m => m.deleted_at == null)
                .Select(m => new SelectListItem { Value = m.id.ToString(), Text = m.name }).ToList();
            ViewBag.Stores = categoryList;
            return View(course);
        }
    }
}