/*
 * Copyright 2021, Yahoo Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace FlurrySDK
{
    /// <summary>
    /// A Unity plugin for Flurry SDK.
    /// The Flurry agent allows you to track the usage and behavior of your application
    /// on users' devices for viewing in the Flurry Analytics system.
    /// Set of methods that allow developers to capture detailed, aggregate information
    /// regarding the use of their app by end users.
    /// </summary>
    public partial class Flurry
    {
        // Flurry SDK constants.

        /// <summary>
        /// Constants for setting log level in analytics SDK.
        /// </summary>
        public enum LogLevel
        {
            VERBOSE = 2,
            DEBUG   = 3,
            INFO    = 4,
            WARN    = 5,
            ERROR   = 6,
            ASSERT  = 7,

            [Obsolete("please use LogLevel.VERBOSE instead of LogLevel.LogVERBOSE")]
            LogVERBOSE = VERBOSE,

            [Obsolete("please use LogLevel.DEBUG instead of LogLevel.LogDEBUG")]
            LogDEBUG = DEBUG,

            [Obsolete("please use LogLevel.INFO instead of LogLevel.LogINFO")]
            LogINFO = INFO,

            [Obsolete("please use LogLevel.WARN instead of LogLevel.LogWARN")]
            LogWARN = WARN,

            [Obsolete("please use LogLevel.ERROR instead of LogLevel.LogERROR")]
            LogERROR = ERROR,

            [Obsolete("please use LogLevel.ASSERT instead of LogLevel.LogASSERT")]
            LogASSERT = ASSERT
        }

        /// <summary>
        /// Constants for logging post install events using Flurry's FlurrySKAdNetwork class.
        /// </summary>
        public enum SKAdNetworkEvent
        {
            NoEvent       = 0,
            Registration  = 1,
            Login         = 2,
            Subscription  = 3,
            InAppPurchase = 4,
        }

        /// <summary>
        /// Status for analytics event recording.
        /// </summary>
        public enum EventRecordStatus
        {
            FlurryEventFailed = 0,
            FlurryEventRecorded,
            FlurryEventUniqueCountExceeded,
            FlurryEventParamsCountExceeded,
            FlurryEventLogCountExceeded,
            FlurryEventLoggingDelayed,
            FlurryEventAnalyticsDisabled,
            FlurryEventParametersMismatched
        }

        /// <summary>
        /// Constants for setting user gender in analytics SDK.
        /// </summary>
        public enum Gender
        {
            Male,
            Female
        }

    }
}