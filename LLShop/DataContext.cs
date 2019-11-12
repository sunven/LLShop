using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using LLShop.Models;
using WalkingTec.Mvvm.Core;

namespace LLShop
{
    public class DataContext : FrameworkContext
    {
        public DataContext(string cs, DBTypeEnum dbtype)
             : base(cs, dbtype)
        {
        }
        
        public DbSet<Category> Category { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<Goods> Goods { get; set; }

    }

    /// <summary>
    /// 为EF的Migration准备的辅助类，填写完整连接字符串和数据库类型
    /// 就可以使用Add-Migration和Update-Database了
    /// </summary>
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            return new DataContext("User ID=postgres;Password=1234;Host=localhost;Port=5432;Database=LLShop;", DBTypeEnum.PgSql);
        }
    }

}
