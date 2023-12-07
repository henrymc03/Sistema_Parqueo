namespace Proyecto1_Lenguajes.Models.Domain
{
    public class UsersPerRole
    {
        private string roleType;
        private int users;

        public UsersPerRole()
        {
        }

        public UsersPerRole(string role, int users)
        {
            this.roleType = role;
            this.users = users;
        }

        public string RoleType { get => roleType; set => roleType = value; }
        public int Users { get => users; set => users = value; }
    }
}
