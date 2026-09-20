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
using UnityEngine;

using FlurrySDKInternal;

namespace FlurrySDK
{
    /// <summary>
    /// A Unity plugin for Flurry SDK.
    /// The Flurry agent allows you to track the usage and behavior of your application
    /// on users' devices for viewing in the Flurry Analytics system.
    /// Set of methods that allow developers to capture detailed, aggregate information
    /// regarding the use of their app by end users.
    /// </summary>
    public partial class Flurry : IDisposable
    {
        // init static Flurry agent object.
        private static FlurryAgent flurryAgent;
        static Flurry()
        {
#if UNITY_ANDROID
            if (Application.platform == RuntimePlatform.Android)
            {
                flurryAgent = new FlurryAgentAndroid();
            }
#elif UNITY_IOS || UNITY_IPHONE
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                flurryAgent = new FlurryAgentIOS();
            }
#else
            flurryAgent = null;
#endif
        }

        /// <summary>
        /// Builder Pattern class for Flurry
        /// </summary>
        public class Builder
        {
            private FlurryAgent.AgentBuilder builder;

            public Builder()
            {
#if UNITY_ANDROID
                if (Application.platform == RuntimePlatform.Android)
                {
                    builder = new FlurryAgentAndroid.AgentBuilderAndroid();
                }
#elif UNITY_IOS || UNITY_IPHONE
                if (Application.platform == RuntimePlatform.IPhonePlayer)
                {
                    builder = new FlurryAgentIOS.AgentBuilderIOS();
                }
#else
                builder = null;
#endif
            }

            public void Build(string apiKey)
            {
                if (builder != null)
                {
                    builder.Build(apiKey);
                }
            }

            /// <summary>
            /// True to enable or false to disable the ability to catch all uncaught exceptions and have them reported back to Flurry.
            /// </summary>
            /// <returns>The builder.</returns>
            /// <param name="crashReporting">If set to <c>true</c> to enable crash reporting.</param>
            public Builder WithCrashReporting(bool crashReporting = true)
            {
                if (builder != null)
                {
                    builder.WithCrashReporting(crashReporting);
                }
                return this;
            }

            /// <summary>
            /// Set Flurry Consent for the IAB Global Privacy Platform (GPP). To pass an IAB string to Flurry.
            /// </summary>
            /// <returns>The builder.</returns>
            /// <param name="gppString">IAB GPP String.</param>
            /// <param name="gppSectionIds">Integer set of IAB GPP section ids that are applicable for this bid request.</param>
            public Builder WithGppConsent(string gppString, ISet<int> gppSectionIds)
            {
                if (builder != null)
                {
                    builder.WithGppConsent(gppString, gppSectionIds);
                }
                return this;
            }

            /// <summary>
            /// An api to send ccpa compliance data to Flurry on the user's choice to opt out or opt in to data sale to third parties. The default is false
            /// </summary>
            /// <returns>The builder.</returns>
            /// <param name="isOptOut">If set to <c>true</c> user is opted out of data sale to third parties for CCPA.</param>
            public Builder WithDataSaleOptOut(bool isOptOut)
            {
                if (builder != null)
                {
                    builder.WithDataSaleOptOut(isOptOut);
                }
                return this;
            }

            /// <summary>
            /// Set the timeout for expiring a Flurry session.
            /// </summary>
            /// <returns>The builder.</returns>
            /// <param name="sessionMillis">Session timeout millis.</param>
            public Builder WithContinueSessionMillis(long sessionMillis = 10000)
            {
                if (builder != null)
                {
                    builder.WithContinueSessionMillis(sessionMillis);
                }
                return this;
            }

            /// <summary>
            /// True if this session should be added to total sessions/DAUs when applicationstate is inactive or background.
            /// </summary>
            /// <returns>The builder.</returns>
            /// <param name="includeBackgroundSessionsInMetrics">If set to <c>true</c> to include background sessions in metrics.</param>
            public Builder WithIncludeBackgroundSessionsInMetrics(bool includeBackgroundSessionsInMetrics = true)
            {
                if (builder != null)
                {
                    builder.WithIncludeBackgroundSessionsInMetrics(includeBackgroundSessionsInMetrics);
                }
                return this;
            }

            /// <summary>
            /// True to enable or false to disable the internal logging for the Flurry SDK.
            /// </summary>
            /// <returns>The builder.</returns>
            /// <param name="enableLog">If set to <c>true</c> to enable log.</param>
            public Builder WithLogEnabled(bool enableLog = true)
            {
                if (builder != null)
                {
                    builder.WithLogEnabled(enableLog);
                }
                return this;
            }

            /// <summary>
            /// Set the log level of the internal Flurry SDK logging.
            /// </summary>
            /// <returns>The builder.</returns>
            /// <param name="logLevel">Log level.</param>
            public Builder WithLogLevel(LogLevel logLevel = LogLevel.WARN)
            {
                if (builder != null)
                {
                    builder.WithLogLevel(logLevel);
                }
                return this;
            }

            /// <summary>
            /// True to enable or false to disable Location report. Defaults to false.
            /// </summary>
            /// <returns>The builder.</returns>
            /// <param name="reportLocation">If set to <c>true</c> to enable Location report.</param>
            public Builder WithReportLocation(bool reportLocation = true)
            {
                if (builder != null)
                {
                    builder.WithReportLocation(reportLocation);
                }
                return this;
            }

