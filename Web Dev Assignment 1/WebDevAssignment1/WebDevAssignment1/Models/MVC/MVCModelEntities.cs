using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebDevAssignment1.Models.MVC
{
    public class MVCModelEntities : DbContext
    {

        public MVCModelEntities() : base("name=MVCModel")
        {

        }

        public virtual DbSet<ItemModel> Items { get; set; }


    }
}