using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace LLShop.Models
{
    public class Category : BasePoco
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "分类名称")]
        [Required, MaxLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "分类描述")]
        [MaxLength(512)]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "图片")]
        public string PicUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "排序")]
        public int Seq { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "编码")]
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "父编码")]
        public string ParentCode { get; set; }

        [Display(Name = "商品")]
        public List<Goods> Goods { get; set; }
        
        [Display(Name = "图片")]
        public FileAttachment FileAttachment { get; set; }
        
        [Display(Name = "父级Id")]
        [ForeignKey("Id")]
        public Guid? ParentId { get; set; }
        
        [Display(Name = "父级")]
        public virtual Category Parent { get; set; }
        
        [Display(Name = "子级")]
        public virtual List<Category> Childs  { get; set; }
        
//        /// <summary>
//        /// 
//        /// </summary>
//        [Display(Name = "父Id")]
//        public int CategoryRelationId { get; set; }
//        
//        [Display(Name = "父节点")]
//        public CategoryRelation CategoryRelation { get; set; }
//        
//        [Display(Name = "子节点")]
//        public List<CategoryRelation> CategoryRelations { get; set; }
    }
}
