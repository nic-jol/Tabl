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
            
            if((userName.Equals("server", StringComparison.OrdinalIgnoreCase)) && (password.Equals("server", StringComparison.OrdinalIgnoreCase)))
            {
                return "s";
            }
            else if ((userName.Equals("manager", StringComparison.OrdinalIgnoreCase)) && (password.Equals("manager", StringComparison.OrdinalIgnoreCase)))
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
