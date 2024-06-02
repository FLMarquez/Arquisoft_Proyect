using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cervantes.Arquisoft.View.Models
{
    public class CreateUserViewModel : UserViewModel
    {
        public IEnumerable<SelectListItem> UserRoleList { get; set; }
    }
}
