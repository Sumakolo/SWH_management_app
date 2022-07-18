using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.DataHandle.Interface
{
    interface IRepository
    {
        string[] GetRawDatas();
        void OverWriteDatas(ICollection<User> users);
        User GetUser(string data);
        void GetAllUsers(string[] lines);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUserByID(int id);
        bool Login(string username, string password);
    }
}
