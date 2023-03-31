﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        //Erişim Belirleyici Türü - Değişken Türü - İsim - {get set}

        [Key]
        public int BlogID { get; set; }
        [Display(Name ="Blog Konusu")]
        [Required(ErrorMessage ="{0} gereklidir.")]
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
		public int WriterID { get; set; }
		public Writer Writer { get; set; }
		public List<Comment> Comments { get; set; }
    }
}
