using System;
using Specflow.Drivers;
using TechTalk.SpecFlow;

namespace Specflow.Hooks
{
    [Binding]
    public class Hooks
    {
        [AfterScenario]
        public void TearDown() {
            Driver.driver.Quit();
        }
        
    }
}
