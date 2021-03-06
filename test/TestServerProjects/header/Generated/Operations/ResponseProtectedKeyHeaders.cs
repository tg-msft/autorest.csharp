// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core;

namespace header
{
    internal class ResponseProtectedKeyHeaders
    {
        private readonly Azure.Response _response;
        public ResponseProtectedKeyHeaders(Azure.Response response)
        {
            _response = response;
        }
        public string? ContentType => _response.Headers.TryGetValue("Content-Type", out string? value) ? value : null;
    }
}
