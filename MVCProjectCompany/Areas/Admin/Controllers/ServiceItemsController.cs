using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCProjectCompany.Domain;
using MVCProjectCompany.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProjectCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceItemsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public ServiceItemsController(DataManager data, IWebHostEnvironment env)
        {
            this.dataManager = data;
            this.hostingEnvironment = env;
        }

        
        public IActionResult Edit(Guid id)
        {
            ServiceItem service = id == default ? new ServiceItem() : dataManager.ServiceItems.GetServiceItemById(id);
            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ServiceItem model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    string path = "/images/" + titleImageFile.FileName;
                    using (var fileStream = new FileStream(hostingEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await titleImageFile.CopyToAsync(fileStream);
                    }
                }
                dataManager.ServiceItems.SaveServiceItem(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.ServiceItems.DeleteServiceItem(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
