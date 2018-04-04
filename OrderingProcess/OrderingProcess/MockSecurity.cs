using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingProcess
{
    public class MockSecurity
    {

        public MockSecurity()
        {
        }

        public static Boolean canLogin(String userName, String password)
        {
            /*
            if(!(userName.Equals("user1", StringComparison.OrdinalIgnoreCase)) || !(password.Equals("user1", StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }*/
            //Add line of code here for test commit
            return true;
        }

    }
}
