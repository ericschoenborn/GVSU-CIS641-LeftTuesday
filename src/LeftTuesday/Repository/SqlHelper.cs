using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FastMember;

namespace LeftTuesday.Repository
{
    public static class SqlHelper
    {
        private static MySqlConnection _con;

        public static Exception SetDatabase(string databaseName)
        {
            try
            {
                _con.Open();
                _con.ChangeDatabase(databaseName);
                _con.Close();
            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;
        }

        public static void SetConnection()
        {
            _con = new MySqlConnection("server=localhost;uid=root;pwd=20277evs;");
            try
            {
                _con.Open();
                _con.Close();
            }
            catch (Exception ex)
            {
                _con.Close();
            }
        }

        public static Exception NonQuery(string cmdString)
        {
            try
            {
                _con.Open();
                var cmd = new MySqlCommand(cmdString, _con);
                cmd.ExecuteNonQuery();
                _con.Close();
            }
            catch (Exception ex)
            {

                _con.Close();
                return ex;

            }
            return null;
        }

        public static (Exception, int) Insert(string cmdString)
        {
            try
            {
                _con.Open();
                var cmd = new MySqlCommand(cmdString, _con);
                var reader = cmd.ExecuteReader();
                
                int id = 0;
                if (reader != null && reader.Read())
                {
                    id = reader.GetInt32(0);
                }

                _con.Close();

                return (null, id);
            }
            catch (Exception ex)
            {
                if(_con != null)
                {
                    _con.Close();
                }
                
                return (ex, default);
            }
        }

        public static (Exception, T) Query<T>(string cmdString)where T : class, new()
        {
            try
            {
                _con.Open();
                var cmd = new MySqlCommand(cmdString, _con);
                var reader = cmd.ExecuteReader();

                object value = 0;
                if (reader != null && reader.Read())
                {
                    Type type = typeof(T);
                    var accessor = TypeAccessor.Create(type);
                    var members = accessor.GetMembers();
                    var t = new T();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (!reader.IsDBNull(i))
                        {
                            var fieldName = reader.GetName(i);
                            //i dont like this
                            fieldName = char.ToUpper(fieldName[0]) + fieldName.Substring(1);

                            if (members.Any(m => string.Equals(m.Name, fieldName, StringComparison.OrdinalIgnoreCase)))
                            {
                                accessor[t, fieldName] = reader.GetValue(i);
                            }
                        }
                    }

                    value = t;
                }

                _con.Close();

                return (null, (T)value);
            }
            catch (Exception ex)
            {
                if (_con != null)
                {
                    _con.Close();
                }

                return (ex, default);
            }
        }

        /*        public SqlHelper()
                {
                    _con = new MySqlConnection("server=localhost;uid=root;pwd=20277evs;");
                    try
                    {
                        _con.Open();
                        _con.Close();
                    }
                    catch (Exception ex)
                    {
                        _con.Close();
                    }
                }*/
        /*        public static IEnumerable<T> ExecuteObject<T>(string sql)
                {
                    //database=lefttuesday;
                    var cs = "server=localhost;uid=root;pwd=20277evs;";

                    using var con = new MySqlConnection(cs);
                    string result ="";
                    try
                    {
                        con.Open();
                        var stm = "CREATE DATABASE IF NOT EXISTS lefttuesday";
                        var cmd = new MySqlCommand(stm, con);
                        result = cmd.ExecuteScalar().ToString();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                    }


                    Console.WriteLine($"MySQL version: {result}");




        *//*            string connetionString = null;
                    MySqlConnection cnn;
                    SqlConnection connection = new SqlConnection(connectionString)
                    connetionString = "server=localhost;database=lefttuesday;uid=root;pwd=20277evs;";
                    string query = "CREATE DATABASE IF NOT EXISTS lefttuesday";
                    SqlCommand command = new SqlCommand(query, cnn);
                    cnn = new MySqlConnection(connetionString);*/


        /*            List<T> items = new List<T>();
                    var data = ExecuteDataTable(sql); // You probably need to build a ExecuteDataTable for your SQL-class.
                    foreach (var row in data.Rows)
                    {
                        T item = (T)Activator.CreateInstance(typeof(T), row);
                        items.Add(item);
                    }
                    return items;*//*
                }*/
    }
}
