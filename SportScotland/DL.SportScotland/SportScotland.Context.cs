﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL.SportScotland
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SportScotlandDevEntities : DbContext
    {
        public SportScotlandDevEntities()
            : base("name=SportScotlandDevEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Benificiary> Benificiaries { get; set; }
        public DbSet<Impact> Impacts { get; set; }
        public DbSet<ImpactRecord> ImpactRecords { get; set; }
        public DbSet<ImpactRecordBenificiary> ImpactRecordBenificiaries { get; set; }
    }
}
