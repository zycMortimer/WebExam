using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebExam.Models
{
    public class Employee
    {
        public int Id { get; set; }
        

        [Required]  //[Required]欄位必須要輸入
        [StringLength(20,MinimumLength =3,ErrorMessage ="最少需3個字元!")]    //設定字串最大限制，除非有設定MinimumLength不然不會報錯
        public string Name { get; set; }
        
        [Required]  //[Required]欄位必須要輸入
        [RegularExpression(@"^\d{4}\-?\d{3}\-?\d{3}$", ErrorMessage = "需為09xx-xxx-xxx格式")]  //[RegularExpression]用正規表示的pattern來進行驗證
        public string Mobile { get; set; }
        
        [Required(ErrorMessage = "請輸入Email")]   //[Required]欄位必須要輸入
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "請輸入Department")]  //[Required]欄位必須要輸入
        public string Department { get; set; }
        
        [Required(ErrorMessage = "請輸入Title")]   //[Required]欄位必須要輸入
        public string Title { get; set; }
    }
}