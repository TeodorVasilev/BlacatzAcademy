using MyMobile.DAL.Models.Identity;

namespace MyMobile.DAL.Models.ViewModels.Administration
{
    public class ListUsersViewModel
    {
        public ListUsersViewModel()
        {
            this.Users = new List<UserViewModel>();
        }
        public List<UserViewModel> Users { get; set; }
    }
}
