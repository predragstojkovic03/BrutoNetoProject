using Core.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace BrutoNetoProject.Models
{
    public class EmployeeViewModel
    {
        [Display(Name = "Identifikacija")]
        public int Id { get; set; }

        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Ime je obavezno.")]
        [StringLength(50, ErrorMessage = "Maksimalna duzina imena je 50.")]
        public string Name { get; set; }

        [Display(Name = "Prezime")]
        [Required(ErrorMessage = "Prezime je obavezno.")]
        [StringLength(50, ErrorMessage = "Maksimalna duzina prezimena je 50.")]
        public string Surname { get; set; }

        [Display(Name = "Email adresa")]
        [EmailAddress(ErrorMessage = "Nepravilan unos email adrese.")]
        [Required(ErrorMessage = "Email adresa je obavezna.")]
        [StringLength(50, ErrorMessage = "Maksimalna duzina e-mail-a je 320.")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Nepravilan unos broja telefona.")]
        [Display(Name = "Broj mobilnog telefona")]
        [Required(ErrorMessage = "Phone Number Required!")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Adresa")]
        [Required(ErrorMessage = "Adresa je obavezna.")]
        [StringLength(50, ErrorMessage = "Maksimalna duzina adrese je 100.")]
        public string Adress { get; set; }

        [Display(Name = "Grad")]
        [Required(ErrorMessage = "Grad je obavezan.")]
        [StringLength(50, ErrorMessage = "Maksimalna duzina imena grada je 66.")]
        public string City { get; set; }

        [Display(Name = "Neto iznos plate")]
        [Required(ErrorMessage = "Neto iznos plate je obavezan.")]
        [Range(1, 9999999.99, ErrorMessage = "Neto iznost plate mora biti izmedju 1 i 9999999,99.")]
        public decimal Neto { get; set; }

        [Display(Name = "Bruto iznos plate")]
        public decimal Bruto { get; set; }

        public static EmployeeViewModel MapFrom(EmployeeDto employeeDto)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            employeeViewModel.Id = employeeDto.Id;
            employeeViewModel.Name = employeeDto.Name;
            employeeViewModel.Surname = employeeDto.Surname;
            employeeViewModel.Surname = employeeDto.Surname;
            employeeViewModel.Email = employeeDto.Email;
            employeeViewModel.PhoneNumber = employeeDto.PhoneNumber;
            employeeViewModel.Adress = employeeDto.Adress;
            employeeViewModel.City = employeeDto.City;
            employeeViewModel.Neto = employeeDto.Neto;
            employeeViewModel.Bruto = employeeDto.Bruto;

            return employeeViewModel;
        }
    }
}
