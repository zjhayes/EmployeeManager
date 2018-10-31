using AutoMoq;
using EmployeeManager.Shared.Services;
using EmployeeManager.Shared.Services.Interfaces;
using EmployeeManager.Shared.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeManager.Test
{
    [TestClass]
    public class HireDateServiceTests
    {
        private readonly AutoMoqer _mocker = new AutoMoqer();

        [TestInitialize]
        public void Initialize()
        {
            _mocker.GetMock<IDateTimeService>()
                .Setup(x => x.Now())
                .Returns(new DateTime(2018, 11, 01));
        }

        [TestMethod]
        public void IsAnniversary_ReturnsTrue_WhenHireDateIsToday()
        {
            var employee = CreateEmployee(new DateTime(2006, 11, 01));

            var hireDateService = _mocker.Create<HireDateService>();

            var isHireAnniversary = hireDateService.IsAnniversary(employee);

            Assert.IsTrue(isHireAnniversary);
        }

        [TestMethod]
        public void IsAnniversary_ReturnsFalse_WhenHireDateIsNotToday()
        {
            var employee = CreateEmployee(new DateTime(2006, 11, 05));

            var hireDateService = _mocker.Create<HireDateService>();

            var isHireAnniversary = hireDateService.IsAnniversary(employee);

            Assert.IsFalse(isHireAnniversary);
        }

        [TestMethod]
        public void YearsSince_AreEqual_DayOfYearLessThanNow()
        {
            var employee = CreateEmployee(new DateTime(2006, 10, 30));

            var hireDateService = _mocker.Create<HireDateService>();

            var yearsSinceHired = hireDateService.YearsSince(employee);

            var expected = 12;

            Assert.AreEqual(expected, yearsSinceHired);
        }

        [TestMethod]
        public void YearsSince_AreEqual_DayOfYearGreaterThanNow()
        {
            var employee = CreateEmployee(new DateTime(2006, 11, 05));

            var hireDateService = _mocker.Create<HireDateService>();

            var yearsSinceHired = hireDateService.YearsSince(employee);

            var expected = 11;

            Assert.AreEqual(expected, yearsSinceHired);
        }

        [TestMethod]
        public void YearsSince_AreEqual_DayOfYearEqualToNow()
        {
            var employee = CreateEmployee(new DateTime(2006, 11, 01));

            var hireDateService = _mocker.Create<HireDateService>();

            var yearsSinceHired = hireDateService.YearsSince(employee);

            var expected = 12;

            Assert.AreEqual(expected, yearsSinceHired);
        }

        private EmployeeViewModel CreateEmployee(DateTime dateOfHire)
        {
            return new EmployeeViewModel
            {
                EmployeeId = Guid.NewGuid(),
                FirstName = "Gerald",
                MiddleName = "Hubert",
                LastName = "Adler",
                BirthDate = new DateTime(1965, 10, 15),
                DateHired = dateOfHire
            };
        }
    }
}
