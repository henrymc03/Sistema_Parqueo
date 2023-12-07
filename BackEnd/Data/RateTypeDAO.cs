using Proyecto1_Lenguajes.Models.Domain;
using SmartParkingCR_Backend.Models;
using System.Data.SqlClient;

namespace Proyecto1_Lenguajes.Models.Data
{
    public class RateTypeDAO
    {
        private readonly IConfiguration _configuration;
        string connectionString;

        public RateTypeDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public int Insert(RateType rateType)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertRateType", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Booking_Time", rateType.BookingTime);
                    command.Parameters.AddWithValue("@Amount", rateType.Amount);

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


        public RateType Get(string bookingTime)
        {
            RateType rateType = new RateType();
            Exception? exception = new Exception();
  
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetRateType", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Booking_Time", bookingTime);

                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    if (sqlDataReader.Read())
                    {
                        rateType.IdRateType = Convert.ToInt32(sqlDataReader.GetInt32(0));
                        rateType.BookingTime = sqlDataReader.GetString(1);
                        rateType.Amount = (float)Convert.ToDouble(sqlDataReader["Amount"].ToString());
                    }
                    connection.Close();

                    return rateType;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }



        public RateType GetById(int id)
        {
            RateType rateType = new RateType();
            Exception? exception = new Exception();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetByIdRate", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    if (sqlDataReader.Read())
                    {
                        rateType.IdRateType = Convert.ToInt32(sqlDataReader.GetInt32(0));
                        rateType.BookingTime = sqlDataReader.GetString(1);
                        rateType.Amount = (float)Convert.ToDouble(sqlDataReader["Amount"].ToString());
                    }
                    connection.Close();

                    return rateType;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }

        public List<RateType> Get()
        {
            List<RateType> rateType = new List<RateType>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllRateTypes", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    rateType.Add(new RateType
                    {
                        IdRateType = Convert.ToInt32(sqlDataReader["Id"]),
                        BookingTime = sqlDataReader["BookingTime"].ToString(),
                        Amount = (float)Convert.ToDouble(sqlDataReader["Amount"].ToString())
                    });
                }
                connection.Close();
                return rateType;
            }
        }

        public int Update(RateType rateType)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateRateType", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id_RateType", rateType.IdRateType);
                    command.Parameters.AddWithValue("@Booking_Time", rateType.BookingTime);
                    command.Parameters.AddWithValue("@Amount", rateType.Amount);

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


        public RateType Delete(string bookingTime)
        {
            RateType rateType = new RateType();
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("[DeleteRateType]", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Booking_Time", bookingTime);

                    SqlDataReader sqlDataReader = command.ExecuteReader();


                    if (sqlDataReader.Read())
                    {
                        rateType.IdRateType = Convert.ToInt32(sqlDataReader.GetInt32(0));
                        rateType.BookingTime = sqlDataReader.GetString(1);
                        rateType.Amount = (float)Convert.ToDouble(sqlDataReader["Amount"].ToString());
                    }

                    connection.Close();

                    return rateType;
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
