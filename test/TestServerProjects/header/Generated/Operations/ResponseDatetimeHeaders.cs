// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.Core;

namespace header
{
    internal class ResponseDatetimeHeaders
    {
        private readonly Response _response;
        public ResponseDatetimeHeaders(Response response)
        {
            _response = response;
        }
        public DateTimeOffset? Value => _response.Headers.TryGetValue("value", out DateTimeOffset? value) ? value : null;
    }
}
