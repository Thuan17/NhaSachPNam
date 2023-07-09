using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2001207369_Thuan_LTWeb.ViewModel
{
    public class Register
    {
        [Key]
        [Required(ErrorMessage = "Bạn Cần Nhập UserName")]
        [RegularExpression("^([a-zA-Z0-9ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\\s]+)$", ErrorMessage = "Không Được Nhập Ký Tự Đặt Biệt")]
        //[RegularExpression("^([a-zA-Z 0-9\\s]+)$", ErrorMessage = "Không Được Nhập Ký Tự Đặt Biệt")]
        public string UserName { get; set; }

        [MinLength(4, ErrorMessage = "Trên 8 Ký Tự")]
        [Required(ErrorMessage = "Bạn Cần Nhập Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bạn Cần Nhập ConfirmPassword")]
        [Compare("Password", ErrorMessage = "Không Giống Password")]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage = "Định Dạng Chưa Đúng")]
        [Required(ErrorMessage = "Bạn Cần Nhập Email")]
        public string Email { get; set; }


        public string Phone { get; set; }
        public DateTime? BrithDay { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Anh { get; set; }
    }
}