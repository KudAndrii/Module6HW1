using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAccountService<out TUser, in TModel>
    {
        
        public IEnumerable<TUser> GetAll();


        public TUser GetById(int id);


        public string Add(TModel model);
    }
}
