using ParkingSystemProject.Models;
using ParkingSystemProject.Models.Data;
using Proyecto1_Lenguajes.Models.Domain;
using Proyecto1_Lenguajes.Models.Utility;
using SmartParkingCR_Backend.Models;
using System.Data.SqlClient;
using System.Globalization;

namespace Proyecto1_Lenguajes.Models.Data
{
    public class TicketDAO
    {
        private readonly IConfiguration _configuration;
        string connectionString;


        public TicketDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public int Insert(TicketDTO ticket)
        {
            PDF pdf = new PDF();
          
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            ParkingDAO parkingDAO = new ParkingDAO(_configuration);
            SpotDAO spotDAO = new SpotDAO(_configuration);
            UserDAO userDAO = new UserDAO(_configuration);
            RateTypeDAO rateTypeDAO = new RateTypeDAO(_configuration);
            SendMails sendMails = new SendMails();

            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertTicket", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ParkingLotId", ticket.ParkingLot);
                    command.Parameters.AddWithValue("@SpotId", ticket.Spot);
                    command.Parameters.AddWithValue("@UserId", ticket.User);
                    command.Parameters.AddWithValue("@RateTypeId", ticket.RateType);
                    command.Parameters.AddWithValue("@StarDay", ticket.StarDay);
                    command.Parameters.AddWithValue("@EndDay", ticket.EndDay);

                    resultToReturn = command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
            return resultToReturn;
        }

        public Ticket Get(int spotId, string startDay)
        {
            Ticket ticket = new Ticket();
            Exception? exception = new Exception();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetTicket", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SpotId", spotId);
                    command.Parameters.AddWithValue("@StarDay", startDay);

                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    if (sqlDataReader.Read())
                    {
                        ticket.IdTicket = Convert.ToInt32(sqlDataReader.GetInt32(0));
                        ticket.ParkingLot = new ParkingLot(Convert.ToInt32(sqlDataReader.GetInt32(1)), null, 0, null, null, null);
                        ticket.Spot = new Spot(Convert.ToInt32(sqlDataReader.GetInt32(2)), 0, null, null, null, null);
                        ticket.User = new User(Convert.ToInt32(sqlDataReader.GetInt32(3)), null, null, null, null, null, null, null);
                        ticket.RateType = new RateType(Convert.ToInt32(sqlDataReader.GetInt32(4)), null, 0);
                        ticket.StarDay = sqlDataReader.GetString(5).ToString();
                        ticket.EndDay = sqlDataReader.GetString(6).ToString();
                    }
                    connection.Close();

                    return ticket;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }


        public List<Ticket> GetByUserId(int idUser)
        {
            List<Ticket> tickets = new List<Ticket>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetUserReservations", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdUser", idUser);

                SqlDataReader sqlDataReader = command.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    tickets.Add(new Ticket
                    {
                        IdTicket = Convert.ToInt32(sqlDataReader["IdTicket"]),
                        ParkingLot = new ParkingLot(Convert.ToInt32(sqlDataReader["ParkingLotId"]), sqlDataReader["ParkingName"].ToString(), 0, null, null, null),
                        Spot = new Spot(Convert.ToInt32(sqlDataReader["SpotId"]), Convert.ToInt32(sqlDataReader["SpotNumber"]), null, null, null, null),
                        User = new User(Convert.ToInt32(sqlDataReader["UserId"]), null, sqlDataReader["UserName"].ToString(), null, null, null, null, null),
                        RateType = new RateType(Convert.ToInt32(sqlDataReader["RateTypeId"]), null, (float)Convert.ToDouble(sqlDataReader["Amount"])),
                        StarDay = sqlDataReader["StartDay"].ToString(),
                        EndDay = sqlDataReader["EndDay"].ToString()
                    });
                }
                connection.Close();
                return tickets;
            }
        }



        public List<Ticket> GetAll()
        {
            List<Ticket> tickets = new List<Ticket>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetTicketAll", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
       

                SqlDataReader sqlDataReader = command.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    tickets.Add(new Ticket
                    {
                        IdTicket = Convert.ToInt32(sqlDataReader["IdTicket"]),
                        ParkingLot = new ParkingLot(Convert.ToInt32(sqlDataReader["ParkingLotId"]), sqlDataReader["ParkingName"].ToString(), 0, null, null, null),
                        Spot = new Spot(Convert.ToInt32(sqlDataReader["SpotId"]), Convert.ToInt32(sqlDataReader["SpotNumber"]), null, null, null, null),
                        User = new User(Convert.ToInt32(sqlDataReader["UserId"]), null, sqlDataReader["UserName"].ToString(), null, null, null, null, null),
                        RateType = new RateType(Convert.ToInt32(sqlDataReader["RateTypeId"]), null, (float)Convert.ToDouble(sqlDataReader["Amount"])),
                        StarDay = sqlDataReader["StartDay"].ToString(),
                        EndDay = sqlDataReader["EndDay"].ToString()
                    });
                }
                connection.Close();
                return tickets;
            }
        }


        public Ticket GetById(int id)
        {
            Ticket tickets = new Ticket();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetTicketById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader sqlDataReader = command.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    tickets.IdTicket = Convert.ToInt32(sqlDataReader["IdTicket"]);
                    tickets.ParkingLot = new ParkingLot(Convert.ToInt32(sqlDataReader["ParkingLotId"]), sqlDataReader["ParkingName"].ToString(), 0, null, null, null);
                    tickets.Spot = new Spot(Convert.ToInt32(sqlDataReader["SpotId"]), Convert.ToInt32(sqlDataReader["SpotNumber"]), null, null, null, null);
                    tickets.User = new User(Convert.ToInt32(sqlDataReader["UserId"]), null, sqlDataReader["UserName"].ToString(), null, null, null, null, null);
                    tickets.RateType = new RateType(Convert.ToInt32(sqlDataReader["RateTypeId"]), null, (float)Convert.ToDouble(sqlDataReader["Amount"]));
                    tickets.StarDay = sqlDataReader["StartDay"].ToString();
                    tickets.EndDay = sqlDataReader["EndDay"].ToString();
                }
                connection.Close();
                return tickets;
            }
        }


        public int Update(Ticket ticket)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateTicket", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@id", ticket.IdTicket);
                    command.Parameters.AddWithValue("@date_upd", ticket.StarDay);

                    resultToReturn = command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
            return resultToReturn;
        }

    }

}

