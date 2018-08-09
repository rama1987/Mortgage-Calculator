﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MortgageCalculator.Dto;

namespace MortgageCalculator.Api.Services
{
    public interface IMortgageService
    {
        /// <summary>
        /// To get all mortgages.
        /// </summary>        
        /// <returns>List<Mortgage></returns>
        List<Mortgage> GetAllMortgages();

        /// <summary>
        /// To get mortgage by Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Mortgage</returns>
        Mortgage GetMortgageById(int id);
    }

}