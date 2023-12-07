
using Proyecto1_Lenguajes.Models.Domain;
using SmartParkingCR_Backend.Models;
using System.Data.SqlClient;

namespace Proyecto1_Lenguajes.Models.Data
{
    public class RateDAO
    {
        private readonly IConfiguration _configuration;
        string connectionString;

        public RateDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }


        public List<Rate> Get()
        {

            List<Rate> rates = new List<Rate>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetRate", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    rates.Add(new Rate
                    {
                        IdRate = Convert.ToInt32(sqlDataReader["Id"]),
                        Type = new VehicleType(0, sqlDataReader["Type"].ToString()),
                        RateType = new RateType(0, sqlDataReader["BookingTime"].ToString(), (float)Convert.ToDouble(sqlDataReader["Amount"]))
                    });

                }
                connection.Close();
            }

            return rates;
        }

        public int Insert(Rate rate) 
        {
            int resultToReturn = 0;
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertRate", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdType", rate.Type.IdType);
                    command.Parameters.AddWithValue("@IdRateType", rate.RateType.IdRateType);

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

        public Rate GetById(int id)
        {
            Rate rate = new Rate();
            Exception? exception = new Exception();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetRateById", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Rate", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    if (sqlDataReader.Read())
                    {
                        rate.IdRate = Convert.ToInt32(sqlDataReader.GetInt32(0));
                        rate.Type = new VehicleType(Convert.ToInt32(sqlDataReader.GetInt32(1)), null);
                        rate.RateType = new RateType(Convert.ToInt32(sqlDataReader.GetInt32(2)), null, 0);

                    }
                    connection.Close();

                    return rate;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }

        public int Update(Rate rate)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateRate", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id_Rate", rate.IdRate);
                    command.Parameters.AddWithValue("@IdType", rate.Type.IdType);
                    command.Parameters.AddWithValue("@IdRateType", rate.RateType.IdRateType);

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


        public Rate Delete(int id)
        {
            Rate rate = new Rate();
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DeleteRate", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Rate", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();


                    if (sqlDataReader.Read())
                    {
                        rate.IdRate = Convert.ToInt32(sqlDataReader.GetInt32(0));
                        rate.Type = new VehicleType(Convert.ToInt32(sqlDataReader.GetInt32(1)), null);
                        rate.RateType = new RateType(Convert.ToInt32(sqlDataReader.GetInt32(2)), null, 0);
                    }

                    connection.Close();

                    return rate;
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
