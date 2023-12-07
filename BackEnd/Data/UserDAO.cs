using Proyecto1_Lenguajes.Models.Domain;
using Proyecto1_Lenguajes.Models.Utility;
using SmartParkingCR_Backend.Models;
using System.Data.SqlClient;

namespace Proyecto1_Lenguajes.Models.Data
{
    public class UserDAO
    {
        private readonly IConfiguration _configuration;
        string connectionString;

        public UserDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public UserDAO()
        {
        }

        public int Insert(User user)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertUser", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Identification", user.Identification);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Tel_Number", user.TelNumber);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Id_Role", user.Role.IdRole);

                    resultToReturn = command.ExecuteNonQuery();
                    connection.Close();
                }
                SendMails mail = new SendMails();
                mail.sendMailsSmartParking("Welcome " + user.Name + " to Smart parking", user.Email, "Thank you for choosing us");
           
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
            return resultToReturn;
        }


        public List<User> Get()
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllUsers", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    users.Add(new User
                    {
                        IdUser = Convert.ToInt32(sqlDataReader["Id"]),
                        Identification = sqlDataReader["Identification"].ToString(),
                        Name = sqlDataReader["Name"].ToString(),
                        LastName = sqlDataReader["LastName"].ToString(),
                        TelNumber = sqlDataReader["Tel_Number"].ToString(),
                        Email = sqlDataReader["Email"].ToString(),
                        Role = new Role(0, sqlDataReader["RoleName"].ToString())
                    });
                }
                connection.Close();
                return users;
            }
        }


        public List<User> GetClientUser()
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetClientUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    users.Add(new User
                    {
                        IdUser = Convert.ToInt32(sqlDataReader["Id"]),
                        Name = sqlDataReader["Name"].ToString(),
                        LastName = sqlDataReader["LastName"].ToString(),
                        TelNumber = sqlDataReader["Tel_Number"].ToString(),
                        Email = sqlDataReader["Email"].ToString(),
                        Role = new Role(0, sqlDataReader["RoleName"].ToString())
                    });
                }
                connection.Close();
                return users;
            }
        }


        public User Get(string email, string password)
        {
            User user = new User();
            Exception? exception = new Exception();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetUser", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    if (sqlDataReader.Read())
                    {
                        user.IdUser = Convert.ToInt32(sqlDataReader.GetInt32(0));
                        user.Identification = sqlDataReader.GetString(1);
                        user.Name = sqlDataReader.GetString(2);
                        user.LastName = sqlDataReader.GetString(3);
                        user.TelNumber = sqlDataReader.GetString(4);
                        user.Email = sqlDataReader.GetString(5);
                        user.Password = sqlDataReader.GetString(6);
                        user.Role = new Role(Convert.ToInt32(sqlDataReader.GetInt32(7)),sqlDataReader.GetString(9));
                    }
                    connection.Close();

                    return user;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }


        public User GetByEmail(string email)
        {
            User user = new User();
            Exception? exception = new Exception();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetUserByEmail", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", email);

                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    if (sqlDataReader.Read())
                    {
                        user.IdUser = Convert.ToInt32(sqlDataReader.GetInt32(0));
                        user.Identification = sqlDataReader.GetString(1);
                        user.Name = sqlDataReader.GetString(2);
                        user.LastName = sqlDataReader.GetString(3);
                        user.TelNumber = sqlDataReader.GetString(4);
                        user.Email = sqlDataReader.GetString(5);
                        user.Role = new Role(Convert.ToInt32(sqlDataReader.GetInt32(7)), null);
                    }
                    connection.Close();

                    return user;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }



        public User getUserById(int id)
        {
            User user = new User();
            Exception? exception = new Exception();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getUserById", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    if (sqlDataReader.Read())
                    {
                        user.IdUser = Convert.ToInt32(sqlDataReader.GetInt32(0));
                        user.Identification = sqlDataReader.GetString(1);
                        user.Name = sqlDataReader.GetString(2);
                        user.LastName = sqlDataReader.GetString(3);
                        user.TelNumber = sqlDataReader.GetString(4);
                        user.Email = sqlDataReader.GetString(5);
                        user.Role = new Role(Convert.ToInt32(sqlDataReader.GetInt32(7)), null);
                    }
                    connection.Close();

                    return user;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }


        public int Update(User user)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateUser", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id_User", user.IdUser);
                    command.Parameters.AddWithValue("@Identification", user.Identification);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Tel_Number", user.TelNumber);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Id_Role", user.Role.IdRole);

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


        public User Delete(string email)
        {
            User user = new User();
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DeleteUser", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", email);

                    SqlDataReader sqlDataReader = command.ExecuteReader();


                    if (sqlDataReader.Read())
                    {
                        user.IdUser = Convert.ToInt32(sqlDataReader.GetInt32(0));
                        user.Identification = sqlDataReader.GetString(1);
                        user.Name = sqlDataReader.GetString(2);
                        user.LastName = sqlDataReader.GetString(3);
                        user.TelNumber = sqlDataReader.GetString(4);
                        user.Email = sqlDataReader.GetString(5);
                        user.Password = sqlDataReader.GetString(6);
                        user.Role = new Role(Convert.ToInt32(sqlDataReader.GetInt32(7)), null);
                    }

                    connection.Close();

                    return user;
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

