using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MortgageCalculator.Web.Models
{
    public class MortgageModel
    {
        [Required(ErrorMessage = "Loan Principal Amount is mandatory.")]
        [Display(Name = "Loan Principal Amount")]
        [DataType(DataType.Currency)]
        [Range(1, int.MaxValue, ErrorMessage = "Principal Amount should be of minimum 1.")]
        public double PrincipalAmount { get; set; }

        [Display(Name = "Loan Term in Years")]
        [Required(ErrorMessage = "Loan term is mandatory.")]
        [Range(1, 50, ErrorMessage = "Loan term should be between 1 to 50 year(s).")]
        public double LoanTerm { get; set; }

        [Display(Name = "Select Mortgage Type")]
        public string MortgageType { get; set; }

        public double Rate { get; set; }
    }

    public class MortgageResult
    {
        public double TotalRepayment { get; set; }
        public double TotalInterest { get; set; }
    }

    public class MortgageModels
    {
        public int MortgageId { get; set; }
        public string Name { get; set; }

        public string MortgageType { get; set; }

        public string InterestRepayment { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public int TermsInMonths { get; set; }
        public decimal CancellationFee { get; set; }
        public decimal EstablishmentFee { get; set; }
        public Guid SchemaIdentifier { get; internal set; }
        public decimal InterestRate { get; set; }
    }
}