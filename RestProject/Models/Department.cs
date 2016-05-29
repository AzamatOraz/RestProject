using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestProject.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string DepName { get; set; }
    }
}