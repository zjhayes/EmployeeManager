﻿using System;
using static EmployeeManager.Domain.Entities.Employee;

namespace EmployeeManager.Api.Models
{
    public class EmployeeModel
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }
        public RecurrenceInterval Recurrence { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Availability { get; set; }
    }
}