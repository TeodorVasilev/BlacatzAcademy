namespace MyMobile.DAL.Models.ViewModels.Administration
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            this.Users = new List<string>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
