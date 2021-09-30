using GenericRepositoryPattern.Demo.Library.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Reflection;
using Dapper.Contrib.Extensions;
using GenericRepositoryPattern.Demo.Library.Helper;
using Dapper;
using GenericRepositoryPattern.Demo.Library.Core;

namespace GenericRepositoryPattern.Demo.Library.Concrete
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// readonly modifier tanımlandıktan sonra da değer atanabilir. 
        /// const modifier'a değişken tanımlanırken değer atanır değiştirlemez.
        /// </summary>
        private readonly string _tableName;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tableName"></param>
        public GenericRepository(string tableName)
        {
            this._tableName = tableName;
        }


        /// <summary>
        /// Yeni bir connection nesnesi olusturur
        /// </summary>
        /// <returns></returns>
        private MySqlConnection SqlConnection()
        {
            return new MySqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
        }

        /// <summary>
        /// protected method, bu class'tan türeyen (miras alan) claslardan da erişilebilmesi içindir. (örn bakın UserRepository.cs, orada tekrar baglnatı nesnesi olusturmadık, bunu kullandık.
        /// Bağlantıyı açar, kullanıma hazır
        /// </summary>
        /// <returns></returns>
        protected IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            conn.Open();
            return conn;
        }

        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();

        public async Task Delete(long id)
        {
            //throw new NotImplementedException();
            using (var connection = CreateConnection())
            {
                T model =default (T);
                model.Id =Convert.ToInt32(id);
                var isSuccess = await connection.DeleteAsync<T>(model);
            } 
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var connection = CreateConnection())
            {
                var result= await connection.GetAllAsync<T>();
                return result;
            }
        }

        public async Task<T> GetByIdAsync(long id)
        {
            using (var connection = CreateConnection())
            {
                var result = await connection.GetAsync<T>(id);
                return result;
            }
        }

        public async Task InsertAsync(T tdata)
        {
            using (var connection = CreateConnection())
            {
                var identity = await connection.InsertAsync<T>(tdata);

            }
        }
        public async Task<long> InsertAsync(T tData, bool returnLastInsertedId)
        {
            using (var connection = CreateConnection())
            {
                var identity = await connection.InsertAsync<T>(tData);
                return identity;
            }
        }
        public async Task<int> SaveRangeAsync(IEnumerable<T> listEntity)
        {
            var inserted = 0;
            var query = GenerateInsertQuery();
            using (var connection = CreateConnection())
            {
                inserted += await connection.ExecuteAsync(query, listEntity);
            }
            return inserted;
        }

        public async Task UpdateAsync(T t)
        {
            var updateQuery = GenerateUpdateQuery();

            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(updateQuery, t);
            }
        }


        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");
            var properties = MyHelper.GenerateListOfProperties(GetProperties);

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE Id=@Id");

            return updateQuery.ToString();
        }
        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {_tableName} ");

            insertQuery.Append("(");

            var properties = MyHelper.GenerateListOfProperties(GetProperties);
            properties.ForEach(prop => { insertQuery.Append($"[{prop}],"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");

            return insertQuery.ToString();
        }

    }
}
