using Repository.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IRepository
    {
        private static List<User> users { get; set; }
        //possible upgrade, not needed by the specification
        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        //possible upgrade, not needed by the specification
        public void DeleteUserByID(int ID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all users from a string in a list.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>List<User></returns>
        public ICollection<User> GetAllUsers(string [] lines)
        {
            users = new List<User>();
            for (int i = 0; i < lines.Length; i++)
            {
                users.Add(GetUser(lines[i]));
            }
            return users;
        }

        /// <summary>
        /// Reads the text file which holds the users' properties.
        /// </summary>
        /// <returns>string[]</returns>
        public string[] GetRawDatas()
        {
            string[] lines = File.ReadAllLines(@"D:\Munka\SWH_management_app\database.txt");
            return lines;
        }

        /// <summary>
        /// Overwrites the current text file with the users list.
        /// </summary>
        /// <param name="users"></param>
        public void OverWriteDatas(ICollection<User> users)
        {
            string toWriteOut = ConvertListToString(users);
            try
            {
                StreamWriter sw = new StreamWriter(@"D:\Munka\SWH_management_app\database.txt");

                sw.WriteLine(toWriteOut);

                sw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public User GetUser(string data)
        {
            User user = new User();
            string[] properties = data.Split(';');
            user.UserID = int.Parse(properties[0]);
            user.UserName = properties[1];
            user.Password = int.Parse(properties[2]);
            user.FirstName = properties[3];
            user.LastName = properties[4];
            user.BirthYear = int.Parse(properties[5]);
            user.BirthPlace = properties[6];
            user.City = properties[7];
            return user;
        }

        public void UpdateUser(User user)
        {
            int i = 0;
            while (user.UserID != users[i].UserID && i < users.Count)
            {
                i++;
            }
            if (user.UserID == users[i].UserID)
            {
                users[i].UserName = user.UserName;
                users[i].FirstName = user.FirstName;
                users[i].LastName = user.LastName;
                users[i].BirthPlace = user.BirthPlace;
                users[i].BirthYear = user.BirthYear;
                users[i].Password = user.Password;
                users[i].City = user.City;
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }
        }

        private string ConvertListToString(ICollection<User> users)
        {
            string helper = "";
            if (users.Count > 0)
            {
                foreach (User user in users)
                {
                    string line = user.UserID + ";" + user.UserName + ";" + user.Password + ";" + user.FirstName + ";" + user.LastName + ";" +
                        user.BirthYear + ";" + user.BirthPlace + ";" + user.City + "\n";

                    helper += line;
                }
            } 
            return helper;
        }
    }
}
