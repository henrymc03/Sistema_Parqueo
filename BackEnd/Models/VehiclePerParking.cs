namespace Proyecto1_Lenguajes.Models.Domain
{
    public class VehiclePerParking
    {

        private string nameParkingLot;
        private int vehiclesQuantity;

        public VehiclePerParking()
        {
        }

        public VehiclePerParking(string nameParkingLot, int vehiclesQuantity)
        {
            this.NameParkingLot = nameParkingLot;
            this.VehiclesQuantity = vehiclesQuantity;
        }

        public string NameParkingLot { get => nameParkingLot; set => nameParkingLot = value; }
        public int VehiclesQuantity { get => vehiclesQuantity; set => vehiclesQuantity = value; }

    }
}
