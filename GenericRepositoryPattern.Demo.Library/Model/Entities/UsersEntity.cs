using System.ComponentModel.DataAnnotations.Schema;

namespace GenericRepositoryPattern.Demo.Library.Model.Entities
{
    [Table(name:"Users")]
    public class UsersEntity:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CityName { get; set; }
    }
}
