namespace MasterProject.Core.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class Users : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDataComplete { get; set; }
    }
}
