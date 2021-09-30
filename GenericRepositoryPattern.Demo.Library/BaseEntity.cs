using GenericRepositoryPattern.Demo.Library.Interface;
using System;

namespace GenericRepositoryPattern.Demo.Library
{
    public class BaseEntity : IEntity
    {
        public int Id { get ; set ; }
        public DateTime CreatedDate { get ; set; } = DateTime.Now;
    }
}
