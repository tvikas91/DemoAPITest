using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DemoAPITest.StepDefinitions
{
    [Binding]
    class UsersSteps
    {
        
        [Then(@"Validate UserID is '(.*)'")]
        public void ThenValidateUserIDIs(string userName)
        {
            var respContent = JObject.Parse(APIStepDefinitions.response.Content.ToString());

            if(respContent["name"].ToString()!=userName)
            {
                Assert.Fail("Username not mathcing");
            }

            
        }

    }
}
