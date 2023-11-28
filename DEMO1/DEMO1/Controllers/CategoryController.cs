using DEMO1.DataDBContext;
using DEMO1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DEMO1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly TrainingDBContext _dbContext;
        public CategoryController(TrainingDBContext context)
        {
            _dbContext = context;
        }
        private bool checkUserLogin()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionUserName")))
            {
                return false;
            }
            return true;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //if (!checkUserLogin())
            //{
            //    return RedirectToAction(nameof(LoginController.Index), "Login");
            //}
            CategoryModel categoryModel = new CategoryModel();
            categoryModel.CategoryDetailLists = new List<CategoryDetail>();
            var data = _dbContext.Categories.Where(m => m.deleted_at == null).ToList();
            foreach (var item in data)
            {
                categoryModel.CategoryDetailLists.Add(new CategoryDetail
                {
                    id = item.id,
                    name = item.name,
                    description = item.description,
                    icon = item.icon,
                    status = item.status,
                    created_at = item.created_at,
                    updated_at = item.updated_at
                });
            }

            return View(categoryModel);
        }
        [HttpGet]
        public IActionResult Add()
        {
            //if (!checkUserLogin())
            //{
            //    return RedirectToAction(nameof(LoginController.Index), "Login");
            //}
            CategoryDetail category = new CategoryDetail();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CategoryDetail category, IFormFile Photo) 
        {

            if (ModelState.IsValid)
            {
                try
                {
                    string uniqueFileName = UpLoadFile(Photo);
                    var categoryData = new category()
                    {
                        name = category.name,
                        description = category.description,
                        icon = uniqueFileName,
                        status = category.status,
                        created_at = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                    _dbContext.Categories.Add(categoryData);
                    _dbContext.SaveChanges(true);
                    TempData["SaveStatus"] = true;
                }
                catch
                {
                    TempData["SaveStatus"] = false;
                }
                return RedirectToAction(nameof(CategoryController.Index), "Category");

            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Update(int id = 0) 
        {
            CategoryDetail category = new CategoryDetail();
            var data = _dbContext.Categories.Where(m => m.id == id).FirstOrDefault();
            if(data != null)
            {
                category.id = data.id;
                category.name = data.name;
                category.description = data.description;
                category.icon = data.icon;
                category.status = data.status;
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(CategoryDetail category, IFormFile Photo)
        {
            try
            {
                var data = _dbContext.Categories.Where(m => m.id == category.id).FirstOrDefault();
                string uniqueIconAvatar = UpLoadFile(Photo);
                
                if (data != null)
                {
                    data.name = category.name;
                    data.description = category.description; 
                    data.status = category.status;
                    if (!string.IsNullOrEmpty(uniqueIconAvatar))
                    {
                       
                        data.icon = uniqueIconAvatar;
                    }
                    _dbContext.SaveChanges(true);
                    TempData["UpdateStatus"] = true;
                }
                else
                {
                    TempData["UpdateStatus"] = false;
                }
            }
            catch
            {
                TempData["UpdateStatus"] = false;
            }
            return RedirectToAction(nameof(CategoryController.Index), "Category");
        }

        [HttpGet]
        public IActionResult Delete(int id = 0)
        {
            try
            {
                var data = _dbContext.Categories.Where(m => m.id == id).FirstOrDefault();
                if(data != null)
                {
                    data.deleted_at = Convert.ToDateTime(DateTime.Now.ToString ("yyyy-MM-dd HH:mm:ss"));
                    _dbContext.SaveChanges(true);
                    TempData["DeleteStatus"] = true;
                }
                else
                {
                    TempData["DeleteStatus"] = false;
                }
            }
            catch
            {
                TempData["DeleteStatus"] = false;
            }
            return RedirectToAction(nameof(CategoryController.Index), "Category");
        }
        private string UpLoadFile(IFormFile file)
        {
            string uniqueFileName;
            try 
            {
                // Check if file is null
                if (file == null)
                {
                    // Return an empty string or a default image name
                    return "";
                }
                string pathUploadServer = "wwwroot\\uploads\\images";
                string fileName = file.FileName;
                fileName = Path.GetFileName(fileName);
                string uniqueStr = Guid.NewGuid().ToString();//tao ra cac ky tu ko trung lap
                fileName = uniqueStr + "~" + fileName;
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), pathUploadServer, fileName);
                var stream = new FileStream(uploadPath, FileMode.Create);
                file.CopyToAsync(stream);
                uniqueFileName = fileName;
            }
            catch(Exception ex)
            {
                uniqueFileName = ex.Message.ToString();
            }
            return uniqueFileName;
        }
    }
}