using AgenciaTurismo.Models;
using AgenciaTurismo.Controllers;
using System.Xml.Linq;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Proj MVC - Agencia Turismo");
        /*
        City city1 = new City()
        {
            Description = "Araraquara",
            DtRegistration = DateTime.Now
        };

        City city2 = new City()
        {
            Description = "Bauru",
            DtRegistration = DateTime.Now
        };

        City cityHotel = new City()
        {
            Description = "São Paulo",
            DtRegistration = DateTime.Now
        };

        //CRUD City

        //INSERT CITY

        
        if (new CityController().Insert(city1) > 0)
            Console.WriteLine("Sucesso! Cidade Inserida!");
        else
            Console.WriteLine("Erro ao inserir registro");

        if (new CityController().Insert(city2) > 0)
            Console.WriteLine("Sucesso! Cidade Inserida!");
        else
            Console.WriteLine("Erro ao inserir registro");

        if (new CityController().Insert(cityHotel) > 0)
            Console.WriteLine("Sucesso! Cidade Inserida!");
        else
            Console.WriteLine("Erro ao inserir registro");

        */
        //SELECT CITY 

        //new CityController().FindAll().ForEach(Console.WriteLine);


        // UPDATE City

      






        /*
        Address addressHotel = new Address()
        {
            Street = "Rua Augusta",
            Number = 100,
            Neighborhood = "Viva",
            PostalCode = "123456-123",
            Description = "Apto 123, Bloco C",
            DtRegistration = DateTime.Now,
            City = cityHotel
        };

        Address address1 = new Address()
        {
            Street = "Rua Feliz",
            Number = 100,
            Neighborhood = "Viva",
            PostalCode = "123456-123",
            Description = "Apto 23, Bloco F",
            DtRegistration = DateTime.Now,
            City = city1
        };

        Address address2 = new Address()
        {
            Street = "Rua Feliz",
            Number = 100,
            Neighborhood = "Viva",
            PostalCode = "123456-123",
            Description = "Apto 23, Bloco F",
            DtRegistration = DateTime.Now,
            City = city1
        };

        Address addressSource = new Address()
        {
            Street = "Rua Origem",
            Number = 200,
            Neighborhood = "Vivendo",
            PostalCode = "123456-188",
            Description = "Apto 2, Bloco F",
            DtRegistration = DateTime.Now,
            City = city1
        };

        Address addressDestination = new Address()
        {
            Street = "Rua Origem",
            Number = 200,
            Neighborhood = "Vivendo",
            PostalCode = "123456-188",
            Description = "Apto 2, Bloco F",
            DtRegistration = DateTime.Now,
            City = city2
        };

        //CRUD ADDRESS

        //INSERT ADDRESS


       
        if (new AddressController().Insert(addressHotel) > 0)
            Console.WriteLine("Sucesso! Endereço Inserido!");
        else
            Console.WriteLine("Erro ao inserir registro");

        if (new AddressController().Insert(address1) > 0)
            Console.WriteLine("Sucesso! Endereço Inserido!");
        else
            Console.WriteLine("Erro ao inserir registro");

        if (new AddressController().Insert(address2) > 0)
            Console.WriteLine("Sucesso! Endereço Inserido!");
        else
            Console.WriteLine("Erro ao inserir registro");

        if (new AddressController().Insert(addressSource) > 0)
            Console.WriteLine("Sucesso! Endereço Inserido!");
        else
            Console.WriteLine("Erro ao inserir registro");

        if (new AddressController().Insert(addressDestination) > 0)
            Console.WriteLine("Sucesso! Endereço Inserido!");
        else
            Console.WriteLine("Erro ao inserir registro");
        




        Client clientTicket = new Client()
        {
            Name = "Gustavo",
            Phone = "7070-7070",
            DtRegistration = DateTime.Now,
            Address = address1
        };

        Client clientPackage = new Client()
        {
            Name = "ANA",
            Phone = "1010-3030",
            DtRegistration = DateTime.Now,
            Address = address2
        };


        //CRUD CLIENT

        //INSERT CLIENT


       
        if (new ClientController().Insert(clientTicket) > 0)
            Console.WriteLine("Sucesso! Cliente Inserido!");
        else
            Console.WriteLine("Erro ao inserir registro");

        if (new ClientController().Insert(clientPackage) > 0)
            Console.WriteLine("Sucesso! Cliente Inserido!");
        else
            Console.WriteLine("Erro ao inserir registro");
        


        Hotel hotel = new Hotel()
        {
            Name = "Hotel Felicidade",
            Address = addressHotel,
            CostHotel = 300,
            DtRegistration = DateTime.Now,
        };

        //CRUD HOTEL

        //INSERT HOTEL
        
        if (new HotelController().Insert(hotel) > 0)
            Console.WriteLine("Sucesso! Hotel Inserido!");
        else
            Console.WriteLine("Erro ao inserir registro");
        


        Ticket ticket = new Ticket()
        {
            Source = addressSource,
            Destination = addressDestination,
            Client = clientTicket,
            CostTicket = 200,
            DtRegistration = DateTime.Now,
        };

        //CRUD TICKET

        //INSERT TICKET
       
       
        
        if (new TicketController().Insert(ticket) > 0)
            Console.WriteLine("Sucesso! Passagem Inserida!");
        else
            Console.WriteLine("Erro ao inserir registro");
     


        Package package = new Package()
        {
            Hotel = hotel,
            Ticket = ticket,
            Client = clientPackage,
            Cost = 500,
            DtRegistration = DateTime.Now,
        };

        //CRUD Package

        //INSERT PACKAGE
        
        if (new PackageController().Insert(package) > 0)
            Console.WriteLine("Sucesso! Pacote Inserido!");
        else
            Console.WriteLine("Erro ao inserir registro");
        
        */














        //DELETE CITY
        //new CityController().Delete(1);









    }
}