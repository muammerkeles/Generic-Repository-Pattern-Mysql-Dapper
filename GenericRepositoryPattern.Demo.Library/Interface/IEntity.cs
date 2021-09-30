using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Demo.Library.Interface
{
    public interface IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } 
    }
}
