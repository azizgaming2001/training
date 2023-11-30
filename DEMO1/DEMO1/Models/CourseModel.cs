using DEMO1.Validations;
using System.ComponentModel.DataAnnotations;

namespace DEMO1.Models
{
    public class CourseModel
    {
        public List<CourseDetail> CourseDetailLists { get; set; }
        
    }

    public class CourseDetail
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Enter name,please")]
        public int category_id { get; set; }
        public string name { get; set; }

        public string? description { get; set; }

        [DisplayFormat(DataFormatString = "(0.dd/MM/yyyy)", ApplyFormatInEditMode = true)]
        public DateTime start_date { get; set; }
        [DisplayFormat(DataFormatString = "(0.dd/MM/yyyy)", ApplyFormatInEditMode = true)]
        public DateTime? end_date {  get; set; }
        public int? vote {  get; set; }
        public string avatar { get; set; }
        [Required(ErrorMessage = "Choose status, please")]
        public string status { get; set; }
        [Required(ErrorMessage = "Choose file")]
        [AllowExtentionFIle(new string[] { ".png", ".jpg", ".jpeg", ".gif" })]
        [AllowSizeFile(8 * 1024 * 1024)]
        public IFormFile Photo { get; set; }
        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }

        public DateTime? deleted_at { get; set; }
    }
}