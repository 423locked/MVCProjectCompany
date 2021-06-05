using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProjectCompany.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase() => DateAdded = DateTime.UtcNow;


        [Required]
        public Guid Id { get; set; }


        [Display(Name = "The title")]
        public virtual string Title { get; set; }

        [Display(Name = "Short text")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Full text")]
        public virtual string Text { get; set; }

        [Display(Name = "Title image path")]
        public virtual string TitleImagePath { get; set; }



        [Display(Name = "Metatag Title")]
        public virtual string MetaTitle { get; set; }

        [Display(Name = "Metatag Description")]
        public virtual string MetaDescription { get; set; }

        [Display(Name = "Metatag Keywords")]
        public virtual string MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}
