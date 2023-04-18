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
            Neighborhood = "Viva",
            PostalCode = "123456-123",
            Description = "Apto 23, Bloco F",
            DtRegistration = DateTime.Now,
            City = city
        };

    Client client = new Client()
    {
        Name = "Gustavo",
        Phone = "7070-7070",
        DtRegistration = DateTime.Now,
        Address = address
        };


        /*
         * INSERT CITY
         if (new CityController().Insert(city)>0)
            Console.WriteLine("Sucesso! Registro Inserido!");
        else
            Console.WriteLine("Erro ao inserir registro");
 */

        /*INSERT ADDRESS
         * if (new AddressController().Insert(address)>0)
            Console.WriteLine("Sucesso! Registro Inserido!");
        else
            Console.WriteLine("Erro ao inserir registro");
        */

        /*INSERT CLIENT
         * if (new ClientController().Insert(client) > 0)
            Console.WriteLine("Sucesso! Registro Inserido!");
        else
            Console.WriteLine("Erro ao inserir registro");
        */

        //update City
        new CityController().Update("São carlos", 35);



        //SELECT CITY 
        //new CityController().FindAll().ForEach(Console.WriteLine);


        //DELETE CITY
        //new CityController().Delete(1);





    }
}