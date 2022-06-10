using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static eCartaBEPrj.Utils;
using TechTalk.SpecFlow;

namespace eCartaBEProjMSTests
{
    [Binding]
    public class CalculoTasaCrecimientoSteps
    {
        double tc = 0;
        double valorFinal = 0;
        double valorInicial = 0;

        [Given(@"the initial value is 50")]
        public void GivenTheInitialValueIs()
        {
            valorInicial=50;
        }
        
        [Given(@"the final value is 70")]
        public void GivenTheFinalValueIs()
        {
            valorFinal=70;
        }
        
        [When(@"the growth rate is calculated")]
        public void WhenTheGrowthRateIsCalculated()
        {
            tc = CalculateTasaCrecimiento(valorFinal, valorInicial);
            
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            Assert.AreEqual(40, tc);
        }
    }
}