            /// <summary>
            /// Enable Flurry add-on Messaging.
            /// </summary>
            /// <returns>The builder.</returns>
            /// <param name="enableMessaging">If set to <c>true</c> to enable messaging.</param>
            public Builder WithMessaging(bool enableMessaging = true, IMessagingListener messagingListener = null)
            {
                if (builder != null)
                {
                    builder.WithMessaging(enableMessaging, messagingListener);
                }
                return this;
            }

            /// <summary>
            /// Sets the app version.
            /// </summary>
            /// <returns>The builder.</returns>
            /// <param name="appVersion">App version name string</param>
            public Builder WithAppVersion(string appVersion)
            {
                if (builder != null)
                {
                    builder.WithAppVersion(appVersion);
                }
                return this;
            }

            /// <summary>
            /// Set flags for performance metrics.
            /// </summary>
            /// <returns>The builder.</returns>
            /// <param name="performanceMetrics">Flags for performance metrics</param>
            public Builder WithPerformanceMetrics(int performanceMetrics)
            {
                if (builder != null)
                {
                    builder.WithPerformanceMetrics(performanceMetrics);
                }
                return this;
            }

            /// <summary>
            /// True to enable or false to disable SSL Pinning for Flurry Analytics connection.Defaults to false.
            /// Turn on to add SSL Pinning protection for the Flurry Analytics connections. Disable it
            /// if your app is using proxy or any services that are not compliant with SSL Pinning.
            /// </summary>
            /// <returns>The builder.</returns>
            /// <param name="sslPinningEnabled">true to enable SSL Pinning for Flurry Analytics connection, false to disable it.</param>
            public Builder WithSslPinningEnabled(bool sslPinningEnabled)
            {
                if (builder != null)
                {
                    builder.WithSslPinningEnabled(sslPinningEnabled);
                }
                return this;
            }
        }

        /// <summary>
        /// User Properties class for Flurry
        /// </summary>
        public class UserProperties
        {
            public static string PROPERTY_CURRENCY_PREFERENCE = "Flurry.CurrencyPreference";
            public static string PROPERTY_PURCHASER =           "Flurry.Purchaser";
            public static string PROPERTY_REGISTERED_USER =     "Flurry.RegisteredUser";
            public static string PROPERTY_SUBSCRIBER =          "Flurry.Subscriber";

            // init static Flurry agent UserProperties object.
            private static FlurryAgent.AgentUserProperties userProperties;
            static UserProperties()
            {
#if UNITY_ANDROID
                if (Application.platform == RuntimePlatform.Android)
                {
                    userProperties = new FlurryAgentAndroid.AgentUserPropertiesAndroid();
                }
#elif UNITY_IOS || UNITY_IPHONE
                if (Application.platform == RuntimePlatform.IPhonePlayer)
                {
                    userProperties = new FlurryAgentIOS.AgentUserPropertiesIOS();
                }
#else
                userProperties = null;
#endif
            }

            /// <summary>
            /// <br>Exactly set, or replace if any previously exists, any state for the property. </br>
            /// <br>null clears the property state. </br>
            /// </summary>
            /// <param name="propertyName">Property name.</param>
            /// <param name="propertyValue">Single property value.</param>
            public static void Set(string propertyName, string propertyValue)
            {
                if (userProperties != null)
                {
                    userProperties.Set(propertyName, propertyValue);
                }
            }

            /// <summary>
            /// <br>Exactly set, or replace if any previously exists, any state for the property. </br>
            /// <br>Empty list or null clears the property state. </br>
            /// </summary>
            /// <param name="propertyName">Property name.</param>
            /// <param name="propertyValues">List of property values.</param>
            public static void Set(string propertyName, List<string> propertyValues)
            {
                if (userProperties != null)
                {
                    userProperties.Set(propertyName, propertyValues);
                }
            }

            /// <summary>
            /// <br>Extend any property, even no previous property. </br>
            /// <br>Adding values already included in the state has no effect and does not error. </br>
            /// </summary>
            /// <param name="propertyName">Property name.</param>
            /// <param name="propertyValue">Single property value.</param>
            public static void Add(string propertyName, string propertyValue)
            {
                if (userProperties != null)
                {
                    userProperties.Add(propertyName, propertyValue);
                }
            }

            /// <summary>
            /// <br>Extend any property, even no previous property. </br>
            /// <br>Adding values already included in the state has no effect and does not error. </br>
            /// </summary>
            /// <param name="propertyName">Property name.</param>
            /// <param name="propertyValues">List of property values.</param>
            public static void Add(string propertyName, List<string> propertyValues)
            {
                if (userProperties != null)
                {
                    userProperties.Add(propertyName, propertyValues);
                }
            }

            /// <summary>
            /// <br>Reduce any property. </br>
            /// <br>Removing values not already included in the state has no effect and does not error </br>
            /// </summary>
            /// <param name="propertyName">Property name.</param>
            /// <param name="propertyValue">Single property value.</param>
            public static void Remove(string propertyName, string propertyValue)
            {
                if (userProperties != null)
                {
                    userProperties.Remove(propertyName, propertyValue);
                }
            }

