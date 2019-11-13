using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Attributes;

namespace LLShop.Models
{
    public class Goods : BasePoco
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "商品名称")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "商品价格")]
        public int Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "商品分类Id")]
        [Required]
        public Guid CategoryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Category Category { get; set; }
        
        [Display(Name = "图片")]
        public List<FileAttachment> FileAttachments { get; set; }
    }
}