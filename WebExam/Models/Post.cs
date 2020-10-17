using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace WebExam.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "Title")]  //[Required]欄位必須要輸入
        [StringLength(20, MinimumLength = 2, ErrorMessage = "最少需3個字元!")]    //設定字串最大限制，除非有設定MinimumLength不然不會報錯
        public string PostTitle { get; set; }

        public string PostContent { get; set; }

        public int PostNum { get; set; }
    }
}