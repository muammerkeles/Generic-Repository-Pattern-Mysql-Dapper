using GenericRepositoryPattern.Demo.Library.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Demo.Library.Abstract
{
    public interface IUserRepository
    {
        Task<IEnumerable<UsersEntity>> GetAllDeactiveUsers(); 
    }
}
