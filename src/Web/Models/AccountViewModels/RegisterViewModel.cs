using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.DomainModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("名字格式")]
        public bool NameStyle { get; set; }
        [Required]
        [Display(Name = "姓")]
        public string FirstName { get; set; }
        [Display(Name = "MiddleName")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "名")]
        public string LastName { get; set; }
        [Display(Name = "礼貌称呼")]
        public string Title { get; set; }
        [Display(Name = "名字后缀")]
        public string Suffix { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "邮件")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string PersonType { get; set; }
        public int EmailPromotion { get; set; }

        [Display(Name = "行动电话")]
        public string PhoneNumber { get; set; }
        [Display(Name = "人员类型")]
        public IEnumerable<SelectListItem> PersonTypes { get; set; }
        [Display(Name = "邮件设定")]
        public IEnumerable<SelectListItem> EmailPromotions { get; set; }
    }
}
