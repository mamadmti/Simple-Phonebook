using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace WebApplication4.Models
{
    public class PhonebookDB:DbContext
    {

        public PhonebookDB()
        {

        }
        public DbSet<phonebook> Phonebooks { get; set; }
    }
}