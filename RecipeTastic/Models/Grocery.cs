using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace RecipeTastic.Models
{
    public class Grocery
    {
        public int GroceryId { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name ="Grocery Name")]
        public string GroceryName { get; set; }
        [Display(Name ="Grocery Comment")]
        public string GroceryComment { get; set; }
        public string UserId { get; set; } = HttpContext.Current.User.Identity.GetUserName();
    }
}