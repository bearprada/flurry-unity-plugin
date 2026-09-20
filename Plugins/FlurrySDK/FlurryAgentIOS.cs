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
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using AOT;

#if UNITY_IOS || UNITY_IPHONE
namespace FlurrySDKInternal
{
    public class FlurryAgentIOS : FlurryAgent
    {
        static FlurrySDK.Flurry.IFlurryPublisherSegmentationListener _publisherSegmentationListener;
        static FlurrySDK.Flurry.IMessagingListener _messagingListener;

        public FlurryAgentIOS()
        {
            Debug.Log("FlurryAgentIOS instance created");
        }

        [DllImport("__Internal")]
        private static extern void initializeFlurrySessionBuilder();

        [DllImport("__Internal")]
        private static extern void flurryWithAppVersion(string appVersion);

        [DllImport("__Internal")]
        private static extern void flurryWithCrashReporting(bool crashReporting);

        [DllImport("__Internal")]
        private static extern void flurryWithSessionContinueSeconds(long sessionMillis);

        [DllImport("__Internal")]
        private static extern void flurryWithIncludeBackgroundSessionsInMetrics(bool includeBackgroundSessionsInMetrics);

        [DllImport("__Internal")]
        private static extern void flurryWithLogEnabled(bool logEnabled);

        [DllImport("__Internal")]
        private static extern void flurryWithLogLevel(int logLevel);

        [DllImport("__Internal")]
        private static extern void flurryWithDataSaleOptOut(bool isOptOut);

        [DllImport("__Internal")]
        private static extern void flurrySetupMessagingWithAutoIntegration();

        [DllImport("__Internal")]
        private static extern void flurryStartSessionWithSessionBuilder(string apiKey);

        [DllImport("__Internal")]
        private static extern void flurrySetSessionContinueSeconds(long sessionSeconds);

        [DllImport("__Internal")]
        private static extern void flurrySetIncludeBackgroundSessionsInMetrics(bool includeBackgroundSessionsInMetrics);
       
        [DllImport("__Internal")]
        private static extern void flurrySetAge(int age);

        [DllImport("__Internal")]
        private static extern void flurrySetGender(string gender);

        [DllImport("__Internal")]
        private static extern void flurrySetSessionOrigin(string originName, string deepLink);

        [DllImport("__Internal")]
        private static extern void flurrySetUserId(string userId);

        [DllImport("__Internal")]
        private static extern void flurrySetVersionName(string versionName);

        [DllImport("__Internal")]
        private static extern void flurryAddOrigin(string originName, string originVersion);

        [DllImport("__Internal")]
        private static extern void flurryAddOriginWithParams(string originName, string originVersion, string keys, string values);

        [DllImport("__Internal")]
        private static extern void flurryAddSessionProperty(string name, string value);

        [DllImport("__Internal")]
        private static extern void flurrySetDataSaleOptOut(bool isOptOut);

        [DllImport("__Internal")]
        private static extern void flurrySetDelete();

        [DllImport("__Internal")]
        private static extern void flurryOpenPrivacyDashboard();

        [DllImport("__Internal")]
        private static extern string flurryGetAgentVersion();

        [DllImport("__Internal")]
        private static extern void flurryGetReleaseVersion();

        [DllImport("__Internal")]
        private static extern string flurryGetSessionId();

        [DllImport("__Internal")]
        private static extern int flurryLogEvent(string eventId);

        [DllImport("__Internal")]
        private static extern int flurryLogTimedEvent(string eventId, bool isTimed);

        [DllImport("__Internal")]
        private static extern int flurryLogEventWithParameter(string eventName, string keys, string values);

        [DllImport("__Internal")]
        private static extern int flurryLogTimedEventWithParams(string eventId, string keys, string values, bool isTimed);

        [DllImport("__Internal")]
        private static extern void flurryEndTimedEvent(string eventId);

        [DllImport("__Internal")]
        private static extern void flurryEndTimedEventWithParams(string eventId, string keys, string values);
        
