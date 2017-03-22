using AbiokaBoilerplate.Infrastructure.Common.Exceptions;
using System.Net;

namespace AbiokaBoilerplate.Infrastructure.Framework.Authentication
{

    public class SignatureVerificationException : DenialException
    {
        public SignatureVerificationException(string message)
            : base(HttpStatusCode.Unauthorized, message) {
        }
    }
}
