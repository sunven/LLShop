using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WalkingTec.Mvvm.Core;
using LLShop.Controllers;
using LLShop.ViewModels.CategoryVMs;
using LLShop.Models;

namespace LLShop.Test
{
    [TestClass]
    public class CategoryApiTest
    {
        private CategoryController _controller;
        private string _seed;

        public CategoryApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<CategoryController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            string rv = _controller.Search(new CategorySearcher());
            Assert.IsTrue(string.IsNullOrEmpty(rv)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            CategoryVM vm = _controller.CreateVM<CategoryVM>();
            Category v = new Category();
            
            v.Name = "RBJ";
            v.Seq = 52;
            v.FileAttachmentId = AddFileAttachment();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Category>().FirstOrDefault();
                
                Assert.AreEqual(data.Name, "RBJ");
                Assert.AreEqual(data.Seq, 52);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Category v = new Category();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Name = "RBJ";
                v.Seq = 52;
                v.FileAttachmentId = AddFileAttachment();
                context.Set<Category>().Add(v);
                context.SaveChanges();
            }

            CategoryVM vm = _controller.CreateVM<CategoryVM>();
            var oldID = v.ID;
            v = new Category();
            v.ID = oldID;
       		
            v.Name = "fqP";
            v.Seq = 90;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Seq", "");
            vm.FC.Add("Entity.FileAttachmentId", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Category>().FirstOrDefault();
 				
                Assert.AreEqual(data.Name, "fqP");
                Assert.AreEqual(data.Seq, 90);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Category v = new Category();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Name = "RBJ";
                v.Seq = 52;
                v.FileAttachmentId = AddFileAttachment();
                context.Set<Category>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Category v1 = new Category();
            Category v2 = new Category();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "RBJ";
                v1.Seq = 52;
                v1.FileAttachmentId = AddFileAttachment();
                v2.Name = "fqP";
                v2.Seq = 90;
                v2.FileAttachmentId = v1.FileAttachmentId; 
                context.Set<Category>().Add(v1);
                context.Set<Category>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<Category>().Count(), 0);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Guid AddFileAttachment()
        {
            FileAttachment v = new FileAttachment();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.FileName = "Kl0IBPMG";
                v.FileExt = "gXS6UrNR4";
                v.Length = 12;
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
