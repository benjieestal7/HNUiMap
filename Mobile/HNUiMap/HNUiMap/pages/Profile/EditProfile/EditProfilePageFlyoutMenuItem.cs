using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNUiMap.pages.Profile.EditProfile
{

    public class EditProfilePageFlyoutMenuItem
    {
        public EditProfilePageFlyoutMenuItem()
        {
            TargetType = typeof(EditProfilePageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}