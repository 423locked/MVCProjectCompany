using MVCProjectCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProjectCompany.Service
{
    public class ServiceItem : EntityBase
    {
        [Required(ErrorMessage = "Please enter the service title.")]
        [Display(Name = "Service name, title")]
        public override string Title { get; set; }

        [Display(Name = "Short service desription.")]
        public override string Subtitle { get; set; }

        [Display(Name = "Detailed description of the service.")]
        public override string Text { get; set; }
    }
}
