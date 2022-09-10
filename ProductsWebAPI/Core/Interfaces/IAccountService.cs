using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAccountService<out TUser, in TModel>
    {
        /// <summary>
        /// Method returns all registered users.
        /// </summary>
        /// <returns>List of users.</returns>
        public IEnumerable<TUser> GetAll();

        /// <summary>
        /// Method returns user by given id.
        /// </summary>
        /// <param name="id">Given id.</param>
        /// <returns>User.</returns>
        public TUser GetById(int id);

        /// <summary>
        /// Method adds given user to list.
        /// </summary>
        /// <param name="model">Given user.</param>
        /// <returns>Added user.</returns>
        public TUser Add(TModel model);
    }
}
