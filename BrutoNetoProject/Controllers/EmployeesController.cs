using BrutoNetoProject.Models;
using Core.Data.Entities;
using Infrasctructure.Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrutoNetoProject.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeDal _employeeDal;

        public EmployeesController(IConfiguration configuration)
        {
            string connectionString = configuration["ConnectionStrings:DefaultConnection"];
            _employeeDal = new EmployeeDal(connectionString);
        }

        // GET: EmployeesController
        public async Task<ActionResult> Index()
        {
            IEnumerable<EmployeeViewModel> employees;
            IEnumerable<EmployeeDto> employeeDtos;

            employeeDtos = await _employeeDal.GetEmployees();
            employees = employeeDtos.Select(employeeDto => EmployeeViewModel.MapFrom(employeeDto));

            return View(employees);
        }

        // GET: EmployeesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            EmployeeViewModel employee;
            EmployeeDto employeeDto;

            employeeDto = await _employeeDal.GetEmployee(id);
            employee = EmployeeViewModel.MapFrom(employeeDto);

            return View(employee);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                EmployeeDto employee = new EmployeeDto
                {
                    Name = collection["Name"].ToString(),
                    Surname = collection["Surname"].ToString(),
                    Email = collection["Email"].ToString(),
                    PhoneNumber = collection["PhoneNumber"],
                    Adress = collection["Adress"].ToString(),
                    City = collection["City"].ToString(),
                    Neto = Convert.ToDecimal(collection["Neto"])
                };

                bool result = await _employeeDal.CreateEmployee(employee);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            EmployeeViewModel employee = new EmployeeViewModel();
            EmployeeDto employeeDto = new EmployeeDto();

            employeeDto = await _employeeDal.GetEmployee(id: id);
            employee = EmployeeViewModel.MapFrom(employeeDto);

            return View(employee);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                EmployeeDto employee = new EmployeeDto
                {
                    Id = id,
                    Name = collection["Name"].ToString(),
                    Surname = collection["Surname"].ToString(),
                    Email = collection["Email"].ToString(),
                    PhoneNumber = collection["PhoneNumber"],
                    Adress = collection["Adress"].ToString(),
                    City = collection["City"].ToString(),
                    Neto = Convert.ToDecimal(collection["Neto"])
                };

                bool result = await _employeeDal.EditEmployee(employee);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            EmployeeViewModel employee;
            EmployeeDto employeeDto;

            employeeDto = await _employeeDal.GetEmployee(id);
            employee = EmployeeViewModel.MapFrom(employeeDto);

            return View(employee);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                bool result = await _employeeDal.DeleteEmployee(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
