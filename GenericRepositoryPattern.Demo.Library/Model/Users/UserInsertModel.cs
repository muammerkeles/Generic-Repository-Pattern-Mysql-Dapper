using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Demo.Library.Model.Users
{
    public class UserInsertModel:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CityName { get; set; }
    }
}
