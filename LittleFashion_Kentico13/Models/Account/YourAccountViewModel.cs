using Kentico.Membership;

namespace LittleFashion_Kentico13.Models
{
    public class YourAccountViewModel
    {
        public ApplicationUser User { get; set; }

        public bool AvatarUpdateFailed { get; set; }
    }
}