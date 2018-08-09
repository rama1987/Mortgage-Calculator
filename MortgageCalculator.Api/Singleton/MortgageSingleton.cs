using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MortgageCalculator.Dto;

namespace MortgageCalculator.Api.Singleton
{
    public class MortgageSingleton
    {
        private static readonly MortgageSingleton mortgageInstance = new MortgageSingleton();

        public static MortgageSingleton CreateInstance
        {
            get
            {
                return mortgageInstance;
            }
        }

        public List<Mortgage> MortgageList { get; set; }

    }
}