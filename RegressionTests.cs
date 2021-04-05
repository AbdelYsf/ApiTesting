using System;
using System.Net;
using AventStack.ExtentReports;
using DemoRestsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoRestsharp.Helpers;
using  DemoRestsharp.DTO;
using DemoRestsharp.Reporter;


namespace ApiTest
{
    [TestClass]
    public class RegressionTests
    {
        

        public  TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            var dir = context.TestRunDirectory;
            ReportHandler.SetupExtentReport("myreport","hello",dir);
        }

        [TestInitialize]
        public void SetupTest()
        {
            ReportHandler.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void CleanUpTest()
        {
            var teststatus = TestContext.CurrentTestOutcome;
            Status logstatus;

            switch (teststatus)
            {
                case UnitTestOutcome.Failed:
                    logstatus = Status.Fail;
                    ReportHandler.TestStatus(logstatus.ToString());
                    break;
                case UnitTestOutcome.Passed:
                    logstatus = Status.Pass;
                    ReportHandler.TestStatus(logstatus.ToString());
                    break;
                case UnitTestOutcome.InProgress:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Inconclusive:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
            }



           
        }
        [TestMethod]
        public void VerifyListOfUsers()
        {
            var demo = new APIHandler<ListOfUsersDTO>();
            var response =demo.GetRequest("https://reqres.in/api/users?page=2");
            Assert.AreEqual(2,response.page);
//            ReportHandler.LogToReport(Status.Info,"test1");
            Assert.AreEqual("Michael", response.data[0].first_name);
  //          ReportHandler.LogToReport(Status.Info, "test2");

        }

        //[DeploymentItem("..\\TestData\\testdata.csv"),
        // DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
        //     "testdata.csv","testdata#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestMethod1()
        {
            //string payload = @"{
            //                ""name"":""abdel"",
            //                ""job"":""leader""
            //                    }";
            var payload = new CreateUserRequestDTO();
            payload.job = "leder"; //TestContext.DataRow["job"].ToString();
            payload.name = "abdel"; //TestContext.DataRow["name"].ToString();
            var handler = new APIHandler<CreateUserDTO>();
            var response = handler.PostRequest(EndPoints.USERS_ENDPOINT, payload);
            Assert.AreEqual("abdel", response.Name);
            Assert.AreEqual(response.Response.StatusCode,HttpStatusCode.Created);
        }

        [ClassCleanup]
        public static void cleanup()
        {
           ReportHandler.FlushReport();
        }
    }
}
