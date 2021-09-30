using GenericRepositoryPattern.Demo.Library.Concrete;
using GenericRepositoryPattern.Demo.Library.Model.Users;
using GenericRepositoryPattern.Demo.Library.Model.Entities;
using System;
namespace Application.Main
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var userRepo = new UserRepository();
            /*
            await userRepo.InsertAsync(new UsersEntity
            {
                CityName="Istanbul",
                FirstName="Muammer",
                LastName="Keles"
            });
            await userRepo.UpdateAsync(new UsersEntity
            {
                Id = 1,
                CityName = "Istanbul",
                FirstName = "Muammer",
            });
            */
            var pasifUyeler=userRepo.GetAllDeactiveUsers();
            var uye=userRepo.GetByIdAsync(1);
        }
    }
}
