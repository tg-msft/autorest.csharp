// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace xml_service.Models
{
    /// <summary> signed identifier. </summary>
    public partial class SignedIdentifier
    {
        /// <summary> a unique id. </summary>
        public string Id { get; set; }
        /// <summary> An Access policy. </summary>
        public AccessPolicy AccessPolicy { get; set; } = new AccessPolicy();
    }
}
