using API_Automation;
using API_Automation.Models.Request;
using API_Automation.Models.Response;
using API_Automation.Utility;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace TestSpecFlow.Steps
{
  [Binding]
  public class CreateUserSteps
  {

    private CreateUserReq createUserReq;
    private RestResponse response;
    private ScenarioContext scenarioContext;
    private HttpStatusCode statusCode;

    public CreateUserSteps(CreateUserReq createUserReq, ScenarioContext scenarioContext)
    {
      this.createUserReq = createUserReq;
      this.scenarioContext = scenarioContext;
    }

    [Given(@"user with name ""([^""]*)""")]
    public void GivenUserWithName(string name)
    {
      createUserReq.name = name;
    }

    [Given(@"user with job ""([^""]*)""")]
    public void GivenUserWithJob(string job)
    {
      createUserReq.job = job;
    }

    [When(@"request is sent to create user")]
    public async Task WhenRequestIsSentToCreateUser()
    {
      var api = new API_Client();
      response = await api.CreateUser<CreateUserReq>(createUserReq);
    }

    [Then(@"verify user was created")]
    public void ThenVerifyUserWasCreated()
    {
      statusCode = response.StatusCode;
      var code = (int)statusCode;
      Assert.That(code, Is.EqualTo(201));

      var content = HandleContent.GetContent<CreateUserRes>(response);
      Assert.That(createUserReq.name, Is.EqualTo(content.name));
      Assert.That(createUserReq.job, Is.EqualTo(content.job));
    }
  }
}
