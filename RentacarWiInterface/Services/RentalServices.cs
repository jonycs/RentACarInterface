using RentacarWiInterface.Entities;
using System;

namespace RentacarWiInterface.Services
{
    class RentalServices
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        private BrasilTaxService _brasilTaxService = new BrasilTaxService();

        public RentalServices(double pricePerHour, double pricePerDay)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duracao = carRental.Fim.Subtract(carRental.Inicio);

            double basicPayment = 0.0;

            if (duracao.TotalHours <= 12.0)
            {
                basicPayment = PricePerHour * Math.Ceiling(duracao.TotalHours);
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duracao.TotalDays);
            }

            double tax = _brasilTaxService.Tax(basicPayment);
            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
