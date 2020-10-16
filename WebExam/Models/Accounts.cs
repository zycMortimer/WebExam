using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebExam.Models
{
    public class Accounts
    {
        [Key]
        [Required(ErrorMessage = "請輸入帳號")]   //[Required]欄位必須要輸入
        public string Account { get; set; }

        [Required]  //[Required]欄位必須要輸入
        [StringLength(20, MinimumLength = 3, ErrorMessage = "最少需3個字元!")]    //設定字串最大限制，除非有設定MinimumLength不然不會報錯
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}