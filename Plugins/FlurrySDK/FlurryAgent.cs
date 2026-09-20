/*
 * Copyright 2022, Yahoo Inc.
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
using System.Collections.Generic;

namespace FlurrySDKInternal
{
    public abstract class FlurryAgent : IDisposable
    {
        public abstract class AgentBuilder
        {
            public abstract void Build(string apiKey);

            public abstract void WithAppVersion(string appVersion);

            public abstract void WithContinueSessionMillis(long sessionMillis);

            public abstract void WithCrashReporting(bool crashReporting);

            public abstract void WithIncludeBackgroundSessionsInMetrics(bool includeBackgroundSessionsInMetrics);

            public abstract void WithLogEnabled(bool enableLog);

            public abstract void WithLogLevel(FlurrySDK.Flurry.LogLevel logLevel);

            public abstract void WithReportLocation(bool reportLocation);

            public abstract void WithMessaging(bool enableMessaging, FlurrySDK.Flurry.IMessagingListener messagingListener);

            public abstract void WithGppConsent(string gppString, ISet<int> gppSectionIds);

            public abstract void WithDataSaleOptOut(bool isOptOut);

            public abstract void WithPerformanceMetrics(int performanceMetrics);

            public abstract void WithSslPinningEnabled(bool sslPinningEnabled);
        }

        public abstract class AgentUserProperties
        {
            public abstract void Set(string propertyName, string propertyValue);

            public abstract void Set(string propertyName, List<string> propertyValues);

            public abstract void Add(string propertyName, string propertyValue);

            public abstract void Add(string propertyName, List<string> propertyValues);

            public abstract void Remove(string propertyName, string propertyValue);

            public abstract void Remove(string propertyName, List<string> propertyValues);

            public abstract void Remove(string propertyName);

            public abstract void Flag(string propertyName);
        }

        public abstract class AgentPerformance
        {
            public abstract void ReportFullyDrawn();

            public abstract void StartResourceLogger();

            public abstract void LogResourceLogger(string id);
        }

        public abstract class AgentConfig
        {
            public abstract void Fetch();

            public abstract void Activate();

            public abstract void SetListener(FlurrySDK.Flurry.IConfigListener configListener);

            public abstract string GetString(string key, string defaultValue);
        }

        public abstract class AgentPublisherSegmentation
        {
            public abstract void Fetch();

            public abstract void SetListener(FlurrySDK.Flurry.IPublisherSegmentationListener publisherSegmentationListener);

            public abstract IDictionary<string, string> GetData();
        }

        public abstract void SetContinueSessionMillis(long sessionMillis);

        public abstract void SetCrashReporting(bool crashReporting);

        public abstract void SetIncludeBackgroundSessionsInMetrics(bool includeBackgroundSessionsInMetrics);

        public abstract void SetLogEnabled(bool enableLog);

        public abstract void SetLogLevel(FlurrySDK.Flurry.LogLevel logLevel);

        public abstract void SetSslPinningEnabled(bool sslPinningEnabled);

        public abstract void SetAge(int age);

        public abstract void SetGender(FlurrySDK.Flurry.Gender gender);

        public abstract void SetReportLocation(bool reportLocation);

        public abstract void SetSessionOrigin(string originName, string deepLink);

        public abstract void SetUserId(string userId);

        public abstract void SetVersionName(string versionName);

        public abstract void AddOrigin(string originName, string originVersion);

        public abstract void AddOrigin(string originName, string originVersion, IDictionary<string, string> originParameters);

        public abstract void AddSessionProperty(string name, string value);

        public abstract bool SetGppConsent(string gppString, ISet<int> gppSectionIds);

        public abstract void SetDataSaleOptOut(bool isOptOut);

        public abstract void DeleteData();

        public abstract void OpenPrivacyDashboard();

        public abstract int GetAgentVersion();

        public abstract string GetReleaseVersion();

        public abstract string GetSessionId();

        public abstract int LogEvent(string eventId);

        public abstract int LogEvent(string eventId, bool timed);

        public abstract int LogEvent(string eventId, IDictionary<string, string> parameters);

        public abstract int LogEvent(string eventId, IDictionary<string, string> parameters, bool timed);

        public abstract void EndTimedEvent(string eventId);

        public abstract void EndTimedEvent(string eventId, IDictionary<string, string> parameters);

        public abstract int LogEvent(FlurrySDK.Flurry.Event eventId, FlurrySDK.Flurry.EventParams parameters);

        public abstract void OnPageView();

        public abstract void OnError(string errorId, string message, string errorClass);

        public abstract void OnError(string errorId, string message, string errorClass, IDictionary<string, string> parameters);

        public abstract void LogBreadcrumb(string crashBreadcrumb);

        public abstract int LogPayment(string productName, string productId, int quantity, double price,
                                       string currency, string transactionId, IDictionary<string, string> parameters);

        public abstract void SetIAPReportingEnabled(bool enableIAP);

        public abstract void UpdateConversionValue(int conversionValue);

        public abstract void UpdateConversionValueWithEvent(FlurrySDK.Flurry.SKAdNetworkEvent flurryEvent);

        [Obsolete("please use Builder().WithMessaging() instead of SetMessagingListener()")]
        public abstract void SetMessagingListener(FlurrySDK.Flurry.IMessagingListener messagingListener);

        [Obsolete("please use PublisherSegmentation.GetData() instead of GetPublisherSegmentation()")]
        public abstract IDictionary<string, string> GetPublisherSegmentation();

        [Obsolete("please use PublisherSegmentation.Fetch() instead of FetchPublisherSegmentation()")]
        public abstract void FetchPublisherSegmentation();

        [Obsolete("please use PublisherSegmentation.RegisterListener() instead of SetPublisherSegmentationListener()")]
        public abstract void SetPublisherSegmentationListener(FlurrySDK.Flurry.IFlurryPublisherSegmentationListener flurryPublisherSegmentationListener);

        public abstract void Dispose();

    }
}