            /// <summary>
            /// <br>Reduce any property. </br>
            /// <br>Removing values not already included in the state has no effect and does not error </br>
            /// </summary>
            /// <param name="propertyName">Property name.</param>
            /// <param name="propertyValues">List of property values.</param>
            public static void Remove(string propertyName, List<string> propertyValues)
            {
                if (userProperties != null)
                {
                    userProperties.Remove(propertyName, propertyValues);
                }
            }

            /// <summary>
            /// <br>Exactly set, or replace if any previously exists, any state for the property to be empty. </br>
            /// </summary>
            /// <param name="propertyName">Property name.</param>
            public static void Remove(string propertyName)
            {
                if (userProperties != null)
                {
                    userProperties.Remove(propertyName);
                }
            }

            /// <summary>
            /// <br>Exactly set, or replace if any previously exists, any state for the property to a single true state. </br>
            /// <br>Implies that value is boolean and should only be flagged and cleared. </br>
            /// </summary>
            /// <param name="propertyName">Property name.</param>
            public static void Flag(string propertyName)
            {
                if (userProperties != null)
                {
                    userProperties.Flag(propertyName);
                }
            }
        }

        /// <summary>
        /// Performance class for Flurry
        /// </summary>
        public class Performance
        {
            public static int NONE        = 0;
            public static int COLD_START  = 1;
            public static int SCREEN_TIME = 2;
            public static int ALL         = 1 | 2;

            // init static Flurry agent PerformanceMetrics object.
            private static FlurryAgent.AgentPerformance performance;
            static Performance()
            {
#if UNITY_ANDROID
                if (Application.platform == RuntimePlatform.Android)
                {
                    performance = new FlurryAgentAndroid.AgentPerformanceAndroid();
                }
#elif UNITY_IOS || UNITY_IPHONE
                if (Application.platform == RuntimePlatform.IPhonePlayer)
                {
                    performance = new FlurryAgentIOS.AgentPerformanceIOS();
                }
#else
                performance = null;
#endif
            }

            /// <summary>
            /// Report to the Flurry Cold Start metrics that your app is now fully drawn.
            /// This is only used to help measuring application launch times, so that the
            /// app can report when it is fully in a usable state similar to
            /// {@link android.app.Activity#reportFullyDrawn}.
            /// </summary>
            public static void ReportFullyDrawn()
            {
                if (performance != null)
                {
                    performance.ReportFullyDrawn();
                }
            }

            /// <summary>
            /// Provide a Resource logger that users can start before profiled codes start,
            /// then log event after finished. Flurry will compute the time.
            ///
            /// <example>e.g.
            /// <code>
            ///   Flurry.Performance.StartResourceLogger();
            ///   {
            ///       // profiled codes ...
            ///   }
            ///   Flurry.Performance.LogResourceLogger("My ID");
            /// </code>
            /// </example>
            /// </summary>
            public static void StartResourceLogger()
            {
                if (performance != null)
                {
                    performance.StartResourceLogger();
                }
            }

            /// <summary>
            /// Log Flurry Resources Consuming events.
            /// </summary>
            /// <param name="id">The group ID.</param>
            public static void LogResourceLogger(string id)
            {
                if (performance != null)
                {
                    performance.LogResourceLogger(id);
                }
            }
        }

        /// <summary>
        /// Flurry Config
        /// </summary>
        public class Config
        {
            // init static Flurry Config object.
            private static FlurryAgent.AgentConfig config;
            private static List<IConfigListener> listeners = new List<IConfigListener>();
            private static IConfigListener mainListener = null;
            static Config()
            {
#if UNITY_ANDROID
                if (Application.platform == RuntimePlatform.Android)
                {
                    config = new FlurryAgentAndroid.AgentConfigAndroid();
                }
#elif UNITY_IOS || UNITY_IPHONE
                if (Application.platform == RuntimePlatform.IPhonePlayer)
                {
                    config = new FlurryAgentIOS.AgentConfigIOS();
                }
#else
                config = null;
#endif
            }

            // The internal Config listener.
            private class MainConfigListener : IConfigListener
            {
                public void OnFetchSuccess()
                {
                    foreach (var listener in listeners)
                    {
                        listener.OnFetchSuccess();
                    }
                }

                public void OnFetchNoChange()
                {
                    foreach (var listener in listeners)
                    {
                        listener.OnFetchNoChange();
                    }
                }

                public void OnFetchError(bool isRetrying)
                {
                    foreach (var listener in listeners)
                    {
                        listener.OnFetchError(isRetrying);
                    }
                }

                public void OnActivateComplete(bool isCache)
                {
                    foreach (var listener in listeners)
                    {
                        listener.OnActivateComplete(isCache);
                    }
                }
            }

            /// <summary>
            /// Fetch Flurry Config.
            /// </summary>
            public static void Fetch()
            {
                if (config != null)
                {
                    config.Fetch();
                }
            }

            /// <summary>
            /// Activate Flurry Config data.
            /// </summary>
            public static void Activate()
            {
                if (config != null)
                {
                    config.Activate();
                }
            }

