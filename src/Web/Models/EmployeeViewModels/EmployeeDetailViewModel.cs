using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.EmployeeViewModels
{
    public class EmployeeDetailViewModel
    {
        [Display(Name = "编号")]
        public int BusinessEntityID { get; set; }
        public string NationalIDNumber { get; set; }
        public string LoginID { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
    }
}
