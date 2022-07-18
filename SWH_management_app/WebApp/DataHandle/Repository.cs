using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApp.DataHandle.Interface;
using WebApp.Models;

namespace WebApp.DataHandle
{
    public class Repository : IRepository
    {
        public List<User> users { get; set; }

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
        /// Reads the text file which holds the users' properties.
        /// </summary>
        /// <returns>string[]</returns>
        public string[] GetRawDatas()
        {
            string[] lines = File.ReadAllLines(@"D:\Munka\SWH_management_app\database.txt");
            return lines;
        }

        /// <summary>
        /// Gets all users from a string in a list.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>List<User></returns>
        public void GetAllUsers(string[] lines)
        {
            users = new List<User>();
            for (int i = 0; i < lines.Length; i++)
            {
                users.Add(GetUser(lines[i]));
            }
        }

        /// <summary>
        /// Get a User from a line of data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>User</returns>
        public User GetUser(string data)
        {
            User user = new User();
            string[] properties = data.Split(';');
            user.UserID = int.Parse(properties[0]);
            user.UserName = properties[1];
            user.Password = properties[2];
            user.FirstName = properties[3];
            user.LastName = properties[4];
            user.BirthYear = int.Parse(properties[5]);
            user.BirthPlace = properties[6];
            user.City = properties[7];
            return user;
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Update a User according to changes.
        /// </summary>
        /// <param name="user"></param>
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

        /// <summary>
        /// Checks if the username and password combination exists in the database.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>bool</returns>
        public bool Login(string username, string password)
        {
            bool userExist = false;
            string[] lines = GetRawDatas();
            GetAllUsers(lines);
            foreach (User item in users)
            {
                if (item.UserName == username && item.Password == password)
                {
                    userExist = true;
                }
            }
            return userExist;
        }

        /// <summary>
        /// Convert the users list to on string.
        /// </summary>
        /// <param name="users"></param>
        /// <returns>string</returns>
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
