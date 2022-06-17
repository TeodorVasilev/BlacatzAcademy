using MyMobile.DAL.Models.Identity;

namespace MyMobile.DAL.Models.ViewModels.Administration
{
    public class ListRolesViewModel
    {
        public ListRolesViewModel()
        {
            this.Roles = new List<AppRole>();
        }

        public ICollection<AppRole> Roles { get; set; } //ICOLLECTION<rOLEVIEWMODEL>
    }
}
