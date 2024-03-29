﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNUiMap.pages.Announcement_List
{

    public class AnnouncementListFlyoutMenuItem
    {
        public AnnouncementListFlyoutMenuItem()
        {
            TargetType = typeof(AnnouncementListFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
        public string IconSource { get; set; }
    }
}