            /// <summary>
            /// Registere Flurry Config listener.
            /// </summary>
            /// <param name="configListener">The Flurry Config listener.</param>
            public static void RegisterListener(IConfigListener configListener)
            {
                if (config != null)
                {
                    listeners.Add(configListener);
                    if (mainListener == null)
                    {
                        mainListener = new MainConfigListener();
                        config.SetListener(mainListener);
                    }
                }
            }

            /// <summary>
            /// Unregistere Flurry Config listener.
            /// </summary>
            /// <param name="configListener">The Flurry Config listener.</param>
            public static void UnregisterListener(IConfigListener configListener)
            {
                if (config != null)
                {
                    listeners.Remove(configListener);
                }
            }

            /// <summary>
            /// Get Flurry Config string.
            /// </summary>
            /// <param name="key">The Flurry Config key.</param>
            /// <param name="defaultValue">The Flurry Config default value.</param>
            public static string GetString(string key, string defaultValue)
            {
                if (config != null)
                {
                    return config.GetString(key, defaultValue);
                }

                return null;
            }
        }

        /// <summary>
        /// Listener to be notified when the Flurry Config data have been fetched or activatede.
        /// </summary>
        public interface IConfigListener
        {
            /// <summary>
            /// Config data is successfully loaded from server.
            /// </summary>
            void OnFetchSuccess();

            /// <summary>
            /// Fetch completes but no changes from server.
            /// </summary>
            void OnFetchNoChange();

            /// <summary>
            /// Config data is failed to load from server.
            /// Flurry Config will retry if failed in 10 sec., 30 sec., 3 min., then abandon.
            /// </summary>
            /// <param name="isRetrying">true if it is still retrying fetching.</param>
            void OnFetchError(bool isRetrying);

            /// <summary>
            /// Config data is activated.
            /// Flurry Config can receive activate notification when cached data is read,
            /// and when newly fetched data is been activated.
            /// </summary>
            /// <param name="isCache">Ftrue if activated from the cached data.</param>
            void OnActivateComplete(bool isCache);

        }

        /// <summary>
        /// Flurry message.
        /// </summary>
        public class FlurryMessage
        {
            public string Title;
            public string Body;
            public string ClickAction;
            public IDictionary<string, string> Data;
        }

        /// <summary>
        /// If listener is set, Flurry will call this method to notify you a notification has been received.
        /// </summary>
        public interface IMessagingListener
        {
            /// <summary>
            /// If listener is set, Flurry will call this method to notify you
            /// a notification has been received. If you would like to handle
            /// the notification yourself, be sure to return true to notify
            /// Flurry you've handled it. If you return false, Flurry will continue with
            /// default behavior, which is show the notification if app is in background,
            /// and do nothing if app is in foreground.
            /// </summary>
            /// <returns><c>true</c>, if you've handled the notification. <c>false</c> if you haven't and want Flurry to handle it.</returns>
            /// <param name="message">Message.</param>
            bool OnNotificationReceived(FlurryMessage message);

            /// <summary>
            /// If listener is set, Flurry will call this method to notify you
            /// a notification has been clicked. If you would like to handle
            /// the UI navigation yourself, be sure to return true to notify
            /// Flurry you've handled it.  If you return false, Flurry will continue with
            /// default behavior, which is launch the app or "click_action" activity.
            /// </summary>
            /// <returns><c>true</c>, if you've handled the notification. <c>false</c> if you haven't and want Flurry to handle it.</returns>
            /// <param name="message">Message.</param>
            bool OnNotificationClicked(FlurryMessage message);

            /// <summary>
            /// If listener is set, Flurry will notify you if user has cancelled/dismissed the notification.
            /// </summary>
            /// <returns><c>true</c>, if you've handled the notification. <c>false</c> if you haven't and want Flurry to handle it.</returns>
            /// <param name="message">Message.</param>
            void OnNotificationCancelled(FlurryMessage message);

            /// <summary>
            /// If listener is set, Flurry will notify you if push notification token has been changed.
            /// </summary>
            /// <param name="token">Token.</param>
            void OnTokenRefresh(string token);

            /// <summary>
            /// If listener is set, Flurry will notify you when a notification
            /// has been received that was not sent from Flurry. Based on the various
            /// push providers you have integrated, you may cast the Object to the appropriate type.
            /// </summary>
            /// <param name="nonFlurryMessage">Non flurry message.</param>
            void OnNonFlurryNotificationReceived(IDisposable nonFlurryMessage);

        }

        /// <summary>
        /// If listener is set, Flurry will call this method to notify you a notification has been received.
        /// </summary>
        [Obsolete("please use IMessagingListener instead of IFlurryMessagingListener")]
        public interface IFlurryMessagingListener : IMessagingListener
        {
        }

        /// <summary>
        /// Flurry Publisher Segmentation
        /// </summary>
        public class PublisherSegmentation
        {
            // init static Flurry Publisher Segmentation object.
            private static FlurryAgent.AgentPublisherSegmentation publisherSegmentation;
            private static List<IPublisherSegmentationListener> listeners = new List<IPublisherSegmentationListener>();
            private static IPublisherSegmentationListener mainListener = null;
            static PublisherSegmentation()
            {
#if UNITY_ANDROID
                if (Application.platform == RuntimePlatform.Android)
                {
                    publisherSegmentation = new FlurryAgentAndroid.AgentPublisherSegmentationAndroid();
                }
#elif UNITY_IOS || UNITY_IPHONE
                if (Application.platform == RuntimePlatform.IPhonePlayer)
                {
                    publisherSegmentation = new FlurryAgentIOS.AgentPublisherSegmentationIOS();
                }
#else
                publisherSegmentation = null;
#endif
            }

