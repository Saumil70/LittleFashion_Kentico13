using CMS.DocumentEngine;
using CMS.DocumentEngine.Routing;
using CMS.DocumentEngine.Types.LittleFashion_Kentico13;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using LittleFashion_Kentico13.ViewModel;
using LittleFashion_Kentico13.ViewModel.Menu;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittleFashion_Kentico13.ViewComponents
{
    public class ContactFormViewComponent : ViewComponent
    {
        private readonly IPageRetriever pageRetriever;
        private readonly IPageUrlRetriever pageUrlRetriever;

        public ContactFormViewComponent(IPageRetriever pageRetriever, IPageUrlRetriever pageUrlRetriever)
        {
            // Initializes instances of required services using dependency injection
            this.pageRetriever = pageRetriever;
            this.pageUrlRetriever = pageUrlRetriever;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var contactFormData = await pageRetriever.RetrieveAsync<ContactForm>(
                query => query
                    .Path("/Contact", PathTypeEnum.Children) // Adjust the path to match your site structure
                    .OnCurrentSite()
                    .TopN(1) // Limit to one item (e.g., the main contact form)
            );
            var form = contactFormData.FirstOrDefault();
                
            ContactFormViewModel model = new ContactFormViewModel()
            {
                FormTitle = form.FormTitle,
                Button = form.Button
            };

            // Pass the data to the view
            return View(model);
        }
    }
}
