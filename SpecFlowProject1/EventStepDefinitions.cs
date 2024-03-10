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

        public Event(User user)
        {
            _user = user;
        }

        [Then(@"display user information")]
        public void ThenDisplayUserInformation()
        {
            Console.WriteLine($"{_user.firstName} {_user.lastName}");
        }
    }
}
