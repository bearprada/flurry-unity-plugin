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

#import "FlurryUnityWrapper.h"
#import "FlurryUnityPlugin.h"

@implementation FlurryUnityPlugin

extern "C" {
    
    const void initializeFlurrySessionBuilder() {
        [[FlurryUnityWrapper shared] initializeFlurrySessionBuilder];
    }
    
    const void flurryWithCrashReporting(bool crashReporting){
        [[FlurryUnityWrapper shared] flurryWithCrashReporting:crashReporting];
    }
    
    const void flurryWithDataSaleOptOut(bool isOptOut){
        [[FlurryUnityWrapper shared] flurryWithDataSaleOptOut:isOptOut];
    }
    
    const void flurryWithLogLevel(int logLevel){
        [[FlurryUnityWrapper shared] flurryWithLogLevel:logLevel];
    }
    
    const void flurryWithLogEnabled(bool logEnabled){
        [[FlurryUnityWrapper shared] flurryWithLogEnabled:logEnabled];
    }
    
    const void flurryWithSessionContinueSeconds(long seconds){
        [[FlurryUnityWrapper shared] flurryWithSessionContinueSeconds:seconds];
    }
    
    const void flurryWithIncludeBackgroundSessionsInMetrics(bool includeBackgroundSessionsInMetrics){
        [[FlurryUnityWrapper shared] flurryWithIncludeBackgroundSessionsInMetrics:includeBackgroundSessionsInMetrics];
    }
    
    const void flurryWithAppVersion(const char *appVersion){
        [[FlurryUnityWrapper shared] flurryWithAppVersion:appVersion];
    }
    
    const void flurryStartSessionWithSessionBuilder(const char *apiKey){
        [[FlurryUnityWrapper shared] flurryStartSessionWithSessionBuilder:apiKey];
    }
    
    const void flurrySetupMessagingWithAutoIntegration() {
        [[FlurryUnityWrapper shared] flurrySetupMessagingWithAutoIntegration];
    }
    
    const void flurrySetDataSaleOptOut(bool isOptOut){
        [[FlurryUnityWrapper shared] flurrySetDataSaleOptOut:isOptOut];
    }
    
    const void flurrySetDelete(){
        [[FlurryUnityWrapper shared] flurrySetDelete];
    }
    
    const int flurryLogEvent(const char *eventName){
        [[FlurryUnityWrapper shared] flurryLogEvent:eventName];
    }
    
    const int flurryLogEventWithParameter(const char* eventName, const char* keys, const char* values){
        return [[FlurryUnityWrapper shared] flurryLogEvent:eventName keys:keys values:values];
    }
    
    const int flurryLogTimedEventWithParams(const char* eventName, const char* keys, const char* values, bool isTimed) {
        return [[FlurryUnityWrapper shared] flurryLogTimedEvent:eventName keys:keys values:values isTimed:isTimed];
    }
    
    const int flurryLogStandardEventWithParameter(const char* eventName, const char* keys, const char* values){
        return [[FlurryUnityWrapper shared] flurryLogStandardEvent:eventName keys:keys values:values];
    }
    const void flurrySetUserId(const char* userId) {
        [[FlurryUnityWrapper shared] flurrySetUserId:userId];
    }

    const void flurrySetSessionContinueSeconds(long seconds){
        [[FlurryUnityWrapper shared] flurrySetSessionContinueSeconds:seconds];
    }

    const void flurrySetIncludeBackgroundSessionsInMetrics(bool includeBackgroundSessionsInMetrics) {
        [[FlurryUnityWrapper shared] flurrySetIncludeBackgroundSessionsInMetrics:includeBackgroundSessionsInMetrics];
    }
    
    const void flurrySetAge(const int age) {
        [[FlurryUnityWrapper shared] flurrySetAge:age];
    }
    
    const void flurrySetGender(const char* gender) {
        [[FlurryUnityWrapper shared] flurrySetGender:gender];
    }
    
    const void flurryLogPageView() {
        NSLog(@"[Flurry logPageView] is removed in Flurry 11.0.0");
    }
    
    
    const void flurryLogError(const char* errorId, const char* message, const char* errorClass) {
        [[FlurryUnityWrapper shared] flurryLogError:errorId message:message errorClass:errorClass];
    }
    
    const void flurryLogErrorWithParams(const char* errorId, const char* message, const char* errorClass, const char* keys, const char* values) {
        [[FlurryUnityWrapper shared] flurryLogError:errorId message:message errorClass:errorClass keys:keys values:values];
    }
    
    const void flurryAddOrigin(const char* originName, const char* originVersion) {
        [[FlurryUnityWrapper shared] flurryAddOrigin:originName originVersion:originVersion];
    }
    
    const void flurrySetSessionOrigin(const char* originName, const char* deepLink) {
        [[FlurryUnityWrapper shared] flurrySetSessionOrigin:originName deepLink:deepLink];
    }
    
    const void flurrySetVersionName(const char* versionName) {
        [[FlurryUnityWrapper shared] flurrySetVersionName:versionName];
    }
    
    const void flurryAddSessionProperty(const char* name, const char* value) {
        [[FlurryUnityWrapper shared] flurryAddSessionProperty:name value:value];
    }
    
    
    const void flurryAddOriginWithParams(const char* originName,const char* originVersion,const char* keys,const char* values){
        [[FlurryUnityWrapper shared] flurryAddOrigin:originName originVersion:originVersion keys:keys values:values];
    }
    
    const char* flurryGetAgentVersion()
    {
        return [[FlurryUnityWrapper shared] flurryGetAgentVersion];
    }
    
    const char* flurryGetReleaseVersion()
    {
        return [[FlurryUnityWrapper shared] flurryGetReleaseVersion];
    }
    
    const char* flurryGetSessionId()
    {
        return [[FlurryUnityWrapper shared] flurryGetSessionId];
    }
    
    const int flurryLogTimedEvent(const char* eventId, bool isTimed) {
        return [[FlurryUnityWrapper shared] flurryLogTimedEvent:eventId isTimed:isTimed];
    }
    
    const void flurryEndTimedEvent(const char* eventName) {
        [[FlurryUnityWrapper shared] flurryEndTimedEvent:eventName];
    }
    
    const void flurryEndTimedEventWithParams(const char* eventName, const char* keys,const char* values) {
        [[FlurryUnityWrapper shared] flurryEndTimedEvent:eventName keys:keys values:values];
    }
    
    const void flurryLogBreadcrumb(const char* crashBreadcrumb){
        [[FlurryUnityWrapper shared] flurryLogBreadcrumb:crashBreadcrumb];
    }

    const void flurryLogPayment(const char* productName, const char* productId, const int quantity, const double price, const char* currency, const char* transactionId, const char* keys, const char* values) {
        
        [[FlurryUnityWrapper shared] flurryLogPayment:productName productId:productId quantity:quantity price:price currency:currency transactionId:transactionId keys:keys values:values];
    }
    
    const void flurrySetIAPReportingEnabled(bool enableIAP){
        [[FlurryUnityWrapper shared] flurrySetIAPReportingEnabled:enableIAP];
    }
    
    const void flurryOpenPrivacyDashboard(){
        [[FlurryUnityWrapper shared] flurryOpenPrivacyDashboard];
    }
    
    const void flurryUpdateConversionValue(int conversionValue){
        if (@available(iOS 14.0, *)) {
            [[FlurryUnityWrapper shared] flurryUpdateConversionValue:conversionValue];
        }
    }
    
    const void flurryUpdateConversionValueWithEvent(int flurryEvent){
        if (@available(iOS 14.0, *)) {
            [[FlurryUnityWrapper shared] flurryUpdateConversionValueWithEvent:flurryEvent];
        }
    }
    
    const void flurrySetUserPropertyValues(const char* propertyName, const char* values){
        [[FlurryUnityWrapper shared] flurrySetUserProperty:propertyName  values:values];
    }
    
    const void flurrySetUserPropertyValue(const char* propertyName, const char* value){
        [[FlurryUnityWrapper shared] flurrySetUserProperty:propertyName  value:value];
    }
    
    const void flurryAddUserPropertyValues(const char* propertyName, const char* values){
        [[FlurryUnityWrapper shared] flurryAddUserProperty:propertyName  values:values];
    }
    
    const void flurryAddUserPropertyValue(const char* propertyName, const char* value){
        [[FlurryUnityWrapper shared] flurryAddUserProperty:propertyName  value:value];
    }
    
    const void flurryRemoveUserPropertyValues(const char* propertyName, const char* values){
        [[FlurryUnityWrapper shared] flurryRemoveUserProperty:propertyName  values:values];
    }
    
    const void flurryRemoveUserPropertyValue(const char* propertyName, const char* value){
        [[FlurryUnityWrapper shared] flurryRemoveUserProperty:propertyName  value:value];
    }
    
    const void flurryRemoveUserProperty(const char* propertyName){
        [[FlurryUnityWrapper shared] flurryRemoveUserProperty:propertyName];
    }
    
    const void flurryFlagUserProperty(const char* propertyName){
        [[FlurryUnityWrapper shared] flurryFlagUserProperty:propertyName];
    }
    
    const void flurryFetchPublisherSegmentation(){
        [[FlurryUnityWrapper shared] flurryFetchPublisherSegmentation];
    }
    
    const void flurrySetPublisherSegmentationListener(){
        [[FlurryUnityWrapper shared] flurrySetPublisherSegmentationListener];
    }
    
    const char* flurryGetPublisherData(){
        return [[FlurryUnityWrapper shared] flurryGetPublisherData];
    }
    
    const void flurryRegisterOnPSFetchedCallback(OnPSFetched handler){
        [[FlurryUnityWrapper shared] flurryRegisterOnPSFetchedCallback:handler];
    }
    
    // TODO: Deprecated, and need to remove for next GA release
    const void flurryRegisterOnFetchedCallback(OnFetched handler)
    {
        [[FlurryUnityWrapper shared] flurryRegisterOnFetchedCallback:handler];
    }
    
    const void flurrySetConfigListener(){
        [[FlurryUnityWrapper shared] flurrySetConfigListener];
    }
    
    const void flurryRegisterConfigCallback(OnConfigFetched handler1, OnConfigFetchNoChange handler2, OnConfigFetchFailed handler3, OnConfigActivated handler4){
        
        [[FlurryUnityWrapper shared] flurryRegisterConfigCallback1:handler1 callback2:handler2 callback3:handler3 callback4:handler4];

    }
    
    const void flurryConfigFetch(){
        [[FlurryUnityWrapper shared] flurryConfigFetch];
    }
    
    const void flurryConfigActivate(){
        [[FlurryUnityWrapper shared] flurryConfigActivate];
    }
    
    const char* flurryConfigGetString(const char* key, const char* defaultValue){
        return [[FlurryUnityWrapper shared] flurryConfigGetString:key defaultValue:defaultValue];
        
    }
    
    const void flurryRegisterMessagingCallback(OnNotificationReceived handler1, OnNotificationClicked handler2){
#if __has_include("FlurryMessaging.h")
        [[FlurryUnityWrapper shared] flurryRegisterMessagingCallback1:handler1 callback2:handler2];
#endif
        
    }
}

@end



