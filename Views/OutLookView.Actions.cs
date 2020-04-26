using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;

namespace WinAppDriverPgeObjects.Views
{
    public partial class OutLookStandardView
    {
        private readonly WindowsDriver<WindowsElement> _driver;

        public OutLookStandardView(WindowsDriver<WindowsElement> driver) => _driver = driver;
        //public void ClickByTab(WindowsElement element)
        //{
        //    element.Click();
        //    Console.WriteLine($"Clicked WindowsElement text: {element.Text}");
        //}
        public void WaitUntil(WindowsElement element, WebDriverWait wait, string funcName)
        {
            Debug.WriteLine($"Debug: Test: {funcName} {element.Text} Date: {DateTime.Now}");
            Console.WriteLine($"Console: Test:{funcName} { element.Text} Date: {DateTime.Now}");
            wait.Until(pred => element.Displayed);
        }

        public void ClickElement(WindowsElement element,string funcName)
        {
            Debug.WriteLine($"Debug: Test: {funcName} {element.Text} Date: {DateTime.Now}");
            Console.WriteLine($"Console: Test:{funcName} { element.Text} Date: {DateTime.Now}");
            element.Click();
            var screenShot = _driver.GetScreenshot();
            screenShot.SaveAsFile($"..\\ScreenShot\\{funcName}{DateTime.Now.ToString("ddMMyyyyhhmmss")}.png", OpenQA.Selenium.ScreenshotImageFormat.Png);
        }
    }
}
