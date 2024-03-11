using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1
{
    [Binding]
    public class Event
    {
        public User _user;
        FeatureContext _featureContext;
        ScenarioContext _scenarioContext;

        public Event(User user, FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _user = user;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [Then(@"display user information")]
        public void ThenDisplayUserInformation()
        {
            Console.WriteLine($"{_user.firstName} {_user.lastName}");
        }

        [Given(@"Display employee full name")]
        public void GivenDisplayEmployeeFullName()
        {
            Console.WriteLine(_featureContext["EmployeeFullName"]);
           // Console.WriteLine(_scenarioContext["EmployeeMiddleName"]); // throws an error because we don't have access between scenarios
        }
    }
}
