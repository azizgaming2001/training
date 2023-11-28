using DEMO1.DataDBContext;
using DEMO1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DEMO1.Controllers
{
    public class TopicController : Controller
    {
        private readonly TrainingDBContext _dbContext;

        public TopicController(TrainingDBContext context)
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
            TopicDetail Topic = new TopicDetail();
            var topicList = _dbContext.Topics
                .Where(m => m.deleted_at == null)
                .Select(m => new SelectListItem { Value = m.course_id.ToString(), Text = m.name }).ToList();
            ViewBag.Stores = topicList;
            return View(Topic);
        }
    }
}
