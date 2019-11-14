using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using LLShop.Models;


namespace LLShop.ViewModels.CategoryVMs
{
    public partial class CategoryTemplateVM : BaseTemplateVM
    {
        [Display(Name = "分类名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Category>(x => x.Name);
        [Display(Name = "分类描述")]
        public ExcelPropety Description_Excel = ExcelPropety.CreateProperty<Category>(x => x.Description);
        [Display(Name = "排序")]
        public ExcelPropety Seq_Excel = ExcelPropety.CreateProperty<Category>(x => x.Seq);

	    protected override void InitVM()
        {
        }

    }

    public class CategoryImportVM : BaseImportVM<CategoryTemplateVM, Category>
    {

    }

}
