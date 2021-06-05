using Microsoft.EntityFrameworkCore;
using MVCProjectCompany.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProjectCompany.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository
    {
        private readonly AppDbContext context;
        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get a particular text field by its ID.
        /// </summary>
        /// <param name="id">Guid unique id</param>
        /// <returns>TextField instance</returns>
        public IQueryable<TextField> GetTextFields()
        {
            return context.TextFields;
        }

        /// <summary>
        /// Get a particular text field by its ID.
        /// </summary>
        /// <param name="id">Guid unique id</param>
        /// <returns>TextField instance</returns>
        public TextField GetTextFieldById(Guid id)
        {
            return context.TextFields.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Get a particular text field by its codeword.
        /// </summary>
        /// <param name="codeWord">Text codeword - short description of a text field.</param>
        /// <returns>TextField instance</returns>
        public TextField GetTextFieldByCodeWord(string codeWord)
        {
            return context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        /// <summary>
        /// Create/Update a text field.
        /// </summary>
        /// <param name="service">TextField instance</param>
        public void SaveTextField(TextField field)
        {
            if (field.Id == default) //new entity
                context.Entry(field).State = EntityState.Added;
            else
                context.Entry(field).State = EntityState.Modified;

            context.SaveChanges();
        }

        /// <summary>
        /// Delete a particular text field item by its ID.
        /// </summary>
        /// <param name="id">Guid unique id</param>
        public void DeleteTextField(Guid id)
        {
            context.TextFields.Remove(new TextField() { Id = id });
            context.SaveChanges();
        }
    }
}