            // The internal Publisher Segmentation listener.
            private class MainPublisherSegmentationListener : IPublisherSegmentationListener
            {
                public void OnFetched(IDictionary<string, string> data)
                {
                    foreach (var listener in listeners)
                    {
                        listener.OnFetched(data);
                    }
                }
            }

            /// <summary>
            /// Fetch Publisher Segmentation data.
            /// </summary>
            public static void Fetch()
            {
                if (publisherSegmentation != null)
                {
                    publisherSegmentation.Fetch();
                }
            }

            /// <summary>
            /// Registere Flurry Publisher Segmentation listener.
            /// </summary>
            /// <param name="publisherSegmentationListener">The Flurry Publisher Segmentation listener.</param>
            public static void RegisterListener(IPublisherSegmentationListener publisherSegmentationListener)
            {
                if (publisherSegmentation != null)
                {
                    listeners.Add(publisherSegmentationListener);
                    if (mainListener == null)
                    {
                        mainListener = new MainPublisherSegmentationListener();
                        publisherSegmentation.SetListener(mainListener);
                    }
                }
            }

            /// <summary>
            /// Unregistere Flurry Publisher Segmentation listener.
            /// </summary>
            /// <param name="publisherSegmentationListener">The Flurry Publisher Segmentation listener.</param>
            public static void UnregisterListener(IPublisherSegmentationListener publisherSegmentationListener)
            {
                if (publisherSegmentation != null)
                {
                    listeners.Remove(publisherSegmentationListener);
                }
            }

            /// <summary>
            /// Get Publisher Segmentation data without fetch; cached or newly fetched.
            /// </summary>
            public static IDictionary<string, string> GetData()
            {
                if (publisherSegmentation != null)
                {
                    return publisherSegmentation.GetData();
                }

                return null;
            }
        }

        /// <summary>
        /// Listener to be notified when the Publisher Segmentation data have been fetched and ready to use.
        /// </summary>
        public interface IPublisherSegmentationListener
        {
            /// <summary>
            /// Publisher Segmentation data is fetched and ready to use.
            /// </summary>
            /// <param name="data">Fetched data.</param>
            void OnFetched(IDictionary<string, string> data);

        }

        /// <summary>
        /// Listener to be notified when the Publisher Segmentation data have been fetched and ready to use.
        /// </summary>
        [Obsolete("please use IPublisherSegmentationListener instead of IFlurryPublisherSegmentationListener")]
        public interface IFlurryPublisherSegmentationListener : IPublisherSegmentationListener
        {
        }

        /// <summary>
        /// Set the timeout for expiring a Flurry session.
        /// </summary>
        /// <param name="sessionMillis"> The time in milliseconds to set the session timeout to. Minimum value of 5000.</param>
        public static void SetContinueSessionMillis(long sessionMillis)
        {
            if (flurryAgent != null)
            {
                flurryAgent.SetContinueSessionMillis(sessionMillis);
            }
        }

        /// <summary>
        /// True to enable or false to disable the ability to catch all uncaught exceptions
        /// and have them reported back to Flurry.
        /// </summary>
        /// <param name="crashReporting"> True to enable, false to disable.</param>
        public static void SetCrashReporting(bool crashReporting)
        {
            if (flurryAgent != null)
            {
                flurryAgent.SetCrashReporting(crashReporting);
            }
        }

        /// <summary>
        /// True if this session should be added to total sessions/DAUs when applicationstate is inactive or background.
        /// </summary>
        /// <param name="includeBackgroundSessionsInMetrics"> If background and inactive session should be counted toward dau</param>
        public static void SetIncludeBackgroundSessionsInMetrics(bool includeBackgroundSessionsInMetrics)
        {
            if (flurryAgent != null)
            {
                flurryAgent.SetIncludeBackgroundSessionsInMetrics(includeBackgroundSessionsInMetrics);
            }
        }

        /// <summary>
        /// True to enable or false to disable the internal logging for the Flurry SDK.
        /// </summary>
        /// <param name="enableLog"> True to enable logging, false to disable it.</param>
        public static void SetLogEnabled(bool enableLog)
        {
            if (flurryAgent != null)
            {
                flurryAgent.SetLogEnabled(enableLog);
            }
        }

        /// <summary>
        /// Set the log level of the internal Flurry SDK logging.
        /// </summary>
        ///<param name="logLevel"> The level to set it to { VERBOSE, DEBUG, INFO, WARN, ERROR, ASSERT }.</param>
        public static void SetLogLevel(FlurrySDK.Flurry.LogLevel logLevel)
        {
            if (flurryAgent != null)
            {
                flurryAgent.SetLogLevel(logLevel);
            }
        }

