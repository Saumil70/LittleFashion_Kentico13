using System.Collections.Generic;

namespace LittleFashion_Kentico13.ViewModel
{
    public class ContactInfoViewModel
    {
        public string Title { get; set; }
        public string ButtonText { get; set; }
        public string ButtonLink { get; set; }
        public string Description { get; set; }
        public List<SocialLinkViewModel> SocialLinks { get; set; }
    }

    public class SocialLinkViewModel
    {
        public string SocialLinkText { get; set; }
        public string SocialLink { get; set; }
    }
}
