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

        public static String canLogin(String userName, String password)
        {
            
            if(((userName.Trim()).Equals("server", StringComparison.OrdinalIgnoreCase)) && ((password.Trim()).Equals("server", StringComparison.OrdinalIgnoreCase)))
            {
                return "s";
            }
            else if (((userName.Trim()).Equals("manager", StringComparison.OrdinalIgnoreCase)) && ((password.Trim()).Equals("manager", StringComparison.OrdinalIgnoreCase)))
            {
                return "m";
            }
            else
            {
                return "n";
            }            
        }

    }
}