        /// <summary>
        /// True to enable or  false to disable SSL Pinning for Flurry Analytics connection. Defaults to false.
        ///
        /// Turn on to add SSL Pinning protection for the Flurry Analytics connections. Disable it
        /// if your app is using proxy or any services that are not compliant with SSL Pinning.
        /// </summary>
        /// <param name="sslPinningEnabled"> True to enable SSL Pinning for Flurry Analytics connection, false to disable it.</param>
        public static void SetSslPinningEnabled(bool sslPinningEnabled)
        {
            if (flurryAgent != null)
            {
                flurryAgent.SetSslPinningEnabled(sslPinningEnabled);
            }
        }

        /// <summary>
        /// Sets the age of the user at the time of this session.
        /// </summary>
        /// <param name="age">Age.</param>
        public static void SetAge(int age)
        {
            if (flurryAgent != null)
            {
                flurryAgent.SetAge(age);
            }
        }

        /// <summary>
        /// Sets the gender of the user.
        /// </summary>
        /// <param name="gender">Gender.</param>
        public static void SetGender(Gender gender)
        {
            if (flurryAgent != null)
            {
                flurryAgent.SetGender(gender);
            }
        }

        /// <summary>
        /// Set whether Flurry should record location via GPS.
        /// </summary>
        /// <param name="reportLocation">If set to <c>true</c> report location.</param>
        public static void SetReportLocation(bool reportLocation)
        {
            if (flurryAgent != null)
            {
                flurryAgent.SetReportLocation(reportLocation);
            }
        }

        /// <summary>
        /// This method allows you to specify session origin and deep link for each session.
        /// </summary>
        /// <param name="originName">Origin name.</param>
        /// <param name="deepLink">Deep link.</param>
        public static void SetSessionOrigin(string originName, string deepLink)
        {
            if (flurryAgent != null)
            {
                flurryAgent.SetSessionOrigin(originName, deepLink);
            }
        }

        /// <summary>
        /// Sets the Flurry userId for this session.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        public static void SetUserId(string userId)
        {
            if (flurryAgent != null)
            {
                flurryAgent.SetUserId(userId);
            }
        }

        /// <summary>
        /// Set the version name of the app.
        /// </summary>
        /// <param name="versionName">Version name.</param>
        public static void SetVersionName(string versionName)
        {
            if (flurryAgent != null)
            {
                flurryAgent.SetVersionName(versionName);
            }
        }

        /// <summary>
        /// Add origin attribution.
        /// </summary>
        /// <param name="originName">Origin name.</param>
        /// <param name="originVersion">Origin version.</param>
        public static void AddOrigin(string originName, string originVersion)
        {
            if (flurryAgent != null)
            {
                flurryAgent.AddOrigin(originName, originVersion);
            }
        }

        /// <summary>
        /// Add origin attribution with parameters.
        /// </summary>
        /// <param name="originName">Origin name.</param>
        /// <param name="originVersion">Origin version.</param>
        /// <param name="originParameters">Origin parameters.</param>
        public static void AddOrigin(string originName, string originVersion, IDictionary<string, string> originParameters)
        {
            if (flurryAgent != null)
            {
                flurryAgent.AddOrigin(originName, originVersion, originParameters);
            }
        }

        /// <summary>
        /// This method allows you to associate parameters with an session.
        /// </summary>
        /// <param name="name">Property Name.</param>
        /// <param name="value">Property Value.</param>
        public static void AddSessionProperty(string name, string value)
        {
            if (flurryAgent != null)
            {
                flurryAgent.AddSessionProperty(name, value);
            }
        }

        /// <summary>
        /// Set Flurry Consent for the IAB Global Privacy Platform (GPP). To pass an IAB string to Flurry.
        /// </summary>
        /// <param name="gppString">IAB GPP String.</param>
        /// <param name="gppSectionIds">Integer set of IAB GPP section ids that are applicable for this bid request.</param>
        /// <returns>True if consent is valid, false otherwise.</returns>
        public static bool SetGppConsent(string gppString, ISet<int> gppSectionIds)
        {
            if (flurryAgent != null)
            {
                return flurryAgent.SetGppConsent(gppString, gppSectionIds);
            }

            return false;
        }

        /// <summary>
        /// An api to send ccpa compliance data to Flurry on the user's choice to opt out or opt in to data sale to third parties. The user's preference must be used to initialize the WithDataSaleOptOut setting in the FlurrySessionBuilder in all future sessions.
        /// </summary>
        /// <param name="isOptOut">isOptOut</param>
        public static void SetDataSaleOptOut(bool isOptOut)
        {
            if (flurryAgent != null)
            {
                flurryAgent.SetDataSaleOptOut(isOptOut);
            }
        }

        /// <summary>
        /// An api to allow the user to request Flurry delete their collected data from this app.
        /// </summary>
        public static void DeleteData()
        {
            if (flurryAgent != null)
            {
                flurryAgent.DeleteData();
            }
        }

        /// <summary>
        /// This api opens privacy dashboard in Chrome CustomTab (if its dependency's been included in the gradle and device support it as well)
        /// otherwise will open it in the external browser.
        /// </summary>
        public static void OpenPrivacyDashboard()
        {
            if (flurryAgent != null)
            {
                flurryAgent.OpenPrivacyDashboard();
            }
        }

