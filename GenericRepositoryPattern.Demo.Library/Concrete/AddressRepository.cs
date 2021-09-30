using GenericRepositoryPattern.Demo.Library.Interface;
using GenericRepositoryPattern.Demo.Library.Model.Entities;

namespace GenericRepositoryPattern.Demo.Library.Concrete
{
    public class AddressRepository : GenericRepository<AddressEntity>, IAddressRepository
    {
        /// <summary>
        /// Tablo ismini base class'a aktar
        /// </summary>
        public AddressRepository():base("address")
        {

        }
    }
}
