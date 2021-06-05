using MVCProjectCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProjectCompany.Service
{
    public class TextField : EntityBase
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Page name, title")]
        public override string Title { get; set; } = "Info page";

        [Display(Name = "Page contents")]
        public override string Text { get; set; } = "The contents of the page are filled by the admin.";
    }
}
