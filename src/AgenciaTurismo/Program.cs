using AgenciaTurismo.Models;
using AgenciaTurismo.Controllers;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Proj MVC - Agencia Turismo");

        City city = new City()
        {
            Description = "Araraquara",
            DtRegistration = DateTime.Now
        };

        Address address = new Address()
        {
            Street = "Rua Feliz",
            Number = 100,
            PostalCode = "123456-123",
            Description = "Apto 23, Bloco F",
            DtRegistration = DateTime.Now,
            City = new City()
        };

        Client client = new Client()
        {
            Name = "Gustavo",
            Phone = "7070-7070",
            DtRegistration = DateTime.Now,
            Address = new Address()
        };


        if (new CityController().Insert(city))
            Console.WriteLine("Sucesso! Registro Inserido!");
        else
            Console.WriteLine("Erro ao inserir registro");

        //select 

        //new CityController().FindAll().ForEach(Console.WriteLine);


        //delete
        //new CityController().Delete(1);





    }
}