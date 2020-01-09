using System;
using System.Collections.Generic;

namespace APXClient.APXFacilitator
{
    public class PayLoad
    {
        private string message;

        internal PayLoad(string message)
        {
            this.message = message;
        }

        public string Message
        {
            get { return this.message; }
        }

    }
}