        /// <summary>
        /// Get the version of the Flurry SDK.
        /// </summary>
        /// <returns>The agent version.</returns>
        public static int GetAgentVersion()
        {
            if (flurryAgent != null)
            {
                return flurryAgent.GetAgentVersion();
            }

            return 0;
        }

        /// <summary>
        /// Get the release version of the Flurry SDK.
        /// </summary>
        /// <returns>The release version.</returns>
        public static string GetReleaseVersion()
        {
            if (flurryAgent != null)
            {
                return flurryAgent.GetReleaseVersion();
            }

            return null;
        }

        /// <summary>
        /// Check to see if there is an active session.
        /// </summary>
        /// <returns>The session identifier.</returns>
        public static string GetSessionId()
        {
            if (flurryAgent != null)
            {
                return flurryAgent.GetSessionId();
            }

            return null;
        }

        /// <summary>
        /// Log an event.
        /// </summary>
        /// <returns>The event recording status.</returns>
        /// <param name="eventId">Event identifier.</param>
        public static EventRecordStatus LogEvent(string eventId)
        {
            if (flurryAgent != null)
            {
                return (EventRecordStatus) flurryAgent.LogEvent(eventId);
            }

            return EventRecordStatus.FlurryEventRecorded;
        }

        /// <summary>
        /// Log a timed event.
        /// </summary>
        /// <returns>The event recording status.</returns>
        /// <param name="eventId">Event identifier.</param>
        /// <param name="timed">If set to <c>true</c> to log timed event.</param>
        public static EventRecordStatus LogEvent(string eventId, bool timed)
        {
            if (flurryAgent != null)
            {
                return (EventRecordStatus) flurryAgent.LogEvent(eventId, timed);
            }

            return EventRecordStatus.FlurryEventRecorded;
        }

        /// <summary>
        /// Log an event with parameters.
        /// </summary>
        /// <returns>The event recording status.</returns>
        /// <param name="eventId">Event identifier.</param>
        /// <param name="parameters">Event parameters.</param>
        public static EventRecordStatus LogEvent(string eventId, IDictionary<string, string> parameters)
        {
            if (flurryAgent != null)
            {
                return (EventRecordStatus) flurryAgent.LogEvent(eventId, parameters);
            }

            return EventRecordStatus.FlurryEventRecorded;
        }

        /// <summary>
        /// Log a timed event with parameters.
        /// </summary>
        /// <returns>The event recording status.</returns>
        /// <param name="eventId">Event identifier.</param>
        /// <param name="parameters">Event parameters.</param>
        /// <param name="timed">If set to <c>true</c> to log timed event.</param>
        public static EventRecordStatus LogEvent(string eventId, IDictionary<string, string> parameters, bool timed)
        {
            if (flurryAgent != null)
            {
                return (EventRecordStatus) flurryAgent.LogEvent(eventId, parameters, timed);
            }

            return EventRecordStatus.FlurryEventRecorded;
        }

        /// <summary>
        /// End a timed event.
        /// </summary>
        /// <param name="eventId">Event identifier.</param>
        public static void EndTimedEvent(string eventId)
        {
            if (flurryAgent != null)
            {
                flurryAgent.EndTimedEvent(eventId);
            }
        }

        /// <summary>
        /// End a timed event.Only up to 10 unique parameters total can be passed for an event,
        /// including those passed when the event was initiated.
        /// </summary>
        /// <param name="eventId">Event identifier.</param>
        /// <param name="parameters">Event parameters.</param>
        public static void EndTimedEvent(string eventId, IDictionary<string, string> parameters)
        {
            if (flurryAgent != null)
            {
                flurryAgent.EndTimedEvent(eventId, parameters);
            }
        }

        /// <summary>
        /// Log a standard event.
        /// </summary>
        /// <returns>The event recording status.</returns>
        /// <param name="eventId">Standard Event identifier.</param>
        public static EventRecordStatus LogEvent(Event eventId)
        {
            if (flurryAgent != null)
            {
                return (EventRecordStatus)flurryAgent.LogEvent(eventId, null);
            }

            return EventRecordStatus.FlurryEventRecorded;
        }

        /// <summary>
        /// Log a standard event with parameters.
        /// </summary>
        /// <returns>The event recording status.</returns>
        /// <param name="eventId">Standard Event identifier.</param>
        /// <param name="parameters">Standard Event parameters.</param>
        public static EventRecordStatus LogEvent(Event eventId, EventParams parameters)
        {
            if (flurryAgent != null)
            {
                return (EventRecordStatus)flurryAgent.LogEvent(eventId, parameters);
            }

            return EventRecordStatus.FlurryEventRecorded;
        }

        /// <summary>
        /// Log a page view. Deprecated, API removed, no longer supported by Flurry.
        /// </summary>
        public static void OnPageView()
        {
            if (flurryAgent != null)
            {
                flurryAgent.OnPageView();
            }
        }

        /// <summary>
        /// Report errors that your app catches.
        /// </summary>
        /// <param name="errorId">Error identifier.</param>
        /// <param name="message">Error message.</param>
        /// <param name="errorClass">Error class.</param>
        public static void OnError(string errorId, string message, string errorClass)
        {
            if (flurryAgent != null)
            {
                flurryAgent.OnError(errorId, message, errorClass);
            }
        }

