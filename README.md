# Mortgage-Calculator
Mortgage Calculator

For this project, we are using the following technologies.

i. Asp.Net MVC ii. Asp.Net Web API 2.0 iii. Angular JS iv. BootStrap v. AutoFac

This project solution consists of following 4 projects.

MortgageCalculator.Web
MortgageCalculator.Api
MortgageCalculator.Dto
MortgageCalculator.UnitTests

1.MortgageCalculator.Web
-------------------------

This is MVC web project. Here we are using the MVC with Angular js for front end. From angular js UI, we are making the call to MVC HomeController.cs methods. This controller is having all the methods that we have for web.

we are using following 2 files for displaying the UI. 

i. _MortgageCals.cshtml  --> To show mortgage calculation UI 
ii.  _MortgageHome.cshtml --> To show mortgage home screen

From angular js perspecgtive, we are having following JS file for making calls to MVC controller method

i.  MortgageCalsMain.js        --> Angular routing purpose 

ii. MortgageHomeController.js  --> To load all mortgage 

iii. MortgageCalsController.js --> To load mortgage types and mortgage calculation as well 

iv. MortgageFactory.js         --> to make a call to controller method.

HomeController.cs

Following are the methods available in this controller.

i.  MortgageCalsHome() --> To redirect home screen 

ii. MortgageCals()     --> To redirect to mortgage calculation screen. iii.AllMortgages()     --> to fetch all mortgage list iv. GetMortgagetype    --> to get mortgage type

MortgageBL.cs

This class is having the CalculateMorgage() method, which is used to calculate the EMI, Total interest, Total repayment for the given loan as per terms and mortgage type that was chosen.

MortgageCalsSingleton.cs

MortgageService By using this class, we are achieving the Singleton pattern in MVC Application. to check whether mortgage list already filled or not.

2.MortgageCalculator.Api
-------------------------

MortgageController.cs

This is having following 2 methods.

i. Get() --> to get all mortgage list ii.GetById --> to get mortgage by Id

MortgageService.cs & IMortgageService.cs

Using this service, we are making call to repository to get the data from external MortgageData.dll.

In this file, we are having the Constructor dependency injection using the AutoFac IOC

MortgageRepo.cs

GetAllMortgages() method is used to get the mortgage list using Mortgage data context with the help of MortgageData.dll.

3.MortgageCalculator.DtoMortgage.cs
------------------------------------

This model is used in repository to assign after fetchinbg the data from external DLL.

4.MortgageCalculator.UnitTests
-------------------------------

This is the Automated test case project. We are using MOQ for mocking the service in the controller.
i have written the test cases using MS unit test case.

I have written the test case for validating the get all the valid mortgages as well as the invalid mortgages.
