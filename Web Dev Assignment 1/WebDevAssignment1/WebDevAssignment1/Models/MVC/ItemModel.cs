using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDevAssignment1.Models.MVC
{
    public class ItemModel
    {
        [Key]
        int itemID { get; set; }

        [Display(Name = "Item Name")]
        string itemName { get; set; }

        [Display(Name = "Image Url")]
        string itemImageUrl { get; set; }

        [Display(Name = "Short Description")]
        string itemShortDesc { get; set; }



    }
}