        [DllImport("__Internal")]
        private static extern int flurryLogStandardEventWithParameter(string eventName, string keys, string values);

        [DllImport("__Internal")]
        private static extern void flurryLogPageView();

        [DllImport("__Internal")]
        private static extern void flurryLogError(string errorId, string message, string errorClass);

        [DllImport("__Internal")]
        private static extern void flurryLogErrorWithParams(string errorId, string message, string errorClass, string keys, string values);

        [DllImport("__Internal")]
        private static extern void flurryLogBreadcrumb(string crashBreadcrumb);

        [DllImport("__Internal")]
        private static extern void flurryLogPayment(string productName, string productId, int quantity, double price,
                                                    string currency, string transactionId, string keys, string values);

        [DllImport("__Internal")]
        private static extern void flurrySetIAPReportingEnabled(bool isEnabled);

        [DllImport("__Internal")]
        private static extern void flurryUpdateConversionValue(int conversionValue);

        [DllImport("__Internal")]
        private static extern void flurryUpdateConversionValueWithEvent(int flurryEvent);

        [DllImport("__Internal")]
        private static extern void flurrySetUserPropertyValue(string propertyName, string propertyValue);

        [DllImport("__Internal")]
        private static extern void flurrySetUserPropertyValues(string propertyName, string propertyValues);

        [DllImport("__Internal")]
        private static extern void flurryAddUserPropertyValue(string propertyName, string propertyValue);

        [DllImport("__Internal")]
        private static extern void flurryAddUserPropertyValues(string propertyName, string propertyValues);

        [DllImport("__Internal")]
        private static extern void flurryRemoveUserPropertyValue(string propertyName, string propertyValue);

        [DllImport("__Internal")]
        private static extern void flurryRemoveUserPropertyValues(string propertyName, string propertyValues);

        [DllImport("__Internal")]
        private static extern void flurryRemoveUserProperty(string propertyName);

        [DllImport("__Internal")]
        private static extern void flurryFlagUserProperty(string propertyName);

        [DllImport("__Internal")]
        private static extern void flurryFetchPublisherSegmentation();

        [DllImport("__Internal")]
        private static extern void flurrySetPublisherSegmentationListener();

        [DllImport("__Internal")]
        private static extern string flurryGetPublisherData();

        [DllImport("__Internal")]
        private static extern void flurryRegisterOnFetchedCallback(IntPtr handler);

        [DllImport("__Internal")]
        private static extern void flurryRegisterOnPSFetchedCallback(IntPtr handler);

        [DllImport("__Internal")]
        private static extern void flurrySetConfigListener();   

        [DllImport("__Internal")]
        private static extern void flurryRegisterConfigCallback(IntPtr handler1, IntPtr handler2, IntPtr handler3, IntPtr handler4);

        [DllImport("__Internal")]
        private static extern void flurryConfigFetch();

        [DllImport("__Internal")]
        private static extern void flurryConfigActivate();

        [DllImport("__Internal")]
        private static extern string flurryConfigGetString(string key, string defaultValue);

        [DllImport("__Internal")]
        private static extern void flurryRegisterMessagingCallback(IntPtr handler1, IntPtr handler2);


