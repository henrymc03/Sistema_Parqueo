using SmartParkingCR_Backend.Models;

namespace Proyecto1_Lenguajes.Models.Domain
{
    public class Vehicle_User
    {
        private User user;
        private Vehicle vehicle;

        public Vehicle_User()
        {
        }

        public Vehicle_User(User user, Vehicle vehicle)
        {
            this.user = user;
            this.vehicle = vehicle;
        }

        public User User { get => user; set => user = value; }
        public Vehicle Vehicle { get => vehicle; set => vehicle = value; }
    }
}
