using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Category")]
    public class Category:CommonAbstract
    {
        public Category()
        {
            this.News = new HashSet<New>(); // đảm bảo rằng khi tạo 1 đối tượng category, thuộc tính news sẽ được khởi tạo và sẵn sàng để sử dụng
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] // Khóa chính được tạo tự động tăng
        public int Id { get; set; }
        [Required(ErrorMessage ="Tên danh mục không được để trống")]
        [StringLength(150)]
        public string Title { get; set; }
        
        public string Alias { get; set; } // tạo đường link url
        //[StringLength(150)]
        //public string TypeCode { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        [StringLength(150)]
        public string SeoTitle { get; set; }
        [StringLength(250)]
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public bool IsActive { get; set; }
        public ICollection<New> News { get; set; } // một danh mục có thể có nhiều bài báo
        public ICollection<Post> Posts { get; set; } // 
    }
}