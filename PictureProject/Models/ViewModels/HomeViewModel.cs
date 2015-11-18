using System;
using System.Collections.Generic;
using System.Linq;

namespace PictureProject.Models.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }

        public ICollection<InstagramImage> Images { get; set; }

        public bool HasImages
        {
            get
            {
                return Images.Any();
            }
        }
    }
}