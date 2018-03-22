namespace MasterProject.Core.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class Roles : IdentityRole
    {
        public int RoleId { get; set; }
    }
}
