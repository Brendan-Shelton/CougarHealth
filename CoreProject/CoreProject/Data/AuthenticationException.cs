using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException() : base()
        {

        }

        public AuthenticationException( string msg )
            : base( msg )
        {

        }
    }
}
