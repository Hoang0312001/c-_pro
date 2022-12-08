
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EF.Entity
{
    [Table("Product")]
    public class Product : Common
    {

        // [StringLength(250)]
        public string Provider { set; get; }

        // [Column(TypeName = "Money")]
        public decimal Price { set; get; }

        // sinh khoa ngoai voi category
        // [ForeignKey("CateID")] tu dat 

        // public int? CategoryId { set; get; } //  thêm thuộc tính (nullable) lay truc tiep ky ben duoi chi goi ca model
        public Category? category { set; get; }


    }
}

// neu dung Required /* Khi xóa Category, các sản phẩm thuộc về nó cũng bị xóa theo */

// Cũng lưu ý nếu bạn khai báo không phải nullable (int?) cho CategoryId, 
// hoặc bạn chỉ định rõ là nó không được NULL bằng thuộc tính mô tả [Required] thì nó sẽ thực hiện kiểm tra ràng buộc dữ liệu
// , CategoryID là giá trị phải có trong bảng Category, hoặc khi xóa một Category thì các sản phẩm thuộc mục này cũng xóa theo.

