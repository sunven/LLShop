using System;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Attributes;

namespace LLShop.Models
{
    [MiddleTable]
    public class CategoryRelation:BasePoco
    {
        public Category Category { get; set; }

        public Guid CategoryId { get; set; }
    }
}