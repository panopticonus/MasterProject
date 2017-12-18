namespace MasterProject.DAL.Model
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }
        public AppRole(string name) : base(name) { }
    }
}
