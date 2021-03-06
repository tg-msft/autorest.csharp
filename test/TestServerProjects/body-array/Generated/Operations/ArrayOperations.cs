// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using body_array.Models;

namespace body_array
{
    internal partial class ArrayOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of ArrayOperations. </summary>
        public ArrayOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateGetNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/null", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get null array value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetNull");
            scope.Start();
            try
            {
                using var message = CreateGetNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get null array value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetNull");
            scope.Start();
            try
            {
                using var message = CreateGetNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetInvalidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/invalid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get invalid array [1, 2, 3. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetInvalid");
            scope.Start();
            try
            {
                using var message = CreateGetInvalidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get invalid array [1, 2, 3. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetInvalid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetInvalid");
            scope.Start();
            try
            {
                using var message = CreateGetInvalidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetEmptyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/empty", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get empty array value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetEmptyRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get empty array value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetEmpty(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetEmptyRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutEmptyRequest(IEnumerable<string> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/empty", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Set array value empty []. </summary>
        /// <param name="arrayBody"> The ArrayOfput-content-schemaItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEmptyAsync(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutEmpty");
            scope.Start();
            try
            {
                using var message = CreatePutEmptyRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Set array value empty []. </summary>
        /// <param name="arrayBody"> The ArrayOfput-content-schemaItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEmpty(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutEmpty");
            scope.Start();
            try
            {
                using var message = CreatePutEmptyRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetBooleanTfftRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/boolean/tfft", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get boolean array value [true, false, false, true]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<bool>>> GetBooleanTfftAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetBooleanTfft");
            scope.Start();
            try
            {
                using var message = CreateGetBooleanTfftRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<bool> value = new List<bool>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBoolean());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get boolean array value [true, false, false, true]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<bool>> GetBooleanTfft(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetBooleanTfft");
            scope.Start();
            try
            {
                using var message = CreateGetBooleanTfftRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<bool> value = new List<bool>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBoolean());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutBooleanTfftRequest(IEnumerable<bool> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/boolean/tfft", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteBooleanValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Set array value empty [true, false, false, true]. </summary>
        /// <param name="arrayBody"> The ArrayOfboolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBooleanTfftAsync(IEnumerable<bool> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutBooleanTfft");
            scope.Start();
            try
            {
                using var message = CreatePutBooleanTfftRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Set array value empty [true, false, false, true]. </summary>
        /// <param name="arrayBody"> The ArrayOfboolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBooleanTfft(IEnumerable<bool> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutBooleanTfft");
            scope.Start();
            try
            {
                using var message = CreatePutBooleanTfftRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetBooleanInvalidNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/boolean/true.null.false", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get boolean array value [true, null, false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<bool>>> GetBooleanInvalidNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetBooleanInvalidNull");
            scope.Start();
            try
            {
                using var message = CreateGetBooleanInvalidNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<bool> value = new List<bool>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBoolean());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get boolean array value [true, null, false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<bool>> GetBooleanInvalidNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetBooleanInvalidNull");
            scope.Start();
            try
            {
                using var message = CreateGetBooleanInvalidNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<bool> value = new List<bool>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBoolean());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetBooleanInvalidStringRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/boolean/true.boolean.false", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get boolean array value [true, &apos;boolean&apos;, false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<bool>>> GetBooleanInvalidStringAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetBooleanInvalidString");
            scope.Start();
            try
            {
                using var message = CreateGetBooleanInvalidStringRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<bool> value = new List<bool>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBoolean());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get boolean array value [true, &apos;boolean&apos;, false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<bool>> GetBooleanInvalidString(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetBooleanInvalidString");
            scope.Start();
            try
            {
                using var message = CreateGetBooleanInvalidStringRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<bool> value = new List<bool>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBoolean());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetIntegerValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/integer/1.-1.3.300", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetIntegerValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetIntegerValid");
            scope.Start();
            try
            {
                using var message = CreateGetIntegerValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetIntegerValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetIntegerValid");
            scope.Start();
            try
            {
                using var message = CreateGetIntegerValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutIntegerValidRequest(IEnumerable<int> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/integer/1.-1.3.300", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteNumberValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfinteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutIntegerValidAsync(IEnumerable<int> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutIntegerValid");
            scope.Start();
            try
            {
                using var message = CreatePutIntegerValidRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfinteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutIntegerValid(IEnumerable<int> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutIntegerValid");
            scope.Start();
            try
            {
                using var message = CreatePutIntegerValidRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetIntInvalidNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/integer/1.null.zero", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get integer array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetIntInvalidNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetIntInvalidNull");
            scope.Start();
            try
            {
                using var message = CreateGetIntInvalidNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get integer array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetIntInvalidNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetIntInvalidNull");
            scope.Start();
            try
            {
                using var message = CreateGetIntInvalidNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetIntInvalidStringRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/integer/1.integer.0", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get integer array value [1, &apos;integer&apos;, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<int>>> GetIntInvalidStringAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetIntInvalidString");
            scope.Start();
            try
            {
                using var message = CreateGetIntInvalidStringRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get integer array value [1, &apos;integer&apos;, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<int>> GetIntInvalidString(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetIntInvalidString");
            scope.Start();
            try
            {
                using var message = CreateGetIntInvalidStringRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<int> value = new List<int>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt32());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetLongValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/long/1.-1.3.300", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<long>>> GetLongValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetLongValid");
            scope.Start();
            try
            {
                using var message = CreateGetLongValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<long> value = new List<long>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt64());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<long>> GetLongValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetLongValid");
            scope.Start();
            try
            {
                using var message = CreateGetLongValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<long> value = new List<long>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt64());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutLongValidRequest(IEnumerable<long> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/long/1.-1.3.300", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteNumberValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfinteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutLongValidAsync(IEnumerable<long> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutLongValid");
            scope.Start();
            try
            {
                using var message = CreatePutLongValidRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfinteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutLongValid(IEnumerable<long> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutLongValid");
            scope.Start();
            try
            {
                using var message = CreatePutLongValidRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetLongInvalidNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/long/1.null.zero", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get long array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<long>>> GetLongInvalidNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetLongInvalidNull");
            scope.Start();
            try
            {
                using var message = CreateGetLongInvalidNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<long> value = new List<long>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt64());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get long array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<long>> GetLongInvalidNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetLongInvalidNull");
            scope.Start();
            try
            {
                using var message = CreateGetLongInvalidNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<long> value = new List<long>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt64());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetLongInvalidStringRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/long/1.integer.0", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get long array value [1, &apos;integer&apos;, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<long>>> GetLongInvalidStringAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetLongInvalidString");
            scope.Start();
            try
            {
                using var message = CreateGetLongInvalidStringRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<long> value = new List<long>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt64());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get long array value [1, &apos;integer&apos;, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<long>> GetLongInvalidString(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetLongInvalidString");
            scope.Start();
            try
            {
                using var message = CreateGetLongInvalidStringRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<long> value = new List<long>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetInt64());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetFloatValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/float/0--0.01-1.2e20", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<float>>> GetFloatValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetFloatValid");
            scope.Start();
            try
            {
                using var message = CreateGetFloatValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<float> value = new List<float>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetSingle());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<float>> GetFloatValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetFloatValid");
            scope.Start();
            try
            {
                using var message = CreateGetFloatValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<float> value = new List<float>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetSingle());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutFloatValidRequest(IEnumerable<float> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/float/0--0.01-1.2e20", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteNumberValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfnumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutFloatValidAsync(IEnumerable<float> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutFloatValid");
            scope.Start();
            try
            {
                using var message = CreatePutFloatValidRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfnumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutFloatValid(IEnumerable<float> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutFloatValid");
            scope.Start();
            try
            {
                using var message = CreatePutFloatValidRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetFloatInvalidNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/float/0.0-null-1.2e20", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<float>>> GetFloatInvalidNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetFloatInvalidNull");
            scope.Start();
            try
            {
                using var message = CreateGetFloatInvalidNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<float> value = new List<float>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetSingle());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<float>> GetFloatInvalidNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetFloatInvalidNull");
            scope.Start();
            try
            {
                using var message = CreateGetFloatInvalidNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<float> value = new List<float>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetSingle());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetFloatInvalidStringRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/float/1.number.0", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get boolean array value [1.0, &apos;number&apos;, 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<float>>> GetFloatInvalidStringAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetFloatInvalidString");
            scope.Start();
            try
            {
                using var message = CreateGetFloatInvalidStringRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<float> value = new List<float>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetSingle());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get boolean array value [1.0, &apos;number&apos;, 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<float>> GetFloatInvalidString(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetFloatInvalidString");
            scope.Start();
            try
            {
                using var message = CreateGetFloatInvalidStringRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<float> value = new List<float>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetSingle());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetDoubleValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/double/0--0.01-1.2e20", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<double>>> GetDoubleValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDoubleValid");
            scope.Start();
            try
            {
                using var message = CreateGetDoubleValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<double> value = new List<double>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDouble());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<double>> GetDoubleValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDoubleValid");
            scope.Start();
            try
            {
                using var message = CreateGetDoubleValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<double> value = new List<double>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDouble());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutDoubleValidRequest(IEnumerable<double> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/double/0--0.01-1.2e20", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteNumberValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfnumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDoubleValidAsync(IEnumerable<double> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutDoubleValid");
            scope.Start();
            try
            {
                using var message = CreatePutDoubleValidRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfnumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDoubleValid(IEnumerable<double> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutDoubleValid");
            scope.Start();
            try
            {
                using var message = CreatePutDoubleValidRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetDoubleInvalidNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/double/0.0-null-1.2e20", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<double>>> GetDoubleInvalidNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDoubleInvalidNull");
            scope.Start();
            try
            {
                using var message = CreateGetDoubleInvalidNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<double> value = new List<double>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDouble());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<double>> GetDoubleInvalidNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDoubleInvalidNull");
            scope.Start();
            try
            {
                using var message = CreateGetDoubleInvalidNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<double> value = new List<double>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDouble());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetDoubleInvalidStringRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/double/1.number.0", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get boolean array value [1.0, &apos;number&apos;, 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<double>>> GetDoubleInvalidStringAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDoubleInvalidString");
            scope.Start();
            try
            {
                using var message = CreateGetDoubleInvalidStringRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<double> value = new List<double>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDouble());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get boolean array value [1.0, &apos;number&apos;, 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<double>> GetDoubleInvalidString(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDoubleInvalidString");
            scope.Start();
            try
            {
                using var message = CreateGetDoubleInvalidStringRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<double> value = new List<double>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDouble());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetStringValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/string/foo1.foo2.foo3", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get string array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<string>>> GetStringValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetStringValid");
            scope.Start();
            try
            {
                using var message = CreateGetStringValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<string> value = new List<string>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get string array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<string>> GetStringValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetStringValid");
            scope.Start();
            try
            {
                using var message = CreateGetStringValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<string> value = new List<string>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutStringValidRequest(IEnumerable<string> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/string/foo1.foo2.foo3", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfstring to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutStringValidAsync(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutStringValid");
            scope.Start();
            try
            {
                using var message = CreatePutStringValidRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfstring to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutStringValid(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutStringValid");
            scope.Start();
            try
            {
                using var message = CreatePutStringValidRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetEnumValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/enum/foo1.foo2.foo3", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get enum array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<FooEnum>>> GetEnumValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetEnumValid");
            scope.Start();
            try
            {
                using var message = CreateGetEnumValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<FooEnum> value = new List<FooEnum>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString().ToFooEnum());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get enum array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<FooEnum>> GetEnumValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetEnumValid");
            scope.Start();
            try
            {
                using var message = CreateGetEnumValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<FooEnum> value = new List<FooEnum>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString().ToFooEnum());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutEnumValidRequest(IEnumerable<FooEnum> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/enum/foo1.foo2.foo3", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item.ToSerialString());
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfFooEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEnumValidAsync(IEnumerable<FooEnum> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutEnumValid");
            scope.Start();
            try
            {
                using var message = CreatePutEnumValidRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfFooEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEnumValid(IEnumerable<FooEnum> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutEnumValid");
            scope.Start();
            try
            {
                using var message = CreatePutEnumValidRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetStringEnumValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/string-enum/foo1.foo2.foo3", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get enum array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Enum0>>> GetStringEnumValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetStringEnumValid");
            scope.Start();
            try
            {
                using var message = CreateGetStringEnumValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Enum0> value = new List<Enum0>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(new Enum0(item.GetString()));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get enum array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Enum0>> GetStringEnumValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetStringEnumValid");
            scope.Start();
            try
            {
                using var message = CreateGetStringEnumValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<Enum0> value = new List<Enum0>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(new Enum0(item.GetString()));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutStringEnumValidRequest(IEnumerable<Enum0> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/string-enum/foo1.foo2.foo3", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item.ToString());
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfEnum0 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutStringEnumValidAsync(IEnumerable<Enum0> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutStringEnumValid");
            scope.Start();
            try
            {
                using var message = CreatePutStringEnumValidRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Set array value [&apos;foo1&apos;, &apos;foo2&apos;, &apos;foo3&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfEnum0 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutStringEnumValid(IEnumerable<Enum0> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutStringEnumValid");
            scope.Start();
            try
            {
                using var message = CreatePutStringEnumValidRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetStringWithNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/string/foo.null.foo2", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get string array value [&apos;foo&apos;, null, &apos;foo2&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<string>>> GetStringWithNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetStringWithNull");
            scope.Start();
            try
            {
                using var message = CreateGetStringWithNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<string> value = new List<string>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get string array value [&apos;foo&apos;, null, &apos;foo2&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<string>> GetStringWithNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetStringWithNull");
            scope.Start();
            try
            {
                using var message = CreateGetStringWithNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<string> value = new List<string>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetStringWithInvalidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/string/foo.123.foo2", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get string array value [&apos;foo&apos;, 123, &apos;foo2&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<string>>> GetStringWithInvalidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetStringWithInvalid");
            scope.Start();
            try
            {
                using var message = CreateGetStringWithInvalidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<string> value = new List<string>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get string array value [&apos;foo&apos;, 123, &apos;foo2&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<string>> GetStringWithInvalid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetStringWithInvalid");
            scope.Start();
            try
            {
                using var message = CreateGetStringWithInvalidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<string> value = new List<string>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetString());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetUuidValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/uuid/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get uuid array value [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;d1399005-30f7-40d6-8da6-dd7c89ad34db&apos;, &apos;f42f6aa1-a5bc-4ddf-907e-5f915de43205&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Guid>>> GetUuidValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetUuidValid");
            scope.Start();
            try
            {
                using var message = CreateGetUuidValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Guid> value = new List<Guid>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetGuid());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get uuid array value [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;d1399005-30f7-40d6-8da6-dd7c89ad34db&apos;, &apos;f42f6aa1-a5bc-4ddf-907e-5f915de43205&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Guid>> GetUuidValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetUuidValid");
            scope.Start();
            try
            {
                using var message = CreateGetUuidValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<Guid> value = new List<Guid>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetGuid());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutUuidValidRequest(IEnumerable<Guid> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/uuid/valid", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Set array value  [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;d1399005-30f7-40d6-8da6-dd7c89ad34db&apos;, &apos;f42f6aa1-a5bc-4ddf-907e-5f915de43205&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfuuid to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutUuidValidAsync(IEnumerable<Guid> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutUuidValid");
            scope.Start();
            try
            {
                using var message = CreatePutUuidValidRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Set array value  [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;d1399005-30f7-40d6-8da6-dd7c89ad34db&apos;, &apos;f42f6aa1-a5bc-4ddf-907e-5f915de43205&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfuuid to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutUuidValid(IEnumerable<Guid> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutUuidValid");
            scope.Start();
            try
            {
                using var message = CreatePutUuidValidRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetUuidInvalidCharsRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/uuid/invalidchars", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get uuid array value [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;foo&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Guid>>> GetUuidInvalidCharsAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetUuidInvalidChars");
            scope.Start();
            try
            {
                using var message = CreateGetUuidInvalidCharsRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Guid> value = new List<Guid>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetGuid());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get uuid array value [&apos;6dcc7237-45fe-45c4-8a6b-3a8a3f625652&apos;, &apos;foo&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Guid>> GetUuidInvalidChars(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetUuidInvalidChars");
            scope.Start();
            try
            {
                using var message = CreateGetUuidInvalidCharsRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<Guid> value = new List<Guid>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetGuid());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetDateValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/date/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get integer array value [&apos;2000-12-01&apos;, &apos;1980-01-02&apos;, &apos;1492-10-12&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDateValid");
            scope.Start();
            try
            {
                using var message = CreateGetDateValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("D"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get integer array value [&apos;2000-12-01&apos;, &apos;1980-01-02&apos;, &apos;1492-10-12&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDateValid");
            scope.Start();
            try
            {
                using var message = CreateGetDateValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("D"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutDateValidRequest(IEnumerable<DateTimeOffset> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/date/valid", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item, "D");
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Set array value  [&apos;2000-12-01&apos;, &apos;1980-01-02&apos;, &apos;1492-10-12&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfdate to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutDateValid");
            scope.Start();
            try
            {
                using var message = CreatePutDateValidRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Set array value  [&apos;2000-12-01&apos;, &apos;1980-01-02&apos;, &apos;1492-10-12&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfdate to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateValid(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutDateValid");
            scope.Start();
            try
            {
                using var message = CreatePutDateValidRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetDateInvalidNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/date/invalidnull", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get date array value [&apos;2012-01-01&apos;, null, &apos;1776-07-04&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateInvalidNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDateInvalidNull");
            scope.Start();
            try
            {
                using var message = CreateGetDateInvalidNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("D"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get date array value [&apos;2012-01-01&apos;, null, &apos;1776-07-04&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateInvalidNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDateInvalidNull");
            scope.Start();
            try
            {
                using var message = CreateGetDateInvalidNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("D"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetDateInvalidCharsRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/date/invalidchars", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get date array value [&apos;2011-03-22&apos;, &apos;date&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateInvalidCharsAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDateInvalidChars");
            scope.Start();
            try
            {
                using var message = CreateGetDateInvalidCharsRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("D"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get date array value [&apos;2011-03-22&apos;, &apos;date&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateInvalidChars(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDateInvalidChars");
            scope.Start();
            try
            {
                using var message = CreateGetDateInvalidCharsRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("D"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetDateTimeValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/date-time/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get date-time array value [&apos;2000-12-01t00:00:01z&apos;, &apos;1980-01-02T00:11:35+01:00&apos;, &apos;1492-10-12T10:15:01-08:00&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDateTimeValid");
            scope.Start();
            try
            {
                using var message = CreateGetDateTimeValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("S"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get date-time array value [&apos;2000-12-01t00:00:01z&apos;, &apos;1980-01-02T00:11:35+01:00&apos;, &apos;1492-10-12T10:15:01-08:00&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateTimeValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDateTimeValid");
            scope.Start();
            try
            {
                using var message = CreateGetDateTimeValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("S"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutDateTimeValidRequest(IEnumerable<DateTimeOffset> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/date-time/valid", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item, "S");
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Set array value  [&apos;2000-12-01t00:00:01z&apos;, &apos;1980-01-02T00:11:35+01:00&apos;, &apos;1492-10-12T10:15:01-08:00&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfdate-time to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateTimeValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutDateTimeValid");
            scope.Start();
            try
            {
                using var message = CreatePutDateTimeValidRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Set array value  [&apos;2000-12-01t00:00:01z&apos;, &apos;1980-01-02T00:11:35+01:00&apos;, &apos;1492-10-12T10:15:01-08:00&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfdate-time to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateTimeValid(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutDateTimeValid");
            scope.Start();
            try
            {
                using var message = CreatePutDateTimeValidRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetDateTimeInvalidNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/date-time/invalidnull", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get date array value [&apos;2000-12-01t00:00:01z&apos;, null]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeInvalidNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDateTimeInvalidNull");
            scope.Start();
            try
            {
                using var message = CreateGetDateTimeInvalidNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("S"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get date array value [&apos;2000-12-01t00:00:01z&apos;, null]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateTimeInvalidNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDateTimeInvalidNull");
            scope.Start();
            try
            {
                using var message = CreateGetDateTimeInvalidNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("S"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetDateTimeInvalidCharsRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/date-time/invalidchars", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get date array value [&apos;2000-12-01t00:00:01z&apos;, &apos;date-time&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeInvalidCharsAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDateTimeInvalidChars");
            scope.Start();
            try
            {
                using var message = CreateGetDateTimeInvalidCharsRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("S"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get date array value [&apos;2000-12-01t00:00:01z&apos;, &apos;date-time&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateTimeInvalidChars(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDateTimeInvalidChars");
            scope.Start();
            try
            {
                using var message = CreateGetDateTimeInvalidCharsRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("S"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetDateTimeRfc1123ValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/date-time-rfc1123/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get date-time array value [&apos;Fri, 01 Dec 2000 00:00:01 GMT&apos;, &apos;Wed, 02 Jan 1980 00:11:35 GMT&apos;, &apos;Wed, 12 Oct 1492 10:15:01 GMT&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<DateTimeOffset>>> GetDateTimeRfc1123ValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDateTimeRfc1123Valid");
            scope.Start();
            try
            {
                using var message = CreateGetDateTimeRfc1123ValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("R"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get date-time array value [&apos;Fri, 01 Dec 2000 00:00:01 GMT&apos;, &apos;Wed, 02 Jan 1980 00:11:35 GMT&apos;, &apos;Wed, 12 Oct 1492 10:15:01 GMT&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<DateTimeOffset>> GetDateTimeRfc1123Valid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDateTimeRfc1123Valid");
            scope.Start();
            try
            {
                using var message = CreateGetDateTimeRfc1123ValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<DateTimeOffset> value = new List<DateTimeOffset>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetDateTimeOffset("R"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutDateTimeRfc1123ValidRequest(IEnumerable<DateTimeOffset> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/date-time-rfc1123/valid", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item, "R");
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Set array value  [&apos;Fri, 01 Dec 2000 00:00:01 GMT&apos;, &apos;Wed, 02 Jan 1980 00:11:35 GMT&apos;, &apos;Wed, 12 Oct 1492 10:15:01 GMT&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfdate-time to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDateTimeRfc1123ValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutDateTimeRfc1123Valid");
            scope.Start();
            try
            {
                using var message = CreatePutDateTimeRfc1123ValidRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Set array value  [&apos;Fri, 01 Dec 2000 00:00:01 GMT&apos;, &apos;Wed, 02 Jan 1980 00:11:35 GMT&apos;, &apos;Wed, 12 Oct 1492 10:15:01 GMT&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfdate-time to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDateTimeRfc1123Valid(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutDateTimeRfc1123Valid");
            scope.Start();
            try
            {
                using var message = CreatePutDateTimeRfc1123ValidRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetDurationValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/duration/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get duration array value [&apos;P123DT22H14M12.011S&apos;, &apos;P5DT1H0M0S&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<TimeSpan>>> GetDurationValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDurationValid");
            scope.Start();
            try
            {
                using var message = CreateGetDurationValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<TimeSpan> value = new List<TimeSpan>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetTimeSpan("P"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get duration array value [&apos;P123DT22H14M12.011S&apos;, &apos;P5DT1H0M0S&apos;]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<TimeSpan>> GetDurationValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDurationValid");
            scope.Start();
            try
            {
                using var message = CreateGetDurationValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<TimeSpan> value = new List<TimeSpan>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetTimeSpan("P"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutDurationValidRequest(IEnumerable<TimeSpan> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/duration/valid", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStringValue(item, "P");
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Set array value  [&apos;P123DT22H14M12.011S&apos;, &apos;P5DT1H0M0S&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfduration to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDurationValidAsync(IEnumerable<TimeSpan> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutDurationValid");
            scope.Start();
            try
            {
                using var message = CreatePutDurationValidRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Set array value  [&apos;P123DT22H14M12.011S&apos;, &apos;P5DT1H0M0S&apos;]. </summary>
        /// <param name="arrayBody"> The ArrayOfduration to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDurationValid(IEnumerable<TimeSpan> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutDurationValid");
            scope.Start();
            try
            {
                using var message = CreatePutDurationValidRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetByteValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/byte/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get byte array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each item encoded in base64. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<byte[]>>> GetByteValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetByteValid");
            scope.Start();
            try
            {
                using var message = CreateGetByteValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<byte[]> value = new List<byte[]>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBytesFromBase64());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get byte array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each item encoded in base64. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<byte[]>> GetByteValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetByteValid");
            scope.Start();
            try
            {
                using var message = CreateGetByteValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<byte[]> value = new List<byte[]>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBytesFromBase64());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutByteValidRequest(IEnumerable<byte[]> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/byte/valid", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteBase64StringValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Put the array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each elementencoded in base 64. </summary>
        /// <param name="arrayBody"> The ArrayOfbyte-array to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutByteValidAsync(IEnumerable<byte[]> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutByteValid");
            scope.Start();
            try
            {
                using var message = CreatePutByteValidRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put the array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each elementencoded in base 64. </summary>
        /// <param name="arrayBody"> The ArrayOfbyte-array to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutByteValid(IEnumerable<byte[]> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutByteValid");
            scope.Start();
            try
            {
                using var message = CreatePutByteValidRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetByteInvalidNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/byte/invalidnull", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get byte array value [hex(AB, AC, AD), null] with the first item base64 encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<byte[]>>> GetByteInvalidNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetByteInvalidNull");
            scope.Start();
            try
            {
                using var message = CreateGetByteInvalidNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<byte[]> value = new List<byte[]>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBytesFromBase64());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get byte array value [hex(AB, AC, AD), null] with the first item base64 encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<byte[]>> GetByteInvalidNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetByteInvalidNull");
            scope.Start();
            try
            {
                using var message = CreateGetByteInvalidNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<byte[]> value = new List<byte[]>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBytesFromBase64());
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetBase64UrlRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/prim/base64url/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get array value [&apos;a string that gets encoded with base64url&apos;, &apos;test string&apos; &apos;Lorem ipsum&apos;] with the items base64url encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<byte[]>>> GetBase64UrlAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetBase64Url");
            scope.Start();
            try
            {
                using var message = CreateGetBase64UrlRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<byte[]> value = new List<byte[]>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBytesFromBase64("U"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get array value [&apos;a string that gets encoded with base64url&apos;, &apos;test string&apos; &apos;Lorem ipsum&apos;] with the items base64url encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<byte[]>> GetBase64Url(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetBase64Url");
            scope.Start();
            try
            {
                using var message = CreateGetBase64UrlRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<byte[]> value = new List<byte[]>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(item.GetBytesFromBase64("U"));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetComplexNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/complex/null", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get array of complex type null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Product>>> GetComplexNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetComplexNull");
            scope.Start();
            try
            {
                using var message = CreateGetComplexNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get array of complex type null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Product>> GetComplexNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetComplexNull");
            scope.Start();
            try
            {
                using var message = CreateGetComplexNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetComplexEmptyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/complex/empty", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get empty array of complex type []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Product>>> GetComplexEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetComplexEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetComplexEmptyRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get empty array of complex type []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Product>> GetComplexEmpty(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetComplexEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetComplexEmptyRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetComplexItemNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/complex/itemnull", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get array of complex type with null item [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, null, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Product>>> GetComplexItemNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetComplexItemNull");
            scope.Start();
            try
            {
                using var message = CreateGetComplexItemNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get array of complex type with null item [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, null, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Product>> GetComplexItemNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetComplexItemNull");
            scope.Start();
            try
            {
                using var message = CreateGetComplexItemNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetComplexItemEmptyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/complex/itemempty", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get array of complex type with empty item [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Product>>> GetComplexItemEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetComplexItemEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetComplexItemEmptyRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get array of complex type with empty item [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Product>> GetComplexItemEmpty(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetComplexItemEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetComplexItemEmptyRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetComplexValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/complex/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get array of complex type with [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {&apos;integer&apos;: 3, &apos;string&apos;: &apos;4&apos;}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Product>>> GetComplexValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetComplexValid");
            scope.Start();
            try
            {
                using var message = CreateGetComplexValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get array of complex type with [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {&apos;integer&apos;: 3, &apos;string&apos;: &apos;4&apos;}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Product>> GetComplexValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetComplexValid");
            scope.Start();
            try
            {
                using var message = CreateGetComplexValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<Product> value = new List<Product>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                value.Add(Product.DeserializeProduct(item));
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutComplexValidRequest(IEnumerable<Product> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/complex/valid", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteObjectValue(item);
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Put an array of complex type with values [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {&apos;integer&apos;: 3, &apos;string&apos;: &apos;4&apos;}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="arrayBody"> The ArrayOfProduct to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutComplexValidAsync(IEnumerable<Product> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutComplexValid");
            scope.Start();
            try
            {
                using var message = CreatePutComplexValidRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put an array of complex type with values [{&apos;integer&apos;: 1 &apos;string&apos;: &apos;2&apos;}, {&apos;integer&apos;: 3, &apos;string&apos;: &apos;4&apos;}, {&apos;integer&apos;: 5, &apos;string&apos;: &apos;6&apos;}]. </summary>
        /// <param name="arrayBody"> The ArrayOfProduct to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutComplexValid(IEnumerable<Product> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutComplexValid");
            scope.Start();
            try
            {
                using var message = CreatePutComplexValidRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetArrayNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/array/null", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get a null array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetArrayNull");
            scope.Start();
            try
            {
                using var message = CreateGetArrayNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<ICollection<string>> value = new List<ICollection<string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    value0.Add(item0.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get a null array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<ICollection<string>>> GetArrayNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetArrayNull");
            scope.Start();
            try
            {
                using var message = CreateGetArrayNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<ICollection<string>> value = new List<ICollection<string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    value0.Add(item0.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetArrayEmptyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/array/empty", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an empty array []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetArrayEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetArrayEmptyRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<ICollection<string>> value = new List<ICollection<string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    value0.Add(item0.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get an empty array []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<ICollection<string>>> GetArrayEmpty(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetArrayEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetArrayEmptyRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<ICollection<string>> value = new List<ICollection<string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    value0.Add(item0.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetArrayItemNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/array/itemnull", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], null, [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayItemNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetArrayItemNull");
            scope.Start();
            try
            {
                using var message = CreateGetArrayItemNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<ICollection<string>> value = new List<ICollection<string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    value0.Add(item0.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], null, [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<ICollection<string>>> GetArrayItemNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetArrayItemNull");
            scope.Start();
            try
            {
                using var message = CreateGetArrayItemNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<ICollection<string>> value = new List<ICollection<string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    value0.Add(item0.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetArrayItemEmptyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/array/itemempty", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayItemEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetArrayItemEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetArrayItemEmptyRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<ICollection<string>> value = new List<ICollection<string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    value0.Add(item0.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<ICollection<string>>> GetArrayItemEmpty(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetArrayItemEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetArrayItemEmptyRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<ICollection<string>> value = new List<ICollection<string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    value0.Add(item0.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetArrayValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/array/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [&apos;4&apos;, &apos;5&apos;, &apos;6&apos;], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<ICollection<string>>>> GetArrayValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetArrayValid");
            scope.Start();
            try
            {
                using var message = CreateGetArrayValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<ICollection<string>> value = new List<ICollection<string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    value0.Add(item0.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get an array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [&apos;4&apos;, &apos;5&apos;, &apos;6&apos;], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<ICollection<string>>> GetArrayValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetArrayValid");
            scope.Start();
            try
            {
                using var message = CreateGetArrayValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<ICollection<string>> value = new List<ICollection<string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                ICollection<string> value0 = new List<string>();
                                foreach (var item0 in item.EnumerateArray())
                                {
                                    value0.Add(item0.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutArrayValidRequest(IEnumerable<ICollection<string>> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/array/valid", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStartArray();
                foreach (var item0 in item)
                {
                    content.JsonWriter.WriteStringValue(item0);
                }
                content.JsonWriter.WriteEndArray();
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Put An array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [&apos;4&apos;, &apos;5&apos;, &apos;6&apos;], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="arrayBody"> The ArrayOfArray of put-content-schema-itemsItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutArrayValidAsync(IEnumerable<ICollection<string>> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutArrayValid");
            scope.Start();
            try
            {
                using var message = CreatePutArrayValidRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put An array of array of strings [[&apos;1&apos;, &apos;2&apos;, &apos;3&apos;], [&apos;4&apos;, &apos;5&apos;, &apos;6&apos;], [&apos;7&apos;, &apos;8&apos;, &apos;9&apos;]]. </summary>
        /// <param name="arrayBody"> The ArrayOfArray of put-content-schema-itemsItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutArrayValid(IEnumerable<ICollection<string>> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutArrayValid");
            scope.Start();
            try
            {
                using var message = CreatePutArrayValidRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetDictionaryNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/dictionary/null", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an array of Dictionaries with value null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDictionaryNull");
            scope.Start();
            try
            {
                using var message = CreateGetDictionaryNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    value0.Add(property.Name, property.Value.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get an array of Dictionaries with value null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<IDictionary<string, string>>> GetDictionaryNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDictionaryNull");
            scope.Start();
            try
            {
                using var message = CreateGetDictionaryNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    value0.Add(property.Name, property.Value.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetDictionaryEmptyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/dictionary/empty", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDictionaryEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetDictionaryEmptyRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    value0.Add(property.Name, property.Value.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<IDictionary<string, string>>> GetDictionaryEmpty(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDictionaryEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetDictionaryEmptyRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    value0.Add(property.Name, property.Value.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetDictionaryItemNullRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/dictionary/itemnull", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, null, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryItemNullAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDictionaryItemNull");
            scope.Start();
            try
            {
                using var message = CreateGetDictionaryItemNullRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    value0.Add(property.Name, property.Value.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, null, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<IDictionary<string, string>>> GetDictionaryItemNull(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDictionaryItemNull");
            scope.Start();
            try
            {
                using var message = CreateGetDictionaryItemNullRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    value0.Add(property.Name, property.Value.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetDictionaryItemEmptyRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/dictionary/itemempty", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryItemEmptyAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDictionaryItemEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetDictionaryItemEmptyRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    value0.Add(property.Name, property.Value.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<IDictionary<string, string>>> GetDictionaryItemEmpty(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDictionaryItemEmpty");
            scope.Start();
            try
            {
                using var message = CreateGetDictionaryItemEmptyRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    value0.Add(property.Name, property.Value.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetDictionaryValidRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/dictionary/valid", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {&apos;4&apos;: &apos;four&apos;, &apos;5&apos;: &apos;five&apos;, &apos;6&apos;: &apos;six&apos;}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<IDictionary<string, string>>>> GetDictionaryValidAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDictionaryValid");
            scope.Start();
            try
            {
                using var message = CreateGetDictionaryValidRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    value0.Add(property.Name, property.Value.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {&apos;4&apos;: &apos;four&apos;, &apos;5&apos;: &apos;five&apos;, &apos;6&apos;: &apos;six&apos;}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<IDictionary<string, string>>> GetDictionaryValid(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.GetDictionaryValid");
            scope.Start();
            try
            {
                using var message = CreateGetDictionaryValidRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            ICollection<IDictionary<string, string>> value = new List<IDictionary<string, string>>();
                            foreach (var item in document.RootElement.EnumerateArray())
                            {
                                IDictionary<string, string> value0 = new Dictionary<string, string>();
                                foreach (var property in item.EnumerateObject())
                                {
                                    value0.Add(property.Name, property.Value.GetString());
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutDictionaryValidRequest(IEnumerable<IDictionary<string, string>> arrayBody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/array/dictionary/valid", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in arrayBody)
            {
                content.JsonWriter.WriteStartObject();
                foreach (var item0 in item)
                {
                    content.JsonWriter.WritePropertyName(item0.Key);
                    content.JsonWriter.WriteStringValue(item0.Value);
                }
                content.JsonWriter.WriteEndObject();
            }
            content.JsonWriter.WriteEndArray();
            request.Content = content;
            return message;
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {&apos;4&apos;: &apos;four&apos;, &apos;5&apos;: &apos;five&apos;, &apos;6&apos;: &apos;six&apos;}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="arrayBody"> The ArrayOfDictionary of string to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDictionaryValidAsync(IEnumerable<IDictionary<string, string>> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutDictionaryValid");
            scope.Start();
            try
            {
                using var message = CreatePutDictionaryValidRequest(arrayBody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{&apos;1&apos;: &apos;one&apos;, &apos;2&apos;: &apos;two&apos;, &apos;3&apos;: &apos;three&apos;}, {&apos;4&apos;: &apos;four&apos;, &apos;5&apos;: &apos;five&apos;, &apos;6&apos;: &apos;six&apos;}, {&apos;7&apos;: &apos;seven&apos;, &apos;8&apos;: &apos;eight&apos;, &apos;9&apos;: &apos;nine&apos;}]. </summary>
        /// <param name="arrayBody"> The ArrayOfDictionary of string to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDictionaryValid(IEnumerable<IDictionary<string, string>> arrayBody, CancellationToken cancellationToken = default)
        {
            if (arrayBody == null)
            {
                throw new ArgumentNullException(nameof(arrayBody));
            }

            using var scope = clientDiagnostics.CreateScope("ArrayOperations.PutDictionaryValid");
            scope.Start();
            try
            {
                using var message = CreatePutDictionaryValidRequest(arrayBody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
