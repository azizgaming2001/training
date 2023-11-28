using DEMO1.Validations;
using System.ComponentModel.DataAnnotations;

namespace DEMO1.Models
{
    public class TopicModel
    {
            public List<TopicDetail> TopcDetailLists { get; set; }
        }

    public class TopicDetail
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Enter name,please")]
        public string course_id { get; set; }
        public string name { get; set; }

        public string? description { get; set; }

        public int? videos { get; set; }
        public string documents { get; set; }
        public string attach_file { get; set; }
        [Required(ErrorMessage = "Choose file")]
        [AllowExtentionFIle(new string[] { ".dox", ".jpg", ".jpeg", ".gif" })]
        [AllowSizeFile(8 * 1024 * 1024)]
        public IFormFile File { get; set; }
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

