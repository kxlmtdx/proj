﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proj.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ХУЙГОЙДАПЕНИСЗАЛУПАEntities1 : DbContext
    {
        public ХУЙГОЙДАПЕНИСЗАЛУПАEntities1()
            : base("name=ХУЙГОЙДАПЕНИСЗАЛУПАEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Car_Price> Car_Price { get; set; }
        public virtual DbSet<Mark> Mark { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Staff1> Staff1 { get; set; }
        public virtual DbSet<Type_KPP> Type_KPP { get; set; }
        public virtual DbSet<Type_Privod> Type_Privod { get; set; }
        public virtual DbSet<Type1> Type1 { get; set; }
        public virtual DbSet<Year_Car> Year_Car { get; set; }
    }
}
