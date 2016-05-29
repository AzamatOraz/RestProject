using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestProject.Models
{
    public class Staff
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public DateTime HireDate { get; set; }
        public int Manager_ID { get; set; }
        public int Department_ID { get; set; }

        public virtual Department Department { get; set; }
    }
}