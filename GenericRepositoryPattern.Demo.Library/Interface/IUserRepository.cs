using GenericRepositoryPattern.Demo.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Demo.Library.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetAllDeactiveUsers(); 
    }
}
