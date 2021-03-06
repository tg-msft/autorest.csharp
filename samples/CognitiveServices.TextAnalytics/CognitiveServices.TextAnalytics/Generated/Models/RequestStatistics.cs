// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> if showStats=true was specified in the request this field will contain information about the request payload. </summary>
    public partial class RequestStatistics
    {
        /// <summary> Number of documents submitted in the request. </summary>
        public int DocumentsCount { get; set; }
        /// <summary> Number of valid documents. This excludes empty, over-size limit or non-supported languages documents. </summary>
        public int ValidDocumentsCount { get; set; }
        /// <summary> Number of invalid documents. This includes empty, over-size limit or non-supported languages documents. </summary>
        public int ErroneousDocumentsCount { get; set; }
        /// <summary> Number of transactions for the request. </summary>
        public long TransactionsCount { get; set; }
    }
}