        /// <summary>
        /// Report errors that your app catches with parameters.
        /// </summary>
        /// <param name="errorId">Error identifier.</param>
        /// <param name="message">Error message.</param>
        /// <param name="errorClass">Error class.</param>
        /// <param name="parameters">Error parameters.</param>
        public static void OnError(string errorId, string message, string errorClass, IDictionary<string, string> parameters)
        {
            if (flurryAgent != null)
            {
                flurryAgent.OnError(errorId, message, errorClass, parameters);
            }
        }

        /// <summary>
        /// Logs the breadcrumb.
        /// </summary>
        /// <param name="crashBreadcrumb">Crash breadcrumb.</param>
        public static void LogBreadcrumb(string crashBreadcrumb)
        {
            if (flurryAgent != null)
            {
                flurryAgent.LogBreadcrumb(crashBreadcrumb);
            }
        }

        /// <summary>
        /// Log a payment.
        /// </summary>
        /// <returns>The payment recording status.</returns>
        /// <param name="productName">Product name.</param>
        /// <param name="productId">Product identifier.</param>
        /// <param name="quantity">Quantity.</param>
        /// <param name="price">Price.</param>
        /// <param name="currency">Currency.</param>
        /// <param name="transactionId">Transaction identifier.</param>
        /// <param name="parameters">Payment parameters.</param>
        public static EventRecordStatus LogPayment(
            string productName, string productId, int quantity, double price,
            string currency, string transactionId, IDictionary<string, string> parameters)
        {
            if (flurryAgent != null)
            {
                return (EventRecordStatus) flurryAgent.LogPayment(productName, productId, quantity, price,
                                                                  currency, transactionId, parameters);
            }

            return EventRecordStatus.FlurryEventRecorded;
        }

        /// <summary>
        /// Sets the iOS In-App Purchase reporting enabled.
        /// </summary>
        /// <param name="enableIAP">If set to <c>true</c> to enable iOS In-App Purchase.</param>
        public static void SetIAPReportingEnabled(bool enableIAP)
        {
            if (flurryAgent != null)
            {
                flurryAgent.SetIAPReportingEnabled(enableIAP);
            }
        }

        /// <summary>
        /// Sets the iOS conversion value sent to Apple through SKAdNetwork.
        /// </summary>
        /// <param name="conversionValue">An integer value between 0-63.  The conversion values meaning is determined by the developer.</param>
        public static void UpdateConversionValue(int conversionValue)
        {
            if (flurryAgent != null)
            {
                flurryAgent.UpdateConversionValue(conversionValue);
            }
        }

        /// <summary>
        /// Allows Flurry to set the SKAdNetwork conversion value for you.
        /// The final conversion value is a decimal number between 0-63.
        /// The conversion value is calculated from a 6 bit binary number.
        /// The first two bits represent days of user retention from 0-3 days
        /// The last four bits represent a true false state indicating if the user has completed the post install event.
        /// </summary>
        /// <param name="flurryEvent">Valid events are NoEvent, Registration, LogIn, Subscription, and InAppPurchase.</param>
        public static void UpdateConversionValueWithEvent(SKAdNetworkEvent flurryEvent)
        {
            if (flurryAgent != null)
            {
                flurryAgent.UpdateConversionValueWithEvent(flurryEvent);
            }
        }

        /// <summary>
        /// Set a listener to listen notification events.
        /// </summary>
        /// <param name="messagingListener">Flurry messaging listener.</param>
        [Obsolete("please use Builder().WithMessaging() instead of SetMessagingListener()")]
        public static void SetMessagingListener(IMessagingListener messagingListener)
        {
            if (flurryAgent != null)
            {
                flurryAgent.SetMessagingListener(messagingListener);
            }
        }

        /// <summary>
        /// Get Publisher Segmentation data without fetch; cached or newly fetched.
        /// </summary>
        [Obsolete("please use PublisherSegmentation.GetData() instead of GetPublisherSegmentation()")]
        public static IDictionary<string, string> GetPublisherSegmentation()
        {
            if (flurryAgent != null)
            {
                return flurryAgent.GetPublisherSegmentation();
            }

            return null;
        }

        /// <summary>
        /// Fetch Publisher Segmentation data.
        /// </summary>
        [Obsolete("please use PublisherSegmentation.Fetch() instead of FetchPublisherSegmentation()")]
        public static void FetchPublisherSegmentation()
        {
            if (flurryAgent != null)
            {
                flurryAgent.FetchPublisherSegmentation();
            }
        }

        /// <summary>
        /// Set a listener to listen Publisher Segmentation data request.
        /// </summary>
        /// <param name="flurryPublisherSegmentationListener">Flurry Publisher Segmentation listener.</param>
        [Obsolete("please use PublisherSegmentation.RegisterListener() instead of SetPublisherSegmentationListener()")]
        public static void SetPublisherSegmentationListener(IFlurryPublisherSegmentationListener flurryPublisherSegmentationListener)
        {
            if (flurryAgent != null)
            {
                flurryAgent.SetPublisherSegmentationListener(flurryPublisherSegmentationListener);
            }
        }

        public void Dispose()
        {
            if (flurryAgent != null)
            {
                flurryAgent.Dispose();
            }
        }

    }
}
