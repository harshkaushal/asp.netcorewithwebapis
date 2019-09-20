using Microsoft.AspNetCore.Identity;

namespace GHMS.DataModel.Models.Common
{
   //  public class ApplicationUserRole : IdentityUserRole { }

    public class ApplicationRole : IdentityRole {
        public ApplicationRole() : base()
        { }
        public ApplicationRole(string roleName) : base(roleName)
        {
        }
    }

    //public class ApplicationUserClaim : IdentityUserClaim<string> { }

    //public class ApplicationUserLogin : IdentityUserLogin<string> { }

    public class ApplicationUser  : IdentityUser// IdentityUser<Guid>
    {
        public bool IsPasswordChanged { get; set; }
    }
     
}
