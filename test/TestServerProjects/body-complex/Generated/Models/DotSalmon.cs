// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace body_complex.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class DotSalmon : DotFish
    {
        /// <summary> Initializes a new instance of DotSalmon. </summary>
        public DotSalmon()
        {
            FishType = "DotSalmon";
        }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? Location { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-BOOLEAN. </summary>
        public bool? Iswild { get; set; }
    }
}
