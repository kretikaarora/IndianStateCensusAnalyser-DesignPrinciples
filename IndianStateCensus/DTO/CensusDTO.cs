﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CensusDTO.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
//---------------------------------------------------------------------------------------------------------------------
using IndiaCensusDataDemo.DataDAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaCensusDataDemo.DTO
{
    /// <summary>
    /// Census DTO
    /// </summary>
    public class CensusDTO
    {      
        public int serialNumber;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public double totalArea;
        public double waterArea;
        public double landArea;

        /// <summary>
        /// Parameterised Constructor 
        /// </summary>
        /// <param name="stateCodeDataDAO"></param>
        public CensusDTO(StateCodeDataDAO stateCodeDataDAO)
        {          
            this.serialNumber = stateCodeDataDAO.serialNumber;
            this.stateName = stateCodeDataDAO.stateName;
            this.tin = stateCodeDataDAO.tin;
            this.stateCode = stateCodeDataDAO.stateCode;
        }

        /// <summary>
        /// Parameterised Constructor
        /// </summary>
        /// <param name="censusDataDAO"></param>
        public CensusDTO(CensusDataDAO censusDataDAO)
        {
            this.state = censusDataDAO.state;
            this.population = censusDataDAO.population;
            this.area = censusDataDAO.area;
            this.density = censusDataDAO.density;
        }

    }
}
