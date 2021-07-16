using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class phonebook
    {
        public virtual int id {  get; set; }
        public virtual string username {  get; set;  }
        public virtual string number { get; set; }
    }
}