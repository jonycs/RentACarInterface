using RentacarWiInterface.Entities;
using RentacarWiInterface.Services;
using System;
using System.Globalization;
using System.Net.Http.Headers;

namespace RentacarWiInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com os dados do aluguel: ");
            Console.Write("Modelo do carro: ");
            string modelo = Console.ReadLine();
            Console.Write("Data de retirada: ");
            DateTime retirada = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Data de devolução: ");
            DateTime devolucao = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Preço por hora: R$");
            double valorPorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Valor por dia: R$");
            double valorPorDia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental cr = new CarRental(retirada, devolucao, new Vehicle(modelo));

            RentalServices rs = new RentalServices(valorPorHora, valorPorDia, new BrasilTaxService());

            rs.ProcessInvoice(cr);

            Console.WriteLine("INVOICE:");
            Console.WriteLine(cr.Invoice);
        }
    }
}
