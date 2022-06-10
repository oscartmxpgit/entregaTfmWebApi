using Microsoft.VisualStudio.TestTools.UnitTesting;
using static eCartaBEPrj.Utils;

namespace eCartaBEProjMSTests
{
    [TestClass]
    public class TasaCrecimientoUnitTests
    {
        [TestMethod]
        public void ShouldReturnGrowthRate()
        {
            double valorFinal = 5000;
            double valorInicial = 2500;
            double tc=CalculateTasaCrecimiento(valorFinal, valorInicial);
            Assert.AreEqual(100, tc);
        } 

        [TestMethod]
        public void ShouldReturn0GrowthRate()
        {
            double valorFinal = 5000;
            double valorInicial = 5000;
            double tc=CalculateTasaCrecimiento(valorFinal, valorInicial);
            Assert.AreEqual(0, tc);
        } 
        
        [TestMethod]
        public void ShouldReturnValidGrowthWhenValInic0()
        {
            double valorFinal = 5000;
            double valorInicial = 0;
            double tc=CalculateTasaCrecimiento(valorFinal, valorInicial);
            Assert.AreEqual(5000000, tc);
        }

        [TestMethod]
        public void ShouldReturn0GrowthWhenValInic0ValFin0()
        {
            double valorFinal = 0;
            double valorInicial = 0;
            double tc = CalculateTasaCrecimiento(valorFinal, valorInicial);
            Assert.AreEqual(0, tc);
        }

        [TestMethod]
        public void ShouldReturnNegativeGrowthCrecimientoWhenValIniLessThanValFin()
        {
            double valorFinal = 7999;
            double valorInicial = 8000;
            double tc = CalculateTasaCrecimiento(valorFinal, valorInicial);
            Assert.AreEqual(-0.0125, tc);
        }
    }
}
