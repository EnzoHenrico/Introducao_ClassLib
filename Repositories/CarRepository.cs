using Microsoft.Data.SqlClient;
using Models;
using System.Drawing;
using System.Text;

namespace Repositories
{
    public class CarRepository
    {
        //private SqlConnection _connection = new SqlConnection
        //{
        //    ConnectionString = 
        //        "Data Source= 127.0.0.1; " +
        //        "Initial Catalog=DB_Car; " +
        //        "User Id=sa; " +
        //        "Password=SqlServer2019!; " +
        //        "TrustServerCertificate=True"
        //};

        private string _connectionString = "Data Source= 127.0.0.1; " +
                "Initial Catalog=DB_Car; " +
                "User Id=sa; " +
                "Password=SqlServer2019!; " +
                "TrustServerCertificate=True";
        SqlConnection _connection;

        public CarRepository()
        {
            _connection = new(_connectionString);
        }

        public bool Insert(Car car)
        {
            var result = false;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand{
                    Connection = _connection,
                    CommandText = Car.INSERT
                };
                cmd.Parameters.Add(new SqlParameter("@Name", car.Name ));
                cmd.Parameters.Add(new SqlParameter("@Color", car.Color ));
                cmd.Parameters.Add(new SqlParameter("@Year", car.Year ));
                cmd.ExecuteNonQuery();

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }

        public bool Update(Car car)
        {
            var result = false;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand
                {
                    Connection = _connection,
                    CommandText = Car.UPDATE
                    
                };
                cmd.Parameters.Add(new SqlParameter("@Name", car.Name));
                cmd.Parameters.Add(new SqlParameter("@Color", car.Color));
                cmd.Parameters.Add(new SqlParameter("@Year", car.Year));
                cmd.Parameters.Add(new SqlParameter("@Id", car.Id));
                cmd.ExecuteNonQuery();

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        
        public bool Delete(int id)
        {
            var result = false;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand
                {
                    Connection = _connection,
                    CommandText = Car.DELETE

                };
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.ExecuteNonQuery();

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }

        public List<Car> GetAll()
        {
            var cars = new List<Car>();
            try
            {
                _connection.Open();
                var cmd = new SqlCommand
                {
                    Connection = _connection,
                    CommandText = Car.GET_ALL
                };
                cmd.ExecuteNonQuery();

                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read()) {
                        cars.Add(new Car
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Color = reader.GetString(2),
                            Year = reader.GetInt32(3)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return cars;
        }

        public Car Get(int id)
        {
            var car = new Car();
            try
            {
                _connection.Open();
                var cmd = new SqlCommand
                {
                    Connection = _connection,
                    CommandText = Car.GET_ALL
                };
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.ExecuteNonQuery();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        car.Id = reader.GetInt32(0);
                        car.Name = reader.GetString(1);
                        car.Color = reader.GetString(2);
                        car.Year = reader.GetInt32(3);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return car;
        }
    }
}