        //declare method marked with delegate indicating this is a callback
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnFetched(string data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnPSFetched(string data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnConfigFetched();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnConfigFetchNoChange();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnConfigFetchFailed();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnConfigActivated();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnNotificationReceived(string title, string body, string sound, string data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnNotificationClicked(string title, string body, string sound, string data);


        public class AgentBuilderIOS : AgentBuilder
        {
            public AgentBuilderIOS()
            {
                initializeFlurrySessionBuilder();
            }

            public override void Build(string apiKey)
            {
                flurryStartSessionWithSessionBuilder(apiKey);
            }

            public override void WithCrashReporting(bool crashReporting)
            {
                flurryWithCrashReporting(crashReporting);
            }

            public override void WithGppConsent(string gppString, ISet<int> gppSectionIds)
            {
                Debug.Log("Flurry iOS SDK does not implement WithGppConsent method.");
            }

            public override void WithDataSaleOptOut(bool isOptOut)
            {
                flurryWithDataSaleOptOut(isOptOut);
            }

            public override void WithContinueSessionMillis(long sessionMillis)
            {
                //iOS uses seconds rather than milliseconds
                flurryWithSessionContinueSeconds(sessionMillis / 1000);
            }

            public override void WithIncludeBackgroundSessionsInMetrics(bool includeBackgroundSessionsInMetrics)
            {
                flurryWithIncludeBackgroundSessionsInMetrics(includeBackgroundSessionsInMetrics);
            }

            public override void WithLogEnabled(bool enableLog)
            {
                flurryWithLogEnabled(enableLog);
            }
             
            public override void WithLogLevel(FlurrySDK.Flurry.LogLevel logLevel)
            {
                flurryWithLogLevel((int)logLevel);
            }

            public override void WithReportLocation(bool reportLocation)
            {
                Debug.Log("This method is applied based on the user permissions of the app");
            }
             
            public override void WithAppVersion(string appVersion)
            {
                flurryWithAppVersion(appVersion);
            }

            public override void WithMessaging(bool enableMessaging, FlurrySDK.Flurry.IMessagingListener messagingListener)
            {
                if (enableMessaging){
                    if(messagingListener != null){

                        _messagingListener = messagingListener;

                        // create function ptr
                        OnNotificationReceived handler1 = new OnNotificationReceived(OnNotificationReceivedHandler);
                        IntPtr pointer1 = Marshal.GetFunctionPointerForDelegate(handler1);

                        OnNotificationClicked handler2 = new OnNotificationClicked(OnNotificationClickedHandler);
                        IntPtr pointer2 = Marshal.GetFunctionPointerForDelegate(handler2);

                        // call objC method to pass the ptr
                        flurryRegisterMessagingCallback(pointer1, pointer2);
                        flurrySetupMessagingWithAutoIntegration();
                    }
                }
            }

            public override void WithPerformanceMetrics(int performanceMetrics)
            {
                Debug.Log("Flurry iOS SDK does not implement WithPerformanceMetrics method.");
            }

            public override void WithSslPinningEnabled(bool sslPinningEnabled)
            {
                Debug.Log("Flurry iOS SDK does not implement WithSslPinningEnabled method.");
            }
        }

        public class AgentUserPropertiesIOS : AgentUserProperties
        {
            public override void Set(string propertyName, string propertyValue)
            {
                flurrySetUserPropertyValue(propertyName, propertyValue);
            }

            public override void Set(string propertyName, List<string> propertyValues)
            {
                string values;
                values = String.Join("\n", propertyValues);

                flurrySetUserPropertyValues(propertyName, values);
            }

            public override void Add(string propertyName, string propertyValue)
            {
                flurryAddUserPropertyValue(propertyName, propertyValue);
            }

            public override void Add(string propertyName, List<string> propertyValues)
            {
                string values;
                values = String.Join("\n", propertyValues);

                flurryAddUserPropertyValues(propertyName, values);
            }

            public override void Remove(string propertyName, string propertyValue)
            {
                flurryRemoveUserPropertyValue(propertyName, propertyValue);
            }

            public override void Remove(string propertyName, List<string> propertyValues)
            {
                string values;
                values = String.Join("\n", propertyValues);

                flurryRemoveUserPropertyValues(propertyName, values);
            }

            public override void Remove(string propertyName)
            {
                flurryRemoveUserProperty(propertyName);
            }

            public override void Flag(string propertyName)
            {
                flurryFlagUserProperty(propertyName);
            }
        }

        public class AgentPerformanceIOS : AgentPerformance
        {
            public override void ReportFullyDrawn()
            {
                Debug.Log("Flurry iOS SDK does not implement ReportFullyDrawn method.");
            }

            public override void StartResourceLogger()
            {
                Debug.Log("Flurry iOS SDK does not implement StartResourceLogger method.");
            }

            public override void LogResourceLogger(string id)
            {
                Debug.Log("Flurry iOS SDK does not implement LogResourceLogger method.");
            }
        }

        public class AgentConfigIOS : AgentConfig
        {
            static FlurrySDK.Flurry.IConfigListener _listener;

            public override void Fetch()
            {

                flurryConfigFetch();
            }

            public override void Activate()
            {
                flurryConfigActivate();
            }

            public override void SetListener(FlurrySDK.Flurry.IConfigListener configListener)
            {
                if (configListener != null)
                {
                    _listener = configListener;
                    // create function ptr for each callback
                    OnConfigFetched handler1 = new OnConfigFetched(onConfigFetchedHandler);
                    IntPtr pointer1 = Marshal.GetFunctionPointerForDelegate(handler1);

                    OnConfigFetchNoChange handler2 = new OnConfigFetchNoChange(onConfigFetchNoChangeHandler);
                    IntPtr pointer2 = Marshal.GetFunctionPointerForDelegate(handler2);

                    OnConfigFetchFailed handler3 = new OnConfigFetchFailed(onConfigFetchFailedHandler);
                    IntPtr pointer3 = Marshal.GetFunctionPointerForDelegate(handler3);

                    OnConfigActivated handler4 = new OnConfigActivated(onConfigActivatedHandler);
                    IntPtr pointer4 = Marshal.GetFunctionPointerForDelegate(handler4);

                    // call objC method to pass the ptr
                    flurryRegisterConfigCallback(pointer1, pointer2, pointer3, pointer4);
                    flurrySetConfigListener();
                }
            }

            public override string GetString(string key, string defaultValue)
            {
                string res = flurryConfigGetString(key, defaultValue);
                return res;
            }

            [MonoPInvokeCallback(typeof(OnConfigFetched))]
            static void onConfigFetchedHandler() 
            {
                Debug.Log("On config fetched.");
                if(_listener != null){
                    _listener.OnFetchSuccess();
                }

            }

            [MonoPInvokeCallback(typeof(OnConfigFetchNoChange))]
            static void onConfigFetchNoChangeHandler() 
            {
                Debug.Log("On Config fetch no change.");
                if(_listener != null){
                    _listener.OnFetchNoChange();
                }

            }

            [MonoPInvokeCallback(typeof(OnConfigFetchFailed))]
            static void onConfigFetchFailedHandler() 
            {
                Debug.Log("On config fetch failed.");
                if(_listener != null){
                    _listener.OnFetchError(false);
                }

            }

            [MonoPInvokeCallback(typeof(OnConfigActivated))]
            static void onConfigActivatedHandler() 
            {
                Debug.Log("On config activated.");
                if(_listener != null){
                    _listener.OnActivateComplete(true);
                }
            }
        }

        public class AgentPublisherSegmentationIOS : AgentPublisherSegmentation
        {
            static FlurrySDK.Flurry.IPublisherSegmentationListener _listener;

            public override void Fetch()
            {
                flurryFetchPublisherSegmentation();
            }

            public override void SetListener(FlurrySDK.Flurry.IPublisherSegmentationListener publisherSegmentationListener)
            {
                if (publisherSegmentationListener != null)
                {
                    _listener = publisherSegmentationListener;
                    // create function ptr
                    OnPSFetched handler = new OnPSFetched(OnPSFetchedHandler);
                    IntPtr pointer = Marshal.GetFunctionPointerForDelegate(handler);
                    // call objC method to pass the ptr
                    flurryRegisterOnPSFetchedCallback(pointer);
                    flurrySetPublisherSegmentationListener();
                }
            }

            public override IDictionary<string, string> GetData()
            {
                string rawString = flurryGetPublisherData();
                IDictionary<string, string> map = new Dictionary<string, string>();
                ToDictionary(rawString, out map);
                return map;
            }

            //Implement callback marked MonoPInvokeCallback lets objC callback using function ptr
            [MonoPInvokeCallback(typeof(OnPSFetched))]
            static void OnPSFetchedHandler(string data)
            {
                Debug.Log("OnFetched Data - " + data );
                IDictionary<string, string> map = new Dictionary<string, string>();
                ToDictionary(data, out map);
                if(_listener != null){
                    _listener.OnFetched(map);
                }

            }

            private static void ToDictionary(string rawString, out IDictionary<string, string> dictionary){
                IDictionary<string, string> d = new Dictionary<string, string>();
                string[] pairs = rawString.Split(';');
                foreach (var pair in pairs){
                    string[] components = pair.Split(':');
                    string key = components[0];
                    string val = components[1];
                    d.Add(key, val);
                }
                dictionary = d;
            }

        }

        public override void SetContinueSessionMillis(long sessionMillis)
        {
            flurrySetSessionContinueSeconds(sessionMillis / 1000);
        }

        public override void SetCrashReporting(bool crashReporting)
        {
            Debug.Log("Flurry iOS SDK does not implement SetCrashReporting method.");
        }

        public override void SetIncludeBackgroundSessionsInMetrics(bool includeBackgroundSessionsInMetrics)
        {
            flurrySetIncludeBackgroundSessionsInMetrics(includeBackgroundSessionsInMetrics);
        }

        public override void SetLogEnabled(bool enableLog)
        {
            Debug.Log("Flurry iOS SDK does not implement SetLogEnabled method.");
        }

        public override void SetLogLevel(FlurrySDK.Flurry.LogLevel logLevel)
        {
            Debug.Log("Flurry iOS SDK does not implement SetLogLevel method.");
        }

        public override void SetSslPinningEnabled(bool sslPinningEnabled)
        {
            Debug.Log("Flurry iOS SDK does not implement SetSslPinningEnabled method.");
        }

        public override void SetAge(int age)
        {
           flurrySetAge(age);
        }

        public override void SetGender(FlurrySDK.Flurry.Gender gender)
        {
            if (gender == FlurrySDK.Flurry.Gender.Male)
            {
                flurrySetGender("m");
            }
            else if (gender == FlurrySDK.Flurry.Gender.Female)
            {
                flurrySetGender("f");
            }
        }

        public override void SetReportLocation(bool reportLocation)
        {
            Debug.Log("This method is applied based on the user permissions of the app");
        }

        public override void SetSessionOrigin(string originName, string deepLink)
        {
             flurrySetSessionOrigin(originName, deepLink);
        }

        public override void SetUserId(string userId)
        {
           flurrySetUserId(userId);
        }

        public override void SetVersionName(string versionName)
        {
            flurrySetVersionName(versionName);
        }

        public override void AddOrigin(string originName, string originVersion)
        {
              flurryAddOrigin(originName, originVersion);
        }

        public override void AddOrigin(string originName, string originVersion, IDictionary<string, string> originParameters)
        {
            string keys, values;
            ToKeyValue(originParameters, out keys, out values);
            flurryAddOriginWithParams(originName, originVersion, keys, values);
        }

        public override void AddSessionProperty(string name, string value)
        {
            flurryAddSessionProperty(name, value);
        }

        public override bool SetGppConsent(string gppString, ISet<int> gppSectionIds)
        {
            Debug.Log("Flurry iOS SDK does not implement SetGppConsent method.");
            return false;
        }

        public override void SetDataSaleOptOut(bool isOptOut)
        {
           flurrySetDataSaleOptOut(isOptOut);
        }

        public override void DeleteData()
        {
            flurrySetDelete();
        }

        public override void OpenPrivacyDashboard()
        {
            flurryOpenPrivacyDashboard();
        }

        public override int GetAgentVersion()
        {
            string agentVersionStr = flurryGetAgentVersion();
            int agentVersion = 0;

            Int32.TryParse(agentVersionStr, out agentVersion);
            return agentVersion;
        }

        public override string GetReleaseVersion()
        {
            Debug.Log("Flurry iOS SDK does not implement getReleaseVersion method.");
            return "1.0";
        }

        public override string GetSessionId()
        {
            return flurryGetSessionId();
        }

        public override int LogEvent(string eventId)
        {
            return (int) flurryLogEvent(eventId);
        }

        public override int LogEvent(string eventId, bool timed)
        {
            return (int) flurryLogTimedEvent(eventId, timed);
        }

        public override int LogEvent(string eventId, IDictionary<string, string> parameters)
        {
            string keys, values;
            ToKeyValue(parameters, out keys, out values);

            return (int) flurryLogEventWithParameter(eventId, keys, values);
        }

        public override int LogEvent(string eventId, IDictionary<string, string> parameters, bool timed)
        {
            string keys, values;
            ToKeyValue(parameters, out keys, out values);
            return (int) flurryLogTimedEventWithParams(eventId, keys, values, timed);
        }

        public override void EndTimedEvent(string eventId)
        {
            flurryEndTimedEvent(eventId);
        }

        public override void EndTimedEvent(string eventId, IDictionary<string, string> parameters)
        {
            string keys, values;
            ToKeyValue(parameters, out keys, out values);
            flurryEndTimedEventWithParams(eventId, keys, values);
        }

        public override int LogEvent(FlurrySDK.Flurry.Event eventId, FlurrySDK.Flurry.EventParams parameters)
        {
            string nativeEventId = eventId.ToString();
            IDictionary<string, string> newParameters = new Dictionary<string, string>();
            if (parameters != null)
            {
                IDictionary<object, string> dictionary = parameters.GetParams();
                foreach (KeyValuePair<object, string> pair in dictionary)
                {
                    string nativeEventParamValue = pair.Value;
                    string nativeEventParamKey;
                    if (pair.Key is FlurrySDK.Flurry.EventParamBase)
                    {
                        nativeEventParamKey = pair.Key.ToString();
                    }
                    else
                    {
                        nativeEventParamKey = (string) pair.Key;
                    }
                    newParameters.Add(nativeEventParamKey, nativeEventParamValue);
                }
            }
            string keys, values;
            ToKeyValue(newParameters, out keys, out values);
            return (int) flurryLogStandardEventWithParameter(nativeEventId, keys, values);
        }

        public override void OnPageView()
        {
            flurryLogPageView();
        }

        public override void OnError(string errorId, string message, string errorClass)
        {
           flurryLogError(errorId, message, errorClass);
        }

        public override void OnError(string errorId, string message, string errorClass, IDictionary<string, string> parameters)
        {
            string keys, values;
            ToKeyValue(parameters, out keys, out values);
            flurryLogErrorWithParams(errorId, message, errorClass, keys, values);
        }

        public override void LogBreadcrumb(string crashBreadcrumb)
        {
            flurryLogBreadcrumb(crashBreadcrumb);
        }

        public override int LogPayment(string productName, string productId, int quantity, double price,
                                       string currency, string transactionId, IDictionary<string, string> parameters)
        {
            string keys, values;
            ToKeyValue(parameters, out keys, out values);
            flurryLogPayment(productName, productId, quantity, price, currency, transactionId, keys, values);
            return 1;
        }

        public override void SetIAPReportingEnabled(bool enableIAP)
        {
            flurrySetIAPReportingEnabled(enableIAP);
        }

        public override void UpdateConversionValue(int conversionValue)
        {
           flurryUpdateConversionValue(conversionValue);
        }

        public override void UpdateConversionValueWithEvent(FlurrySDK.Flurry.SKAdNetworkEvent flurryEvent)
        {
           flurryUpdateConversionValueWithEvent((int)flurryEvent);
        }

        [Obsolete("please use Builder().WithMessaging() instead of SetMessagingListener()")]
        public override void SetMessagingListener(FlurrySDK.Flurry.IMessagingListener messagingListener)
        {
            if(messagingListener != null){

                _messagingListener = messagingListener;

                // create function ptr
                OnNotificationReceived handler1 = new OnNotificationReceived(OnNotificationReceivedHandler);
                IntPtr pointer1 = Marshal.GetFunctionPointerForDelegate(handler1);

                OnNotificationClicked handler2 = new OnNotificationClicked(OnNotificationClickedHandler);
                IntPtr pointer2 = Marshal.GetFunctionPointerForDelegate(handler2);

                // call objC method to pass the ptr
                flurryRegisterMessagingCallback(pointer1, pointer2);
                flurrySetupMessagingWithAutoIntegration();
            }
        }

        [MonoPInvokeCallback(typeof(OnNotificationReceived))]
        static void OnNotificationReceivedHandler(string title, string body, string sound, string data) 
        {

            IDictionary<string, string> appData = new Dictionary<string, string>();
            ToDictionary(data, out appData);

            FlurrySDK.Flurry.FlurryMessage message = new FlurrySDK.Flurry.FlurryMessage
            {
                Title = title,
                Body = body,
                ClickAction = sound,
                Data = appData,
            };
            
            if(_messagingListener != null){
                _messagingListener.OnNotificationReceived(message);
            }
        }

        [MonoPInvokeCallback(typeof(OnNotificationClicked))]
        static void OnNotificationClickedHandler(string title, string body, string sound, string data) 
        {
            IDictionary<string, string> appData = new Dictionary<string, string>();
            ToDictionary(data, out appData);

            FlurrySDK.Flurry.FlurryMessage message = new FlurrySDK.Flurry.FlurryMessage
            {
                Title = title,
                Body = body,
                ClickAction = sound,
                Data = appData,
            };
            
            if(_messagingListener != null){
                _messagingListener.OnNotificationClicked(message);
            }
        }


        [Obsolete("please use PublisherSegmentation.GetData() instead of GetPublisherSegmentation()")]
        public override IDictionary<string, string> GetPublisherSegmentation()
        {
            string rawString = flurryGetPublisherData();
            IDictionary<string, string> map = new Dictionary<string, string>();
            ToDictionary(rawString, out map);
            return map;
        }

        [Obsolete("please use PublisherSegmentation.Fetch() instead of FetchPublisherSegmentation()")]
        public override void FetchPublisherSegmentation()
        {
            flurryFetchPublisherSegmentation();
        }

        [Obsolete("please use PublisherSegmentation.RegisterListener() instead of SetPublisherSegmentationListener()")]
        public override void SetPublisherSegmentationListener(FlurrySDK.Flurry.IFlurryPublisherSegmentationListener publisherSegmentationListener)
        {
            _publisherSegmentationListener = publisherSegmentationListener;
            // create function ptr
            OnFetched handler = new OnFetched(onFetchedHandler);
            IntPtr pointer = Marshal.GetFunctionPointerForDelegate(handler);
            // call objC method to pass the ptr
            flurryRegisterOnFetchedCallback(pointer);
            flurrySetPublisherSegmentationListener();
        }

        //Implement callback marked MonoPInvokeCallback lets objC callback using function ptr
        [MonoPInvokeCallback(typeof(OnFetched))]
        static void onFetchedHandler(string data) 
        {
            Debug.Log("OnFetched Data - " + data );
            IDictionary<string, string> map = new Dictionary<string, string>();
            ToDictionary(data, out map);
            if(_publisherSegmentationListener != null){
                _publisherSegmentationListener.OnFetched(map);
            }

        }

        public override void Dispose() { }

        private static void ToKeyValue(IDictionary<string, string> dictionary, out string keys, out string values)
        {
            var keysBuilder = new StringBuilder();
            var valuesBuilder = new StringBuilder();
            int i = 0;
            int length = dictionary.Count;
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                keysBuilder.Append(pair.Key);
                valuesBuilder.Append(pair.Value);
                if (++i < length)
                {
                    keysBuilder.Append("\n");
                    valuesBuilder.Append("\n");
                }
            }
            keys = keysBuilder.ToString();
            values = valuesBuilder.ToString();
        }

        private static void ToDictionary(string rawString, out IDictionary<string, string> dictionary){
            IDictionary<string, string> d = new Dictionary<string, string>();
            string[] pairs = rawString.Split(';');
            foreach (var pair in pairs){
                string[] components = pair.Split(':');
                string key = components[0];
                string val = components[1];
                d.Add(key, val);
            }
            dictionary = d;
        }
    }
}
#endif
