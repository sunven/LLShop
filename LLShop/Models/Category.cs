using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace LLShop.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Category : BasePoco,ITreeData<Category>
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        [Display(Name = "分类名称")]
        [Required, MaxLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// 分类描述
        /// </summary>
        [Display(Name = "分类描述")]
        [MaxLength(512)]
        public string Description { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name = "排序")]
        public int Seq { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Display(Name = "编码")]
        public string Code { get; set; }

        /// <summary>
        /// 父编码
        /// </summary>
        [Display(Name = "父编码")]
        public string ParentCode { get; set; }

        /// <summary>
        /// 商品
        /// </summary>
        [Display(Name = "商品")]
        public List<Goods> Goods { get; set; }
        
        /// <summary>
        /// 附件Id
        /// </summary>
        [Display(Name = "附件Id")]
        public Guid FileAttachmentId { get; set; }
        
        /// <summary>
        /// 附件
        /// </summary>
        [Display(Name = "附件")]
        public FileAttachment FileAttachment { get; set; }
        
        /// <summary>
        /// 父级Id
        /// </summary>
        [Display(Name = "父级Id")]
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 子级
        /// </summary>
        [Display(Name = "子级")]
        public List<Category> Children { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        [Display(Name = "父级")]
        public Category Parent { get; set; }
    }
}
