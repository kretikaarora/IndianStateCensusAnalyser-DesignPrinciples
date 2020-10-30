using IndiaCensusDataDemo;
using IndiaCensusDataDemo.DTO;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTest
{
    /// <summary>
    /// N unit Testing
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// declaring the paths for all the csv files
        /// </summary>
        public static string indianCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        public static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        public static string indianStateCensusFilePath = "C:/Users/Administrator/Desktop/IndianStateCensus/IndianStateCensus/IndianStateCensus/CSVFiles/IndiaStateCensusData.csv";
        public static string indianStateCodeFilePath = @"C:\Users\Administrator\Desktop\IndianStateCensus\IndianStateCensus\IndianStateCensus\CSVFiles\IndiaStateCode.csv";
        public static string wrongHeaderIndianStateCensusFilePath = @"C:\Users\Administrator\Desktop\IndianStateCensus\IndianStateCensus\IndianStateCensus\CSVFiles\WrongIndiaStateCensusData.csv";
        public static string wrongHeaderIndianStateCodeFilePath = @"C:\Users\Administrator\Desktop\IndianStateCensus\IndianStateCensus\IndianStateCensus\CSVFiles\WrongIndiaStateCode.csv";
        public static string wrongIndianStateCensusFilePath = @"C:\Users\Administrator\Desktop\IndianStateCensus\IndianStateCensus\IndianStateCensus\CSVFiles1\WrongIndiaStateCensusData.csv";
        public static string wrongIndianStateCodeFilePath = @"C:\Users\Administrator\Desktop\IndianStateCensus\IndianStateCensus\IndianStateCensus\CSVFiles1\WrongIndiaStateCode.csv";
        public static string wrongIndianStateCensusFileType = @"C:\Users\Administrator\Desktop\IndianStateCensus\IndianStateCensus\IndianStateCensus\CSVFiles\IndiaStateCensusData.txt";
        public static string wrongIndianStateCodeFileType = @"C:\Users\Administrator\Desktop\IndianStateCensus\IndianStateCensus\IndianStateCensus\CSVFiles\IndiaStateCode.txt";
        public static string delimeterIndianStateCensusFilePath = @"C:\Users\Administrator\Desktop\IndianStateCensus\IndianStateCensus\IndianStateCensus\CSVFiles\DelimiterIndiaStateCensusData.csv";
        public static string delimeterIndianStateCodeFilePath = @"C:\Users\Administrator\Desktop\IndianStateCensus\IndianStateCensus\IndianStateCensus\CSVFiles\DelimiterIndiaStateCode.csv";

        ///instantiating an object for census analyser and dictionaries for calculating the count in test case 1 
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        /// <summary>
        /// set up
        /// </summary>
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// Given Indian CensusFile Should Return Census Count
        /// Uc1-Tc1
        /// </summary>
        [Test]
        public void GivenIndianCensusFile_ShouldReturnCensusCount()
        {
            ///Act
            ///Calling to censusAnalyser LoadCensusData Function with country , file path , headers
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianCensusHeaders);   
            ///Assert
            Assert.AreEqual(29, totalRecord.Count); 
        }

        /// <summary>
        /// Given Wrong Indian CensusFile Should Return CustomException
        /// Uc1-Tc2
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusFile_ShouldReturnCustomException()
        {
            ///Act
            var indianCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianCensusHeaders));
            ///Assert
            Assert.AreEqual(CensusAnalyserException.Exception.FILE_NOT_FOUND, indianCensusResult.exception);           
        }

        /// <summary>
        /// Given Wrong Indian CensusFileType Should Return CustomException
        /// Uc1-Tc3
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusFileType_ShouldReturnCustomException()
        {
            ///Act
            var indianCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianCensusHeaders));
            ///Assert
            Assert.AreEqual(CensusAnalyserException.Exception.INVALID_FILE_TYPE, indianCensusResult.exception);
        }

        /// <summary>
        /// Given Wrong Indian Census Delimeter File Type Should Return Custom Exception
        /// Uc1-Tc4
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDelimeterFileType_ShouldReturnCustomException()
        {
            ///Act
            var indianCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianStateCensusFilePath, indianCensusHeaders));
            ///Assert
            Assert.AreEqual(CensusAnalyserException.Exception.INCOREECT_DELIMITER, indianCensusResult.exception);           
        }

        /// <summary>
        /// Given Wrong Indian Census Header Should Return Custom Exception
        /// Uc1-Tc5
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusHeader_ShouldReturnCustomException()
        {
            ///Act
            var indianCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianStateCensusFilePath, indianCensusHeaders));          
            ///Assert
            Assert.AreEqual(CensusAnalyserException.Exception.INCOREECT_DELIMITER, indianCensusResult.exception);  
        }

        /// <summary>
        /// Given State Code File Should Return Census Count
        /// Uc2-Tc1
        /// </summary>
        [Test]
        public void GivenStateCodeFile_ShouldReturnCensusCount()
        {
            ///Act
            stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            ///Assert
            Assert.AreEqual(37, stateRecord.Count);
        }

        /// <summary>
        /// Given Wrong StateCode File Should Return CustomException
        /// Uc2-Tc2
        /// </summary>
        [Test]
        public void GivenWrongStateCodeFile_ShouldReturnCustomException()
        {
            ///Act
            var stateResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            ///Assert
            Assert.AreEqual(CensusAnalyserException.Exception.FILE_NOT_FOUND, stateResult.exception);
        }

        /// <summary>
        /// Given Wrong State CodeFile Type Should Return CustomException
        /// Uc2-Tc3
        /// </summary>
        [Test]
        public void GivenWrongStateCodeFileType_ShouldReturnCustomException()
        {
            ///Act
            var stateResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            ///Assert
            Assert.AreEqual(CensusAnalyserException.Exception.INVALID_FILE_TYPE, stateResult.exception);
        }

        /// <summary>
        /// Given StateCode Delimeter FileType Should Return CustomException
        /// Uc2-Tc4
        /// </summary>
        [Test]
        public void GivenStateCodeDelimeterFileType_ShouldReturnCustomException()
        {
            ///Act
            var stateResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianStateCodeFilePath, indianStateCodeHeaders));
            ///Assert
            Assert.AreEqual(CensusAnalyserException.Exception.INCOREECT_DELIMITER, stateResult.exception);
        }

        /// <summary>
        /// Given Wrong StateCode Header Should Return CustomException
        /// Uc2-Tc5
        /// </summary>
        [Test]
        public void GivenWrongStateCodeHeader_ShouldReturnCustomException()
        {
            ///Act
            var stateResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianStateCodeFilePath, indianStateCodeHeaders));
            ///Assert
            Assert.AreEqual(CensusAnalyserException.Exception.INCOREECT_DELIMITER, stateResult.exception);
        }

    }
}