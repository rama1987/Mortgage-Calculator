using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MortgageCalculator.Dto;
using MortgageCalculator.Web.Models;

namespace MortgageCalculator.Web.Singleton
{
    public class MortgageCalsSingleton
    {
        private static readonly MortgageCalsSingleton mortgageInstance = new MortgageCalsSingleton();

        public static MortgageCalsSingleton CreateInstance
        {
            get
            {
                return mortgageInstance;
            }
        }

        public List<MortgageModels> MortgageList { get; set; }

    }
}