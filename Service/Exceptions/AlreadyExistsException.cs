using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Exceptions
{
    public class AlreadyExistsException:Exception
    {
        public AlreadyExistsException(string message):base(message)
        {

        }
    }
}
