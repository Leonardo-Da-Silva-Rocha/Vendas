using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        public String Nome { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public Double BaseSalary { get; set; }

        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
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
