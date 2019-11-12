using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace LLShop.Models
{
    public class Category : PersistPoco
    {
        /// <summary>
        /// 
        /// </summary>
        [Required, MaxLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(512)]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Seq { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ParentCode { get; set; }
    }
}
