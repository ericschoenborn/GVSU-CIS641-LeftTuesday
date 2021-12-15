using LeftTuesday.Models;
using System;

namespace LeftTuesday.Repository
{
    public class UserRepository
    {
        public (Exception, long) AddUser(User user)
        {
            var cmdString = @$"INSERT INTO user
                                (name,secret) 
                               VALUES
                                ('{user.Name}','{user.Secret}')
                               ;SELECT LAST_INSERT_ID();";
            return SqlHelper.Insert(cmdString);
        }

        public (Exception, User) GetUser(string userName)
        {
            var cmdString = @$"Select * From user WHERE name = '{userName}';";
            return SqlHelper.QuerySingle<User>(cmdString);
        }

        public (Exception, User) GetUserById(long userId)
        {
            var cmdString = @$"Select * From user WHERE id = '{userId}';";
            return SqlHelper.QuerySingle<User>(cmdString);
        }

        public (Exception, User) UpdateUser(User user)
        {
            var cmdString = @$"UPDATE user
                                SET name='{user.Name}',
                                secret ='{user.Secret}'
                                WHERE id ={user.Id};";

            return (SqlHelper.NonQuery(cmdString), user);
        }

        public (Exception, bool) DeleteUser(int id)
        {
            var cmdString = @$"DELETE FROM user WHERE id ={id};";
            return (SqlHelper.NonQuery(cmdString), true);
        }
    }
}
