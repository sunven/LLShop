using System.Collections.Generic;
using System.Linq;
using WalkingTec.Mvvm.Core;
using LLShop.Models;


namespace LLShop.ViewModels.CategoryVMs
{
    public partial class CategoryListVM : BasePagedListVM<Category_View, CategorySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Category", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("Category", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("Category", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("Category", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("Category", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("Category", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("Category", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("Category", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<Category_View>> InitGridHeader()
        {
            return new List<GridColumn<Category_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Description),
                this.MakeGridHeader(x => x.Seq),
                this.MakeGridHeader(x => x.FileAttachmentId).SetFormat(FileAttachmentIdFormat),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> FileAttachmentIdFormat(Category_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.FileAttachmentId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.FileAttachmentId,640,480),
            };
        }


        public override IOrderedQueryable<Category_View> GetSearchQuery()
        {
            var query = DC.Set<Category>()
                .Select(x => new Category_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    Description = x.Description,
                    Seq = x.Seq,
                    FileAttachmentId = x.FileAttachmentId,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Category_View : Category{

    }
}
