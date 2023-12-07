

using Proyecto1_Lenguajes.Models.Domain;
using SmartParkingCR_Backend.Models;
using System.Data.SqlClient;

namespace ParkingSystemProject.Models.Data
{
    public class SpotDAO
    {
        private readonly IConfiguration _configuration;
        string connectionString;

        public SpotDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");

        }


        public int Insert(Spot spot)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertSpot", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Number", spot.Number);
                    command.Parameters.AddWithValue("@Type", spot.Type);
                    command.Parameters.AddWithValue("@Status", spot.Status);
                    command.Parameters.AddWithValue("@Id_ParkingLot", spot.ParkingLot.IdParkingLot);

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

        public List<Spot> Get()
        {

            List<Spot> spots = new List<Spot>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("GetAllSpots", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    spots.Add(new Spot
                    {
                        Id= Convert.ToInt32(sqlDataReader["IdSpot"]),
                        Number = Convert.ToInt32(sqlDataReader["Number"]),
                        Type = sqlDataReader["Type"].ToString(),
                        Status = sqlDataReader["Status"].ToString(),
                        Vehicle = new Vehicle(Convert.ToInt32(sqlDataReader["Id_Vehicle"]), sqlDataReader["LicensePlate"].ToString(), "",0,"",new VehicleType()),
                        ParkingLot = new ParkingLot(Convert.ToInt32(sqlDataReader["Id_ParkingLot"]), sqlDataReader["Name"].ToString(), 0,"","","")

                    });

                }

                connection.Close();

                return spots;

            }
        }

        public Spot Get(string id)
        {
            Spot spot = new Spot();
            int idSpot = Convert.ToInt32(id);
            Exception? exception = new Exception();
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("GetSpot", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", idSpot);

                    SqlDataReader sqlDataReader = command.ExecuteReader();


                    if (sqlDataReader.Read())
                    {
                        spot.Id = idSpot;
                        spot.Number = Convert.ToInt32(sqlDataReader.GetInt32(0));
                        spot.Type = sqlDataReader.GetString(1);
                        spot.Status = sqlDataReader.GetString(2);
                        spot.Vehicle = new Vehicle(Convert.ToInt32(sqlDataReader.GetInt32(3)),sqlDataReader.GetString(4), "", 0, "", new VehicleType());
                        spot.ParkingLot = new ParkingLot(Convert.ToInt32(sqlDataReader.GetInt32(5)), sqlDataReader.GetString(6), 0, "", "", "");
                    }

                    connection.Close();


                    return spot;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }
        public List<Spot> GetByParkingLot(int id)
        {
            List<Spot> spots = new List<Spot>();
            Exception? exception = new Exception();
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("GetSpotsByParkingLot", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_ParkingLot", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    while (sqlDataReader.Read())
                    {

                        spots.Add(new Spot
                        {
                            Id = Convert.ToInt32(sqlDataReader["IdSpot"]),
                            Number = Convert.ToInt32(sqlDataReader["Number"]),
                            Type = sqlDataReader["Type"].ToString(),
                            Status = sqlDataReader["Status"].ToString(),
                            Vehicle = new Vehicle(Convert.ToInt32(sqlDataReader["Id_Vehicle"]), sqlDataReader["LicensePlate"].ToString(), "", 0, "", new VehicleType()),
                            ParkingLot = new ParkingLot(0, null, 0, "", "", "")

                        });

                    }

                    connection.Close();


                    
                }
                return spots;
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }


        public int Update(Spot spot)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            int result;
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateSpot", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdSpot", spot.Id);
                    command.Parameters.AddWithValue("@Status", spot.Status);
                    command.Parameters.AddWithValue("@Type", spot.Type);
                    command.Parameters.AddWithValue("@licensePlate", spot.Vehicle.LicensePlate);
                    //var datareturn = command.Parameters["@result"].Value;
                    //resultToReturn = Convert.ToInt32(datareturn);
                    resultToReturn = command.ExecuteNonQuery();



                    //result = command.ExecuteNonQuery();
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

        public int Delete(int id)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("DeleteSpot", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", id);
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
