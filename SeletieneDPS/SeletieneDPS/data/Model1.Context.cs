﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeletieneDPS.data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class seletieneEntities : DbContext
    {
        public seletieneEntities()
            : base("name=seletieneEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<category> category { get; set; }
        public virtual DbSet<city> city { get; set; }
        public virtual DbSet<collective> collective { get; set; }
        public virtual DbSet<department> department { get; set; }
        public virtual DbSet<productservice> productservice { get; set; }
        public virtual DbSet<qualificationps> qualificationps { get; set; }
        public virtual DbSet<state> state { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<userapp> userapp { get; set; }
        public virtual DbSet<usercallcenter> usercallcenter { get; set; }
    }
}
