using Proyecto1_Lenguajes.Models.Domain;
using SmartParkingCR_Backend.Models;
using System.Data.SqlClient;

namespace Proyecto1_Lenguajes.Models.Data
{
    public class VehicleUserDAO
    {
        private readonly IConfiguration _configuration;
        string connectionString;

        public VehicleUserDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }


        public List<Vehicle_User> GetByUserId(int id)
        {
            List<Vehicle_User> vehicle_user = new List<Vehicle_User>();

            Exception? exception = new Exception();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetUserVehicles", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_User", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    while (sqlDataReader.Read())
                    {

                        vehicle_user.Add(new Vehicle_User
                        {
                            User = new User(0,null, sqlDataReader["Name"].ToString(), sqlDataReader["LastName"].ToString(),
                            sqlDataReader["Tel_Number"].ToString(), sqlDataReader["Email"].ToString(), null, null),
                            Vehicle = new Vehicle(Convert.ToInt32(sqlDataReader.GetInt32(1)), sqlDataReader["LicensePlate"].ToString(), null, 0, null, null)
                        });
                    }
                    connection.Close();
                    return vehicle_user;
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
