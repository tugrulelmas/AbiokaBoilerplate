﻿using System.Net.Http;

namespace AbiokaBoilerplate.Infrastructure.Common.Dynamic
{
    public interface IRequestContext
    {
        /// <summary>
        /// Gets the request.
        /// </summary>
        /// <value>
        /// The request.
        /// </value>
        HttpRequestMessage Request { get; }
    }
}
