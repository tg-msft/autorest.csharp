// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core;

namespace header
{
    internal class ResponseStringHeaders
    {
        private readonly Azure.Response _response;
        public ResponseStringHeaders(Azure.Response response)
        {
            _response = response;
        }
        public string? Value => _response.Headers.TryGetValue("value", out string? value) ? value : null;
    }
}
