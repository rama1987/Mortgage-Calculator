using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MortgageCalculator.Api.Controllers;
using MortgageCalculator.Api.Services;
using MortgageCalculator.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace MortgageCalculator.UnitTests
{
    [TestClass]
    public class MortgageCalsTest 
    {
        /// <summary>
        /// Gets or sets the mock MortgageService.
        /// </summary>
        private Mock<IMortgageService> mockMortRepo { get; set; }

        /// <summary>
        /// Gets or sets the mortgageList.
        /// </summary>
        private List<Mortgage> mortgageList { get; set; }

        /// <summary>
        /// The setup.
        /// </summary>
        /// The Setup
        [TestInitialize]
        public void Setup()
        {            
            this.mockMortRepo = new Mock<IMortgageService>();
            this.mortgageList =  new List<Mortgage>
                {
                   new Mortgage { Name="Variable Home Loan (Principal and Interest)", EffectiveStartDate=DateTime.Now,EffectiveEndDate=DateTime.Now.AddYears(1),CancellationFee=259,EstablishmentFee=199,MortgageType=MortgageType.Fixed, InterestRepayment = InterestRepayment.PrincipalAndInterest,TermsInMonths=12},
                   new Mortgage { Name="Variable Home Loan (Interest Only)", EffectiveStartDate=DateTime.Now,EffectiveEndDate=DateTime.Now.AddYears(1),CancellationFee=259,EstablishmentFee=199,MortgageType=MortgageType.Fixed, InterestRepayment = InterestRepayment.InterestOnly,TermsInMonths=12},
                   new Mortgage { Name="Variable Investment Loan (Interest Only)", EffectiveStartDate=DateTime.Now,EffectiveEndDate=DateTime.Now.AddYears(1),CancellationFee=259,EstablishmentFee=199,MortgageType=MortgageType.Fixed, InterestRepayment = InterestRepayment.InterestOnly,TermsInMonths=12},
                   new Mortgage { Name="Variable Investment Loan (Principal and Interest)", EffectiveStartDate=DateTime.Now,EffectiveEndDate=DateTime.Now.AddYears(1),CancellationFee=259,EstablishmentFee=199,MortgageType=MortgageType.Fixed, InterestRepayment = InterestRepayment.PrincipalAndInterest,TermsInMonths=12},
                   new Mortgage { Name="Fixed Home Loan (Principal and Interest)", EffectiveStartDate=DateTime.Now,EffectiveEndDate=DateTime.Now.AddYears(2),CancellationFee=259,EstablishmentFee=199,MortgageType=MortgageType.Variable, InterestRepayment = InterestRepayment.PrincipalAndInterest,TermsInMonths=12},
                   new Mortgage { Name="Fixed Home Loan (Interest Only)", EffectiveStartDate=DateTime.Now,EffectiveEndDate=DateTime.Now.AddYears(2),CancellationFee=259,EstablishmentFee=199,MortgageType=MortgageType.Variable, InterestRepayment = InterestRepayment.InterestOnly,TermsInMonths=12},
                   new Mortgage { Name="Fixed Investment Loan (Interest Only)", EffectiveStartDate=DateTime.Now,EffectiveEndDate=DateTime.Now.AddYears(2),CancellationFee=259,EstablishmentFee=199,MortgageType=MortgageType.Variable, InterestRepayment = InterestRepayment.InterestOnly,TermsInMonths=12},
                   new Mortgage { Name="Fixed Investment Loan (Principal and Interest)", EffectiveStartDate=DateTime.Now,EffectiveEndDate=DateTime.Now.AddYears(2),CancellationFee=259,EstablishmentFee=199,MortgageType=MortgageType.Variable, InterestRepayment = InterestRepayment.PrincipalAndInterest,TermsInMonths=12},
                };
        }

        /// <summary>
        /// to get all valid mortages
        /// </summary>
        [TestMethod]
        public void TestGetAllMortgages()
        {
            //Arrange
            mockMortRepo.Setup(s => s.GetAllMortgages()).Returns(mortgageList);

            //Act
            MortgageController controller = new MortgageController(mockMortRepo.Object);
            IHttpActionResult response = controller.Get();
            var contentResult = response as OkNegotiatedContentResult<List<Mortgage>>;
            List<Mortgage> mList = contentResult.Content;

            //Assert
            Assert.IsNotNull(mList);
            Assert.AreEqual(mList.Count, mortgageList.Count);
        }

        /// <summary>
        /// to test  in-valid mortages
        /// </summary>
        [TestMethod]
        public void TestInValidMortgages()
        {
            //Arrange
            mockMortRepo.Setup(s => s.GetAllMortgages()).Returns((List<Mortgage>)null);

            //Act
            MortgageController controller = new MortgageController(mockMortRepo.Object);
            IHttpActionResult response = controller.Get();
            var contentResult = response as OkNegotiatedContentResult<List<Mortgage>>;            

            //Assert
            Assert.IsNull(contentResult);            
        }

        /// <summary>
        /// to get all valid mortage by Id
        /// </summary>
        [TestMethod]
        public void TestGetMortgageByID_Valid()
        {
            //Arrange
            var mortId = 1;
            mockMortRepo.Setup(x => x.GetMortgageById(mortId)).Returns(new Mortgage() { MortgageId = 1 });
            //ACT
            var controller = new MortgageController(mockMortRepo.Object);
            IHttpActionResult response = controller.GetById(mortId);
            var contentResult = response as OkNegotiatedContentResult<Mortgage>;

            //Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(mortId, contentResult.Content.MortgageId);

        }

        /// <summary>
        /// to get in-valid mortage by id
        /// </summary>
        [TestMethod]
        public void TestGetMortgageByID_Invalid()
        {            
            var mortId = 500;
            mockMortRepo.Setup(x => x.GetMortgageById(mortId)).Returns((Mortgage) null);

            var controller = new MortgageController(mockMortRepo.Object);

            IHttpActionResult response = controller.GetById(mortId);

            var contentResult = response as NotFoundResult;

            Assert.IsNotNull(contentResult);
        }
    }
}
