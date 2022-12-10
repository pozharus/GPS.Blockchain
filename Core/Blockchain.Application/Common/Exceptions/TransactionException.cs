using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Application.Common.Exceptions
{
    public class TransactionException : Exception
    {
        public TransactionException(string msg)
            : base($"Failed to send transaction to BigchainDB {msg}") { }
    }
}
