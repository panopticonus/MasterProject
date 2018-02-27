namespace MasterProject.Core.Models
{
    using System.ComponentModel;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class Users : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DefaultValue(true)]
        public bool IsDisabled { get; set; }
    }
}
