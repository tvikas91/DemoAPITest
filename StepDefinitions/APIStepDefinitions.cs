using AventStack.ExtentReports.Gherkin.Model;
using DemoAPITest.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DemoAPITest.StepDefinitions
{
    [Binding]
    class APIStepDefinitions
    {
        RestClient restClient;        
        RestRequest request;
        public static string json = "";
        public static IRestResponse response;
        public static string baseURL = "";
        public static string endpoint = "";
        public static string jsonpath = "";


        [Given(@"URL for API is '(.*)'")]
        public void GivenURLForAPIIs(string endPoint)
        {
            baseURL = ConfigurationManager.AppSettings["url"];
            restClient = new RestClient(baseURL + endPoint);
        }

        [Given(@"Create GET Request")]
        public void GivenCreateGETRequest()
        {
            //header = OAuthHelper.GetAuthenticationHeader(true);
            request = new RestRequest(Method.GET);
            //request.AddHeader("Authorization", header);

        }

        [Given(@"Create POST request")]
        public void GivenCreatePOSTRequest()
        {
            //header = OAuthHelper.GetAuthenticationHeader(true);
            request = new RestRequest(Method.POST);
            //request.AddHeader("Authorization", header);
        }

        [When(@"Execute the request")]
        public void WhenExecuteTheRequest()
        {
            if (request.Method != Method.DELETE || request.Method!=Method.GET)
                request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            response = restClient.Execute(request);
        }

        [Then(@"Status Code is '(.*)'")]
        public void ThenStatusCodeIs(string statusCode)
        {
           if(response.StatusCode.ToString()!=statusCode)
            {
                Assert.Fail("Status code is " + response.StatusCode.ToString() + "\n" + response.Content);
            }
        }


        [Then(@"Response Content")]
        public void ThenResponseContent()
        {
            Hooks.scenario.CreateNode<And>(response.Content.ToString());
        }

       

        [Given(@"Payload is '(.*)'")]
        public void GivenPayloadIs(string path)
        {
            jsonpath = path;
            json = JsonManager.JsonString(@path);
        }


    }

}
