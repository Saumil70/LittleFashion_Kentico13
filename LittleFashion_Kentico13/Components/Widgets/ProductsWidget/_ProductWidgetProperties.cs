using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;

namespace LittleFashion_Kentico13.Components.Widgets.ProductWidget
{
    public class _ProductWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Product Name", Order = 1)]
        public string ProductName { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Product Description", Order = 2)]
        public string ProductDescription { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Product Price", Order = 4)]
        public string ProductPrice { get; set; }

        [EditingComponent(UrlSelector.IDENTIFIER, Label = "Product Url", Order = 5)]
        public string ProductUrl { get; set; }

        [EditingComponent(MediaFilesSelector.IDENTIFIER, Label = "Background Image", Order = 6)]
        public IEnumerable<MediaFilesSelectorItem> ImageUrl { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Product Status", Order = 7)]
        public string ProductStatus { get; set; }
    }
}
