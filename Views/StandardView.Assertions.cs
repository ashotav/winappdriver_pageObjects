//using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WinAppDriverPageObjects.Views
{
    public partial class CalculatorStandardView
    {
        public void AssertResult(decimal expectedReslt)
        {
            string strResult = GetCalculatorResultText();
            var actualResult = decimal.Parse(strResult);

            Assert.AreEqual(expectedReslt, actualResult);
        }
    }
}
