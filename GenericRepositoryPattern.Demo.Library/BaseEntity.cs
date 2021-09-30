using Dapper.Contrib.Extensions;
using GenericRepositoryPattern.Demo.Library.Abstract;
using System;

namespace GenericRepositoryPattern.Demo.Library
{
    public class BaseEntity : IEntity
    {
        [Key]
        public int Id { get ; set ; }
        public DateTime CreatedDate { get ; set; } = DateTime.Now;
    }
}
