
using SmartParkingCR_Backend.Models;
using System.Data.SqlClient;

namespace Proyecto1_Lenguajes.Models.Data
{
    public class ParkingDAO
    {
        private readonly IConfiguration _configuration;
        string connectionString;
        private readonly DbSmartParkingContext _context;
        public ParkingDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public ParkingDAO(DbSmartParkingContext context)
        {
            _context = context;
        }

        public ParkingDAO()
        {
        }

        public ParkingLot Get(string name)
        {
            ParkingLot parking = new ParkingLot();
            Exception? exception = new Exception();
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetParking", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", name);

                    SqlDataReader sqlDataReader = command.ExecuteReader();


                    if (sqlDataReader.Read())
                    {
                        parking.IdParkingLot = Convert.ToInt32(sqlDataReader.GetInt32(0));
                        parking.Name = sqlDataReader.GetString(1);
                        parking.CapacitySize = Convert.ToInt32(sqlDataReader.GetInt32(2));
                        parking.Province = sqlDataReader.GetString(3);
                        parking.City = sqlDataReader.GetString(4);
                        parking.District = sqlDataReader.GetString(5);
                    }

                    connection.Close();


                    return parking;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }


        public int Insert(ParkingLot parking)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertParking", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", parking.Name);
                    command.Parameters.AddWithValue("@capacity", parking.CapacitySize);
                    command.Parameters.AddWithValue("@province", parking.Province);
                    command.Parameters.AddWithValue("@city", parking.City);
                    command.Parameters.AddWithValue("@district", parking.District);
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

        public List<ParkingLot> Get()
        {

            List<ParkingLot> parkingLots = new List<ParkingLot>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("getAllParking", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    parkingLots.Add(new ParkingLot
                    {
                        IdParkingLot = Convert.ToInt32(sqlDataReader["Id_ParkingLot"]),
                        Name = sqlDataReader["Name"].ToString(),
                        CapacitySize  = Convert.ToInt32(sqlDataReader["CapacitySize"]),
                        Province = sqlDataReader["Province"].ToString(),
                        City = sqlDataReader["City"].ToString(),
                        District = sqlDataReader["District"].ToString()

                    });

                }

                connection.Close();

                return parkingLots;

            }
        }

        public ParkingLot GetNameParking(int id)
        {
            ParkingLot parking = new ParkingLot();
            Exception? exception = new Exception();
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetParking2", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();


                    if (sqlDataReader.Read())
                    {
                        parking.IdParkingLot = Convert.ToInt32(sqlDataReader.GetInt32(0));
                        parking.Name = sqlDataReader.GetString(1);
                        parking.CapacitySize = Convert.ToInt32(sqlDataReader.GetInt32(2));
                        parking.Province = sqlDataReader.GetString(3);
                        parking.City = sqlDataReader.GetString(4);
                        parking.District = sqlDataReader.GetString(5);
                    }

                    connection.Close();


                    return parking;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }


        public List<ParkingLot> GetCartago()
        {

            List<ParkingLot> parkingLots = new List<ParkingLot>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("getParkingCartago", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    parkingLots.Add(new ParkingLot
                    {
                        IdParkingLot = Convert.ToInt32(sqlDataReader["Id_ParkingLot"]),
                        Name = sqlDataReader["Name"].ToString(),
                        CapacitySize = Convert.ToInt32(sqlDataReader["CapacitySize"]),
                        Province = sqlDataReader["Province"].ToString(),
                        City = sqlDataReader["City"].ToString(),
                        District = sqlDataReader["District"].ToString()

                    });

                }

                connection.Close();

                return parkingLots;

            }
        }

        public List<ParkingLot> GetSanJose()
        {

            List<ParkingLot> parkingLots = new List<ParkingLot>();
            using (SqlConnection connection = new SqlConnection(connectionString))

            {

                connection.Open();
                SqlCommand command = new SqlCommand("getParkingSanJose", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    parkingLots.Add(new ParkingLot
                    {
                        IdParkingLot = Convert.ToInt32(sqlDataReader["Id_ParkingLot"]),
                        Name = sqlDataReader["Name"].ToString(),
                        CapacitySize = Convert.ToInt32(sqlDataReader["CapacitySize"]),
                        Province = sqlDataReader["Province"].ToString(),
                        City = sqlDataReader["City"].ToString(),
                        District = sqlDataReader["District"].ToString()

                    });

                }

                connection.Close();

                return parkingLots;

            }
        }

        public List<ParkingLot> GetHeredia()
        {

            List<ParkingLot> parkingLots = new List<ParkingLot>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("getParkingHeredia", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    parkingLots.Add(new ParkingLot
                    {
                        IdParkingLot = Convert.ToInt32(sqlDataReader["Id_ParkingLot"]),
                        Name = sqlDataReader["Name"].ToString(),
                        CapacitySize = Convert.ToInt32(sqlDataReader["CapacitySize"]),
                        Province = sqlDataReader["Province"].ToString(),
                        City = sqlDataReader["City"].ToString(),
                        District = sqlDataReader["District"].ToString()

                    });

                }

                connection.Close();

                return parkingLots;

            }
        }

        public List<ParkingLot> GetAlajuela()
        {

            List<ParkingLot> parkingLots = new List<ParkingLot>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("getParkingAlajuela", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    parkingLots.Add(new ParkingLot
                    {
                        IdParkingLot = Convert.ToInt32(sqlDataReader["Id_ParkingLot"]),
                        Name = sqlDataReader["Name"].ToString(),
                        CapacitySize = Convert.ToInt32(sqlDataReader["CapacitySize"]),
                        Province = sqlDataReader["Province"].ToString(),
                        City = sqlDataReader["City"].ToString(),
                        District = sqlDataReader["District"].ToString()

                    });

                }

                connection.Close();

                return parkingLots;

            }
        }

        public List<ParkingLot> GetPuntarenas()
        {

            List<ParkingLot> parkingLots = new List<ParkingLot>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("getParkingPuntarenas", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    parkingLots.Add(new ParkingLot
                    {
                        IdParkingLot = Convert.ToInt32(sqlDataReader["Id_ParkingLot"]),
                        Name = sqlDataReader["Name"].ToString(),
                        CapacitySize = Convert.ToInt32(sqlDataReader["CapacitySize"]),
                        Province = sqlDataReader["Province"].ToString(),
                        City = sqlDataReader["City"].ToString(),
                        District = sqlDataReader["District"].ToString()

                    });

                }

                connection.Close();

                return parkingLots;

            }
        }


        public List<ParkingLot> GetLimon()
        {

            List<ParkingLot> parkingLots = new List<ParkingLot>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("getParkingLimon", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    parkingLots.Add(new ParkingLot
                    {
                        IdParkingLot = Convert.ToInt32(sqlDataReader["Id_ParkingLot"]),
                        Name = sqlDataReader["Name"].ToString(),
                        CapacitySize = Convert.ToInt32(sqlDataReader["CapacitySize"]),
                        Province = sqlDataReader["Province"].ToString(),
                        City = sqlDataReader["City"].ToString(),
                        District = sqlDataReader["District"].ToString()

                    });

                }

                connection.Close();

                return parkingLots;

            }
        }

        public List<ParkingLot> GetGuanacaste()
        {

            List<ParkingLot> parkingLots = new List<ParkingLot>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("getParkingGuanacaste", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    parkingLots.Add(new ParkingLot
                    {
                        IdParkingLot = Convert.ToInt32(sqlDataReader["Id_ParkingLot"]),
                        Name = sqlDataReader["Name"].ToString(),
                        CapacitySize = Convert.ToInt32(sqlDataReader["CapacitySize"]),
                        Province = sqlDataReader["Province"].ToString(),
                        City = sqlDataReader["City"].ToString(),
                        District = sqlDataReader["District"].ToString()

                    });

                }

                connection.Close();

                return parkingLots;

            }
        }


        public int Update(ParkingLot parking)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateParking", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@idParking", parking.IdParkingLot);
                    command.Parameters.AddWithValue("@name", parking.Name);
                    command.Parameters.AddWithValue("@capacity", parking.CapacitySize);
                    command.Parameters.AddWithValue("@province", parking.Province);
                    command.Parameters.AddWithValue("@city", parking.City);
                    command.Parameters.AddWithValue("@district", parking.District);
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

    

        public ParkingLot Delete(int parking)
        {
            ParkingLot parkingLots = new ParkingLot();
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("DeleteParking", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", parking);
                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    if (sqlDataReader.Read())
                    {
                        parkingLots.IdParkingLot = Convert.ToInt32(sqlDataReader.GetInt32(0));
                        parkingLots.Name = sqlDataReader.GetString(1);
                        parkingLots.CapacitySize = Convert.ToInt32(sqlDataReader.GetInt32(2));
                        parkingLots.Province = sqlDataReader.GetString(3);
                        parkingLots.City = sqlDataReader.GetString(4);
                        parkingLots.District = sqlDataReader.GetString(5);
                    }

                    connection.Close();

                    return parkingLots;

                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }


            
        }


    }
}
