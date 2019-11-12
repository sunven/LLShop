using WalkingTec.Mvvm.Core;

namespace LLShop.Models
{
    public class Goods : PersistPoco
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CategoryId { get; set; }
    }
}