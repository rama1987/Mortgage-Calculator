using System.Collections.Generic;
using MortgageCalculator.Api.Repos;
using MortgageCalculator.Dto;

namespace MortgageCalculator.Api.Services
{
    public class MortgageService : IMortgageService
    {

        private readonly IMortgageRepo _mortgageRepo;
        public MortgageService() : this(new MortgageRepo())
        { }

        /// <summary>
        /// Constructor dependency injection.
        /// </summary>
        public MortgageService(IMortgageRepo mortgageRepo)
        {
            this._mortgageRepo = mortgageRepo;
        }

        /// <summary>
        /// To get all mortgages.
        /// </summary>        
        /// <returns>List<Mortgage></returns>
        public List<Mortgage> GetAllMortgages()
        {
            return _mortgageRepo.GetAllMortgages();
        }

        /// <summary>
        /// To get mortgage by Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Mortgage</returns>
        public Mortgage GetMortgageById(int id)
        {
            return _mortgageRepo.GetMortgageById(id);
        }
    }
}