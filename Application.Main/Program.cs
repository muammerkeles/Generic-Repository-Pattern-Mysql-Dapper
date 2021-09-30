using GenericRepositoryPattern.Demo.Library.Concrete;
using System;

namespace Application.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var userRepo = new UserRepository();
            var pasifUyeler=userRepo.GetAllDeactiveUsers();
            var uye=userRepo.GetByIdAsync(1);
        }
    }
}
