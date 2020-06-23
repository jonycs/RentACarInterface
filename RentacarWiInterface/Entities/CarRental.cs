using System;

namespace RentacarWiInterface.Entities
{
    class CarRental
    {
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public Vehicle Vehicle { get; set; }
        public Invoice Invoice { get; set; }

        public CarRental(DateTime inicio, DateTime fim, Vehicle vehicle)
        {
            Inicio = inicio;
            Fim = fim;
            Vehicle = vehicle;
        }
    }
}
