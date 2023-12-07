namespace SmartParkingCR_Backend.Models
{
    public class TicketDTO
    {
        private int idTicket;
        private int parkingLot;
        private int spot;
        private int user;
        private int rateType;
        private string starDay;
        private string endDay;

        public TicketDTO()
        {
      
        }

        public TicketDTO(int idTicket, int parkingLot, int spot, int user, int rateType, string starDay, string endDay)
        {
            this.idTicket = idTicket;
            this.parkingLot = parkingLot;
            this.spot = spot;
            this.user = user;
            this.rateType = rateType;
            this.starDay = starDay;
            this.endDay = endDay;
        }

        public int ParkingLot { get => parkingLot; set => parkingLot = value; }
        public int Spot { get => spot; set => spot = value; }
        public int User { get => user; set => user = value; }
        public int RateType { get => rateType; set => rateType = value; }
        public string StarDay { get => starDay; set => starDay = value; }
        public string EndDay { get => endDay; set => endDay = value; }
    }
}
