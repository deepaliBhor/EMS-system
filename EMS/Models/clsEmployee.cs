using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
    public class ClsEmployee
    {
        [Required(ErrorMessage ="Please Provide User Name")]
        public string UName { get; set; }

        [Required(ErrorMessage = "Please Provide Password")]
        public string PWD { get; set; }
    }
}