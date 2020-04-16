using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using WinAppDriverPageObjects.Views;

namespace WinAppDriverPageObjects
{
    [TestClass]
    public class CalculatorPageObjectsTests
    {
        // Note: append /wd/hub to the URL if you're directing the test at Appium
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string CalculatorAppId = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";

        private static WindowsDriver<WindowsElement> _driver;
        private static CalculatorStandardView _calcStandardView;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            DesiredCapabilities options = new DesiredCapabilities();
            options.SetCapability("app", CalculatorAppId);
            options.SetCapability("deviceName", "WindowsPC");
            _driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            _calcStandardView = new CalculatorStandardView(_driver);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }

        [TestMethod]
        public void Addition()
        {
            _calcStandardView.PerformCalculation(5, '+', 7);

            _calcStandardView.AssertResult(12);
        }

        [TestMethod]
        public void Division()
        {
            _calcStandardView.PerformCalculation(8, '/', 1);

            _calcStandardView.AssertResult(8);
        }

        [TestMethod]
        public void Multiplication()
        {
            _calcStandardView.PerformCalculation(9, '*', 9);

            _calcStandardView.AssertResult(81);
        }

        [TestMethod]
        public void Subtraction()
        {
            _calcStandardView.PerformCalculation(9, '-', 1);

            _calcStandardView.AssertResult(8);
        }

        [TestMethod]
        [DataRow(1, '+', 7, 8)]
        [DataRow(9, '-', 7, 2)]
        [DataRow(8, '/', 4, 2)]
        public void FewDataDriven(int num1, char operation, int num2, int result)
        {
            _calcStandardView.PerformCalculation(num1, operation, num2);

            _calcStandardView.AssertResult(Convert.ToDecimal(result));
        }
    }
}
