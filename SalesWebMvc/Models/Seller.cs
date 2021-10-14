using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String Nome { get; set; }
        public Double BaseSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public Departament Departament { get; set; }
        public int DepartamentId { get; set; }
        public ICollection<SallesRecord> Sales { get; set; } = new List<SallesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string email, string nome, double baseSalary, DateTime birthDate, Departament departament)
        {
            Id = id;
            Email = email;
            Nome = nome;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Departament = departament;
        }

        public void AddSale(SallesRecord sale)
        {
            this.Sales.Add(sale);
        }

        public void RemoveSale(SallesRecord sale)
        {
            this.Sales.Remove(sale);
        }

        public Double TotalSalles(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
