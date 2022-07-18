using Logic.Interface;
using Repository;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UserLogic : ILogic
    {
        private UserRepository userRepository;
        public UserLogic(UserRepository repository)
        {
            userRepository = repository;
        }

        //possible upgrade, not needed by the specification
        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        //possible upgrade, not needed by the specification
        public void DeleteUserByID(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all users from a string in a list.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>List<User></returns>
        public ICollection<User> GetAllUsers(string[] lines)
        {
            return userRepository.GetAllUsers(lines);
        }

        public string[] GetRawDatas()
        {
            return userRepository.GetRawDatas();
        }

        /// <summary>
        /// Get a User from a line of data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>User</returns>
        public User GetUser(string data)
        {
            return userRepository.GetUser(data);
        }

        /// <summary>
        /// Overwrites the current text file with the users list.
        /// </summary>
        /// <param name="users"></param>
        public void OverWriteDatas(ICollection<User> users)
        {
            userRepository.OverWriteDatas(users);
        }

        /// <summary>
        /// Update a User according to changes.
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(User user)
        {
            userRepository.UpdateUser(user);
        }
    }
}
