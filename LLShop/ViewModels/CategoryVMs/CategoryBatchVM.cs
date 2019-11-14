using WalkingTec.Mvvm.Core;
using LLShop.Models;


namespace LLShop.ViewModels.CategoryVMs
{
    public partial class CategoryBatchVM : BaseBatchVM<Category, Category_BatchEdit>
    {
        public CategoryBatchVM()
        {
            ListVM = new CategoryListVM();
            LinkedVM = new Category_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class Category_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
