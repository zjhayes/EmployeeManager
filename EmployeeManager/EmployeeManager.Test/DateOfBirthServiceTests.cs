using AutoMoq;
using EmployeeManager.Shared.Services;
using EmployeeManager.Shared.Services.Interfaces;
using EmployeeManager.Shared.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeManager.Test
{ 

    [TestClass]
    public class DateOfBirthServiceTests
    {
        private readonly AutoMoqer _mocker = new AutoMoqer();

        [TestInitialize]
        public void Initialize()
        {
            _mocker.GetMock<IDateTimeService>()
                .Setup(x => x.Now())
                .Returns(new DateTime(2018, 10, 15));
        }

        [TestMethod]
        public void IsAnniversary_ReturnsTrue_WhenBirthdayMatchesToday()
        {
            var employee = CreateEmployee(new DateTime(1965, 10, 15));

            var dateOfBirthService = _mocker.Create<DateOfBirthService>();

            var isBirthday = dateOfBirthService.IsAnniversary(employee);

            Assert.IsTrue(isBirthday);
        }

        [TestMethod]
        public void IsAnniversary_ReturnsFalse_WhenBirthdayIsNotToday()
        {
            var employee = CreateEmployee(new DateTime(1965, 10, 12));

            var dateOfBirthService = _mocker.Create<DateOfBirthService>();

            var isBirthday = dateOfBirthService.IsAnniversary(employee);

            Assert.IsFalse(isBirthday);
        }

        [TestMethod]
        public void Age_AreEqual_DayOfYearLessThanNow()
        {
            var employee = CreateEmployee(new DateTime(1965, 10, 01));

            var dateOfBirthService = _mocker.Create<DateOfBirthService>();

            var age = dateOfBirthService.YearsSince(employee);

            var expected = 53;

            Assert.AreEqual(expected, age);
        }

        [TestMethod]
        public void Age_AreEqual_DayOfYearGreaterThanNow()
        {
            var employee = CreateEmployee(new DateTime(1965, 10, 30));

            var dateOfBirthService = _mocker.Create<DateOfBirthService>();

            var age = dateOfBirthService.YearsSince(employee);

            var expected = 52;

            Assert.AreEqual(expected, age);
        }

        [TestMethod]
        public void Age_AreEqual_DayOfYearEqualToNow()
        {
            var employee = CreateEmployee(new DateTime(1965, 10, 15));

            var dateOfBirthService = _mocker.Create<DateOfBirthService>();

            var age = dateOfBirthService.YearsSince(employee);

            var expected = 53;

            Assert.AreEqual(expected, age);
        }

        private EmployeeViewModel CreateEmployee(DateTime birthDate)
        {
            return new EmployeeViewModel
            {
                EmployeeId = Guid.NewGuid(),
                FirstName = "Gerald",
                MiddleName = "Hubert",
                LastName = "Adler",
                BirthDate = birthDate,
                DateHired = new DateTime(2006, 11, 01)
            };
        }
    }
}
