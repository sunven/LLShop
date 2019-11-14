using WalkingTec.Mvvm.Core;
using LLShop.Models;


namespace LLShop.ViewModels.CategoryVMs
{
    public partial class CategoryVM : BaseCRUDVM<Category>
    {

        public CategoryVM()
        {
            SetInclude(c=>c.Parent);
        }

        protected override void InitVM()
        {
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
