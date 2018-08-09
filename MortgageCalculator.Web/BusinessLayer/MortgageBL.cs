using MortgageCalculator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MortgageCalculator.Web.BusinessLayer
{
    public class MortgageBL
    {
        /// <summary>
        /// mortgage calculation core part
        /// </summary>
        /// <param name="model"></param>
        /// <returns>MortgageResult</returns>
        public static MortgageResult CalculateMorgage(MortgageModel model)
        {
            MortgageResult result = new MortgageResult();

            double Principal = 0, loanTerm = 0, intrstRate = 0, pwrValue, EMI, totalRepayment, totInterest;
            if (model != null)
            {
                loanTerm = (model.LoanTerm) * 12;
                Principal = model.PrincipalAmount;
                intrstRate = model.Rate;
            }
            intrstRate = (intrstRate / 100) / 12;

            pwrValue = Math.Pow((1 + intrstRate), loanTerm);

            EMI = Principal * intrstRate * (pwrValue / (pwrValue - 1));

            totalRepayment = Math.Round((EMI * loanTerm), 2);

            totInterest = Math.Round((totalRepayment - Principal), 2);

            result.TotalInterest = totInterest;

            result.TotalRepayment = totalRepayment;
            return result;
        }
    }
}