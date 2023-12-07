using Proyecto1_Lenguajes.Models.Domain;
using SmartParkingCR_Backend.Models;
using System.Data.SqlClient;
namespace Proyecto1_Lenguajes.Models.Data
{
    public class VehicleDAO
    {
        private readonly IConfiguration _configuration;
        string connectionString;

        public VehicleDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            this.connectionString = _configuration.GetConnectionString("DefaultConnection");
        }


        public int Insert(Vehicle vehicle)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertVehicle", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@LicensePlate", vehicle.LicensePlate);
                    command.Parameters.AddWithValue("@Color", vehicle.Color);
                    command.Parameters.AddWithValue("@Weight", vehicle.Weight);
                    command.Parameters.AddWithValue("@Brand", vehicle.Brand);
                    command.Parameters.AddWithValue("@IdType", vehicle.Type.IdType);
                    command.Parameters.AddWithValue("@EmailUser", vehicle.User.Email);
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

        public List<Vehicle> Get()
        {

            List<Vehicle> vehicles = new List<Vehicle>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("GetAllVehicles", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    vehicles.Add(new Vehicle
                    {
                        IdVehicle = Convert.ToInt32(sqlDataReader["Id"]),
                        LicensePlate = sqlDataReader["LicensePlate"].ToString(),
                        Color = sqlDataReader["Color"].ToString(),
                        Weight = Convert.ToInt32(sqlDataReader["Weight"]),
                        Brand = sqlDataReader["Brand"].ToString(),
                        Type = new VehicleType(0, sqlDataReader["Name"].ToString())

                    }) ;

                }

                connection.Close();

                return vehicles;

            }
        }

        public Vehicle Get(string licensePlate)
        {
            Vehicle vehicle = new Vehicle();
            Exception? exception = new Exception();
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("GetVehicle", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@licensePlate", licensePlate);

                    SqlDataReader sqlDataReader = command.ExecuteReader();


                    if (sqlDataReader.Read())
                    {
                        vehicle.IdVehicle = Convert.ToInt32(sqlDataReader.GetInt32(0));
                        vehicle.LicensePlate = sqlDataReader.GetString(1);
                        vehicle.Weight = Convert.ToInt32(sqlDataReader.GetInt32(2));
                        vehicle.Brand = sqlDataReader.GetString(3);
                        vehicle.Color = sqlDataReader.GetString(4);
                        vehicle.Type = new VehicleType(Convert.ToInt32(sqlDataReader.GetInt32(5)), "");
                    }

                    connection.Close();


                    return vehicle;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }


        public int Update(Vehicle vehicle)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateVehicle", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id_Vehicle", vehicle.IdVehicle);
                    command.Parameters.AddWithValue("@LicensePlate", vehicle.LicensePlate);
                    command.Parameters.AddWithValue("@Weight", vehicle.Weight);
                    command.Parameters.AddWithValue("@Color", vehicle.Color);
                    command.Parameters.AddWithValue("@Brand", vehicle.Brand);
                    command.Parameters.AddWithValue("@IdType", vehicle.Type.IdType);



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

        public int Delete(int id)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("DeleteVehicle", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdVehicle", id);
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
