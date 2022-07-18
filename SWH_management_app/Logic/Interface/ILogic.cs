using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
    interface ILogic
    {
        string[] GetRawDatas();
        void OverWriteDatas(ICollection<User> users);
        User GetUser(string data);
        ICollection<User> GetAllUsers(string[] lines);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUserByID(int id);
    }
}
