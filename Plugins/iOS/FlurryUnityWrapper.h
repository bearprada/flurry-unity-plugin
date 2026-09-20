/*
 * Copyright 2018, Oath Inc.
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

#import <Foundation/Foundation.h>

typedef void (*OnFetched) (const char *data);
typedef void (*OnPSFetched) (const char *data);

typedef void (*OnConfigFetched)();
typedef void (*OnConfigFetchNoChange)();
typedef void (*OnConfigFetchFailed)();
typedef void (*OnConfigActivated)();

typedef void (*OnNotificationReceived)(const char *title, const char *body, const char *sound, const char *appData);
typedef void (*OnNotificationClicked)(const char *title, const char *body, const char *sound, const char *appData);


@interface FlurryUnityWrapper : NSObject

+ (FlurryUnityWrapper *)shared;

- (void)initializeFlurrySessionBuilder;

- (void)flurryWithCrashReporting:(BOOL)crashReporting;

- (void)flurryWithDataSaleOptOut:(BOOL)isOptOut;

- (void)flurryWithLogLevel:(int)logLevel;

- (void)flurryWithLogEnabled:(BOOL)logEnabled;

- (void)flurryWithSessionContinueSeconds:(long)seconds;

- (void)flurryWithIncludeBackgroundSessionsInMetrics:(BOOL) includeBackgroundSessionsInMetrics;

- (void)flurryWithAppVersion:(const char *)appVersion;

- (void)flurryStartSessionWithSessionBuilder:(const char *)apiKey;

- (void)flurrySetupMessagingWithAutoIntegration;

- (void)flurrySetDataSaleOptOut:(BOOL)isOptOut;

- (void)flurrySetDelete;

- (int)flurryLogEvent:(const char *)eventName;

- (int)flurryLogEvent:(const char *)eventName keys:(const char *)keys values:(const char *)values;

- (int)flurryLogTimedEvent:(const char *)eventName keys:(const char *)keys values:(const char *)values isTimed:(BOOL)isTimed;

- (int)flurryLogStandardEvent:(const char *)eventName keys:(const char *)keys values:(const char *)values;

- (void)flurrySetUserId:(const char *)userId;

- (void)flurrySetSessionContinueSeconds:(long)seconds;

- (void)flurrySetIncludeBackgroundSessionsInMetrics:(BOOL)includeBackgroundSessionsInMetrics;

- (void)flurrySetAge:(int)age;

- (void)flurrySetGender:(const char *)gender;

- (void)flurryLogError:(const char *)errorId message:(const char *)message errorClass:(const char *)errorClass;

- (void)flurryLogError:(const char *)errorId message:(const char *)message errorClass:(const char *)errorClass keys:(const char *)keys values:(const char *)values;

- (void)flurryAddOrigin:(const char *)originName originVersion:(const char *)originVersion;

- (void)flurrySetSessionOrigin:(const char *)originName deepLink:(const char *)deepLink;

- (void)flurrySetVersionName:(const char *)versionName;

- (void)flurryAddSessionProperty:(const char *)name value:(const char* )value;

- (void)flurryAddOrigin:(const char *)originName originVersion:(const char *)originVersion keys:(const char *) keys values:(const char *)values;

- (const char *)flurryGetAgentVersion;

- (const char *)flurryGetReleaseVersion;

- (const char *)flurryGetSessionId;

- (int)flurryLogTimedEvent:(const char *)eventId isTimed:(BOOL)isTimed;

- (void)flurryEndTimedEvent:(const char *)eventName;

- (void)flurryEndTimedEvent:(const char *)eventName keys:(const char *)keys values:(const char *)values;

- (void)flurryLogBreadcrumb:(const char *)crashBreadcrumb;

- (void)flurryLogPayment:(const char *)productName productId:(const char *)productId quantity:(const int)quantity price:(const double)price currency:(const char *)currency transactionId:(const char *)transactionId keys:(const char *)keys values:(const char *)values;

- (void)flurrySetIAPReportingEnabled:(BOOL)enableIAP;

- (void)flurryOpenPrivacyDashboard;

- (void)flurryUpdateConversionValue:(int)conversionValue;

- (void)flurryUpdateConversionValueWithEvent:(int)flurryEvent;

- (void)flurrySetUserProperty:(const char *)propertyName values:(const char *)values;

- (void)flurrySetUserProperty:(const char *)propertyName value:(const char *)value;

- (void)flurryAddUserProperty:(const char *)propertyName values:(const char *)values;

- (void)flurryAddUserProperty:(const char *)propertyName value:(const char *)value;

- (void)flurryRemoveUserProperty:(const char *)propertyName values:(const char *)values;

- (void)flurryRemoveUserProperty:(const char *)propertyName value:(const char *)value;

- (void)flurryRemoveUserProperty:(const char *)propertyName;

- (void)flurryFlagUserProperty:(const char *)propertyName;

- (void)flurryFetchPublisherSegmentation;

- (void)flurrySetPublisherSegmentationListener;

- (const char *)flurryGetPublisherData;

- (void)flurryRegisterOnPSFetchedCallback:(OnPSFetched)handler;

// TODO: Deprecated, and need to remove for next GA release
- (void)flurryRegisterOnFetchedCallback:(OnFetched)handler;

- (void)flurrySetConfigListener;

- (void)flurryRegisterConfigCallback1:(OnConfigFetched)handler1 callback2:(OnConfigFetchNoChange)handler2 callback3:(OnConfigFetchFailed)handler3 callback4:(OnConfigActivated)handler4;

- (void)flurryConfigFetch;

- (void)flurryConfigActivate;

- (const char *)flurryConfigGetString:(const char *)key defaultValue:(const char *)defaultValue;

- (void)flurryRegisterMessagingCallback1:(OnNotificationReceived)handler1 callback2:(OnNotificationClicked) handler2;
@end
