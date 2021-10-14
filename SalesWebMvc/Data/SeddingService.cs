using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Data
{
    public class SeddingService
    {
        private SalesWebMvcContext _context;

        public SeddingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departament.Any() || _context.Seller.Any() || _context.SallesRecord.Any())
            {
                return; //banco já populado
            }

            Departament d1 = new Departament(1, "Computens");
            Departament d2 = new Departament(2, "Eletronicos");
            Departament d3 = new Departament(3, "Moda");
            Departament d4 = new Departament(4, "Livros");

            Seller s1 = new Seller(1, "Bob@", "Bod", 1000.0, new DateTime(1998, 4, 21), d1);
            Seller s2 = new Seller(2, "maria@", "maria", 2000.0, new DateTime(1998, 5, 22), d2);
            Seller s3 = new Seller(3, "mario@", "mario", 3000.0, new DateTime(1998, 6, 23), d3);
            Seller s4 = new Seller(4, "teste@", "teste", 4000.0, new DateTime(1998, 7, 24), d4);

            SallesRecord r1 = new SallesRecord(1, new DateTime(2019, 09, 25), 11000.0, Models.Enuns.SallesStatus.Billed, s1);
            SallesRecord r2 = new SallesRecord(2, new DateTime(2017, 09, 25), 11000.0, Models.Enuns.SallesStatus.Cancellad, s2);
            SallesRecord r3 = new SallesRecord(3, new DateTime(2016, 09, 25), 11000.0, Models.Enuns.SallesStatus.Pedding, s3);
            SallesRecord r4 = new SallesRecord(4, new DateTime(2015, 09, 25), 11000.0, Models.Enuns.SallesStatus.Billed, s4);

            _context.Departament.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4);
            _context.SallesRecord.AddRange(r1, r2, r3, r4);
            _context.SaveChanges();
        }
    }
}
