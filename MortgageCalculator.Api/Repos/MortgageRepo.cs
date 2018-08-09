using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MortgageCalculator.Dto;
using MortgageCalculator.Api.Singleton;

namespace MortgageCalculator.Api.Repos
{
    public class MortgageRepo : IMortgageRepo
    {
        /// <summary>
        /// To get all mortgages.
        /// </summary>        
        /// <returns>List<Mortgage></returns>
        public List<Mortgage> GetAllMortgages()
        {
            if (MortgageSingleton.CreateInstance.MortgageList == null || MortgageSingleton.CreateInstance.MortgageList.Count() == 0)
            {

                using (var context = new MortgageData.MortgageDataContext())
                {

                    var mortgages = context.Mortgages.ToList();
                    List<Mortgage> result = new List<Mortgage>();
                    foreach (var mortgage in mortgages)
                    {
                        result.Add(new Mortgage()
                        {
                            Name = mortgage.Name,
                            EffectiveStartDate = mortgage.EffectiveStartDate,
                            EffectiveEndDate = mortgage.EffectiveEndDate,
                            CancellationFee = mortgage.CancellationFee,
                            EstablishmentFee = mortgage.EstablishmentFee,
                            InterestRate = mortgage.InterestRate,
                            InterestRepayment = (InterestRepayment)Enum.Parse(typeof(InterestRepayment), mortgage.InterestRepayment.ToString()),
                            MortgageId = mortgage.MortgageId,
                            MortgageType = (MortgageType)Enum.Parse(typeof(MortgageType), mortgage.MortgageType.ToString()),
                            TermsInMonths = GetTermsInMonths(mortgage.EffectiveStartDate, mortgage.EffectiveEndDate)
                        }
                        );
                    }

                    MortgageSingleton.CreateInstance.MortgageList = result;

                }
            }
            return MortgageSingleton.CreateInstance.MortgageList;

        }

        /// <summary>
        /// To get mortgage by Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Mortgage</returns>
        public Mortgage GetMortgageById(int id)
        {

            var mortgages = GetAllMortgages();
            if (mortgages != null && mortgages.Where(x => x.MortgageId == id).Any())
            {
                return mortgages.FirstOrDefault(x => x.MortgageId == id);
            }
            else
                return new Mortgage();
        }

        /// <summary>
        /// To get terms in month.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>int</returns>
        public int GetTermsInMonths(DateTime startDate, DateTime endDate)
        {
            return ((endDate.Year - startDate.Year) * 12) + (endDate.Month - startDate.Month);
        }
    }
}