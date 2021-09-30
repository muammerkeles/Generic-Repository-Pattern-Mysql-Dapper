using Dapper.Contrib.Extensions;
using GenericRepositoryPattern.Demo.Library.Abstract;
using GenericRepositoryPattern.Demo.Library.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Demo.Library.Concrete
{
    public class UserRepository : GenericRepository<UsersEntity>, IUserRepository
    {
        /// <summary>
        /// Tablo ismini base class'a aktar
        /// </summary>
        public UserRepository()
            :base("Users")
        {
        }


        /// <summary>
        /// Generic Repo içinde sadece bütün repository'lerin ihtiyaç duyduğu sadece ORTAK methodları (CRUD diyebiliriz) kullandık.
        /// Her repository'de tekrar tekrar o methdoları yazmak işlemek yerine implemente etmemiz yeterli oldu. DRY=> Dont Repeat Yourself prensibi.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UsersEntity>> GetAllDeactiveUsers()
        {
            using (var connection = CreateConnection())
            {
                var result = await connection.GetAllAsync<UsersEntity>();
                return result;
            }

        }
    }
}
