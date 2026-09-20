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
using System.Collections.Generic;

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
        // Flurry Standard Event.

        /// <summary>
        /// Constants for Flurry Standard Event IDs.
        /// </summary>
        public enum Event
        {
            /// <summary>
            /// <br>Log this event when a user clicks on an Ad. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.AD_TYPE </br>
            /// </summary>
            AD_CLICK,

            /// <summary>
            /// <br>Log this event when a user views an Ad impression. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.AD_TYPE </br>
            /// </summary>
            AD_IMPRESSION,

            /// <summary>
            /// <br>Log this event when a user is granted a reward for viewing a rewarded Ad. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.AD_TYPE </br>
            /// </summary>
            AD_REWARDED,

            /// <summary>
            /// <br>Log this event when a user skips an Ad. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.AD_TYPE </br>
            /// </summary>
            AD_SKIPPED,

            /// <summary>
            /// <br>Log this event when a user spends credit in the app. </br>
            /// <br>mandatory parameters: Param.TOTAL_AMOUNT </br>
            /// <br>recommended parameters: Param.LEVEL_NUMBER, Param.IS_CURRENCY_SOFT, Param.CREDIT_TYPE, Param.CREDIT_ID, Param.CREDIT_NAME, Param.CURRENCY_TYPE </br>
            /// </summary>
            CREDITS_SPENT,

            /// <summary>
            /// <br>Log this event when a user purchases credit in the app. </br>
            /// <br>mandatory parameters: Param.TOTAL_AMOUNT </br>
            /// <br>recommended parameters: Param.LEVEL_NUMBER, Param.IS_CURRENCY_SOFT, Param.CREDIT_TYPE, Param.CREDIT_ID, Param.CREDIT_NAME, Param.CURRENCY_TYPE </br>
            /// </summary>
            CREDITS_PURCHASED,

            /// <summary>
            /// <br>Log this event when a user earns credit in the app. </br>
            /// <br>mandatory parameters: Param.TOTAL_AMOUNT </br>
            /// <br>recommended parameters: Param.LEVEL_NUMBER, Param.IS_CURRENCY_SOFT, Param.CREDIT_TYPE, Param.CREDIT_ID, Param.CREDIT_NAME, Param.CURRENCY_TYPE </br>
            /// </summary>
            CREDITS_EARNED,

            /// <summary>
            /// <br>Log this event when a user unlocks an achievement in the app. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.ACHIEVEMENT_ID </br>
            /// </summary>
            ACHIEVEMENT_UNLOCKED,

            /// <summary>
            /// <br>Log this event when an App user completes a level. </br>
            /// <br>mandatory parameters: Param.LEVEL_NUMBEER </br>
            /// <br>recommended parameters: Param.LEVEL_NAME </br>
            /// </summary>
            LEVEL_COMPLETED,

            /// <summary>
            /// <br>Log this event when an App user fails a level. </br>
            /// <br>mandatory parameters: Param.LEVEL_NUMBEER </br>
            /// <br>recommended parameters: Param.LEVEL_NAME </br>
            /// </summary>
            LEVEL_FAILED,

            /// <summary>
            /// <br>Log this event when an App user levels up. </br>
            /// <br>mandatory parameters: Param.LEVEL_NUMBEER </br>
            /// <br>recommended parameters: Param.LEVEL_NAME </br>
            /// </summary>
            LEVEL_UP,

            /// <summary>
            /// <br>Log this event when an App user starts a level. </br>
            /// <br>mandatory parameters: Param.LEVEL_NUMBEER </br>
            /// <br>recommended parameters: Param.LEVEL_NAME </br>
            /// </summary>
            LEVEL_STARTED,

            /// <summary>
            /// <br>Log this event when an App user skips a level. </br>
            /// <br>mandatory parameters: Param.LEVEL_NUMBEER </br>
            /// <br>recommended parameters: Param.LEVEL_NAME </br>
            /// </summary>
            LEVEL_SKIP,

            /// <summary>
            /// <br>Log this event when an App user posts his score. </br>
            /// <br>mandatory parameters: Param.SCORE </br>
            /// <br>recommended parameters: Param.LEVEL_NUMBEER </br>
            /// </summary>
            SCORE_POSTED,

            /// <summary>
            /// <br>Log this event when a user rates a content in the App. </br>
            /// <br>mandatory parameters: Param.CONTENT_ID, Param.RATING </br>
            /// <br>recommended parameters: Param.CONTENT_TYPE, Param.CONTENT_NAME </br>
            /// </summary>
            CONTENT_RATED,

            /// <summary>
            /// <br>Log this event when a specific content is viewed by a user. </br>
            /// <br>mandatory parameters: Param.CONTENT_ID </br>
            /// <br>recommended parameters: Param.CONTENT_TYPE, Param.CONTENT_NAME </br>
            /// </summary>
            CONTENT_VIEWED,

            /// <summary>
            /// <br>Log this event when a user saves the content in the App. </br>
            /// <br>mandatory parameters: Param.CONTENT_ID </br>
            /// <br>recommended parameters: Param.CONTENT_TYPE, Param.CONTENT_NAME </br>
            /// </summary>
            CONTENT_SAVED,

            /// <summary>
            /// <br>Log this event when a user customizes the App/product. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: none </br>
            /// </summary>
            PRODUCT_CUSTOMIZED,

            /// <summary>
            /// <br>Log this event when the App is activated. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: none </br>
            /// </summary>
            APP_ACTIVATED,

            /// <summary>
            /// <br>Log this event when a user submits an application through the App. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: none </br>
            /// </summary>
            APPLICATION_SUBMITTED,

            /// <summary>
            /// <br>Log this event when an item is added to the cart. </br>
            /// <br>mandatory parameters: Param.ITEM_COUNT, Param.PRICE </br>
            /// <br>recommended parameters: Param.ITEM_ID, Param.ITEM_NAME, Param.ITEM_TYPE </br>
            /// </summary>
            ADD_ITEM_TO_CART,

            /// <summary>
            /// <br>Log this event when an item is added to the wish list. </br>
            /// <br>mandatory parameters: Param.ITEM_COUNT, Param.PRICE </br>
            /// <br>recommended parameters: Param.ITEM_ID, Param.ITEM_NAME, Param.ITEM_TYPE </br>
            /// </summary>
            ADD_ITEM_TO_WISH_LIST,

            /// <summary>
            /// <br>Log this event when checkout is completed or transaction is successfully completed. </br>
            /// <br>mandatory parameters: Param.ITEM_COUNT, Param.TOTAL_AMOUNT </br>
            /// <br>recommended parameters: Param.CURRENCY_TYPE, Param.TRANSACTION_ID </br>
            /// </summary>
            COMPLETED_CHECKOUT,

            /// <summary>
            /// <br>Log this event when payment information is added during a checkout process. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.SUCCESS, Param.PAYMENT_TYPE </br>
            /// </summary>
            PAYMENT_INFO_ADDED,

            /// <summary>
            /// <br>Log this event when an item is viewed. </br>
            /// <br>mandatory parameters: Param.ITEM_ID </br>
            /// <br>recommended parameters: Param.ITEM_NAME, Param.ITEM_TYPE, Param.PRICE </br>
            /// </summary>
            ITEM_VIEWED,

            /// <summary>
            /// <br>Log this event when a list of items is viewed. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.ITEM_LIST_TYPE </br>
            /// </summary>
            ITEM_LIST_VIEWED,

            /// <summary>
            /// <br>Log this event when a user does a purchase in the App. </br>
            /// <br>mandatory parameters: Param.TOTAL_AMOUNT </br>
            /// <br>recommended parameters: Param.ITEM_COUNT, Param.ITEM_ID, Param.SUCCESS, Param.ITEM_NAME, Param.ITEM_TYPE, Param.CURRENCY_TYPE, Param.TRANSACTION_ID </br>
            /// </summary>
            PURCHASED,

            /// <summary>
            /// <br>Log this event at refund. </br>
            /// <br>mandatory parameters: Param.PRICE </br>
            /// <br>recommended parameters: Param.CURRENCY_TYPE
            /// </summary>
            PURCHASE_REFUNDED,

            /// <summary>
            /// <br>Log this event when a user removes an item from the cart. </br>
            /// <br>mandatory parameters: Param.ITEM_ID </br>
            /// <br>recommended parameters: Param.PRICE, Param.ITEM_NAME, Param.ITEM_TYPE </br>
            /// </summary>
            REMOVE_ITEM_FROM_CART,

            /// <summary>
            /// <br>Log this event when a user starts checkout. </br>
            /// <br>mandatory parameters: Param.ITEM_COUNT, Param.TOTAL_AMOUNT </br>
            /// <br>recommended parameters: none </br>
            /// </summary>
            CHECKOUT_INITIATED,

            /// <summary>
            /// <br>Log this event when a user donates fund to your App or through the App. </br>
            /// <br>mandatory parameters: Param.PRICE </br>
            /// <br>recommended parameters: Param.CURRENCY_TYPE </br>
            /// </summary>
            FUNDS_DONATED,

            /// <summary>
            /// <br>Log this event when user schedules an appointment using the App. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: none </br>
            /// </summary>
            USER_SCHEDULED,

            /// <summary>
            /// <br>Log this event when an offer is presented to the user. </br>
            /// <br>mandatory parameters: Param.ITEM_ID, Param.PRICE </br>
            /// <br>recommended parameters: Param.ITEM_NAME, Param.ITEM_CATEGORY </br>
            /// </summary>
            OFFER_PRESENTED,

            /// <summary>
            /// <br>Log this event at the start of a paid subscription for a service or product. </br>
            /// <br>mandatory parameters: Param.PRICE, Param.IS_ANNUAL_SUBSCRIPTION </br>
            /// <br>recommended parameters: Param.TRIAL_DAYS, Param.PREDICTED_LTV, Param.CURRENCY_TYPE, Params.SUBSCRIPTION_COUNTRY </br>
            /// </summary>
            SUBSCRIPTION_STARTED,

            /// <summary>
            /// <br>Log this event when a user unsubscribes from a paid subscription for a service or product. </br>
            /// <br>mandatory parameters: Param.IS_ANNUAL_SUBSCRIPTION </br>
            /// <br>recommended parameters: Param.CURRENCY_TYPE, Params.SUBSCRIPTION_COUNTRY </br>
            /// </summary>
            SUBSCRIPTION_ENDED,

            /// <summary>
            /// <br>Log this event when user joins a group. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.GROUP_NAME </br>
            /// </summary>
            GROUP_JOINED,

            /// <summary>
            /// <br>Log this event when user leaves a group. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.GROUP_NAME </br>
            /// </summary>
            GROUP_LEFT,

            /// <summary>
            /// <br>Log this event when a user starts a tutorial. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.TUTORIAL_NAME </br>
            /// </summary>
            TUTORIAL_STARTED,

            /// <summary>
            /// <br>Log this event when a user completes a tutorial. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.TUTORIAL_NAME </br>
            /// </summary>
            TUTORIAL_COMPLETED,

            /// <summary>
            /// <br>Log this event when a specific tutorial step is completed. </br>
            /// <br>mandatory parameters: Param.STEP_NUMBER </br>
            /// <br>recommended parameters: Param.TUTORIAL_NAME </br>
            /// </summary>
            TUTORIAL_STEP_COMPLETED,

            /// <summary>
            /// <br>Log this event when user skips the tutorial. </br>
            /// <br>mandatory parameters: Param.STEP_NUMBER </br>
            /// <br>recommended parameters: Param.TUTORIAL_NAME </br>
            /// </summary>
            TUTORIAL_SKIPPED,

            /// <summary>
            /// <br>Log this event when a user login on the App. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.USER_ID, Param.METHOD </br>
            /// </summary>
            LOGIN,

            /// <summary>
            /// <br>Log this event when a user logout of the App. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.USER_ID, Param.METHOD </br>
            /// </summary>
            LOGOUT,

            /// <summary>
            /// <br>Log the event when a user registers (signup). Helps capture the method used to sign-up (sign up with google/apple or emailaddress) . </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.USER_ID, Param.METHOD </br>
            /// </summary>
            USER_REGISTERED,

            /// <summary>
            /// <br>Log this event when user views search results. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.QUERY, Param.SEARCH_TYPE </br>
            /// </summary>
            SEARCH_RESULT_VIEWED,

            /// <summary>
            /// <br>Log this event when a user searches for a keyword using Search. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.QUERY, Param.SEARCH_TYPE </br>
            /// </summary>
            KEYWORD_SEARCHED,

            /// <summary>
            /// <br>Log this event when a user searches for a location using Search. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.QUERY </br>
            /// </summary>
            LOCATION_SEARCHED,

            /// <summary>
            /// <br>Log this event when a user invites another user. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.USER_ID, Param.METHOD </br>
            /// </summary>
            INVITE,

            /// <summary>
            /// <br>Log this event when a user shares content with another user in the App. </br>
            /// <br>mandatory parameters: Param.SOCIAL_CONTENT_ID </br>
            /// <br>recommended parameters: Param.SOCIAL_CONTENT_NAME, Param.METHOD </br>
            /// </summary>
            SHARE,

            /// <summary>
            /// <br>Log this event when a user likes a social content. e.g. likeType captures what kind of like is logged,
            /// <br>mandatory parameters: Param.SOCIAL_CONTENT_ID </br>
            /// <br>recommended parameters: Param.SOCIAL_CONTENT_NAME, Param.LIKE_TYPE </br>
            /// </summary>
            LIKE,

            /// <summary>
            /// <br>Log this event when a user comments or replies on a social post. </br>
            /// <br>mandatory parameters: Param.SOCIAL_CONTENT_ID </br>
            /// <br>recommended parameters: Param.SOCIAL_CONTENT_NAME </br>
            /// </summary>
            COMMENT,

            /// <summary>
            /// <br>Log this event when an image, audio or a video is captured. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.MEDIA_ID, Param.MEDIA_NAME, Param.MEDIA_TYPE </br>
            /// </summary>
            MEDIA_CAPTURED,

            /// <summary>
            /// <br>Log this event when an audio or video starts. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: Param.MEDIA_ID, Param.MEDIA_NAME, Param.MEDIA_TYPE </br>
            /// </summary>
            MEDIA_STARTED,

            /// <summary>
            /// <br>Log this event when an audio or video is stopped. </br>
            /// <br>mandatory parameters: Param.DURATION </br>
            /// <br>recommended parameters: Param.MEDIA_ID, Param.MEDIA_NAME, Param.MEDIA_TYPE </br>
            /// </summary>
            MEDIA_STOPPED,

            /// <summary>
            /// <br>Log this event when an audio or video is paused. </br>
            /// <br>mandatory parameters: Param.DURATION </br>
            /// <br>recommended parameters: Param.MEDIA_ID, Param.MEDIA_NAME, Param.MEDIA_TYPE </br>
            /// </summary>
            MEDIA_PAUSED,

            /// <summary>
            /// <br>Log this event when a privacy prompt is displayed. </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: none </br>
            /// </summary>
            PRIVACY_PROMPT_DISPLAYED,

            /// <summary>
            /// <br>Log this event when a user opts in (on the privacy prompt). </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: none </br>
            /// </summary>
            PRIVACY_OPT_IN,

            /// <summary>
            /// <br>Log this event when a user opts out (on the privacy prompt). </br>
            /// <br>mandatory parameters: none </br>
            /// <br>recommended parameters: none </br>
            /// </summary>
            PRIVACY_OPT_OUT,

        }

        /// <summary>
        /// Constants for Flurry Standard Event parameters.
        /// </summary>
        public static class EventParam
        {
            /// <summary>
            /// AD type - value type: string.
            /// </summary>
            public static StringEventParam AD_TYPE = new StringEventParam("AD_TYPE");

            /// <summary>
            /// Level name - value type: string.
            /// </summary>
            public static StringEventParam LEVEL_NAME = new StringEventParam("LEVEL_NAME");

            /// <summary>
            /// Level number - value type: int.
            /// </summary>
            public static IntegerEventParam LEVEL_NUMBER = new IntegerEventParam("LEVEL_NUMBER");

            /// <summary>
            /// Content name - value type: string.
            /// </summary>
            public static StringEventParam CONTENT_NAME = new StringEventParam("CONTENT_NAME");

            /// <summary>
            /// Content type - value type: string.
            /// </summary>
            public static StringEventParam CONTENT_TYPE = new StringEventParam("CONTENT_TYPE");

            /// <summary>
            /// Content ID - value type: string.
            /// </summary>
            public static StringEventParam CONTENT_ID = new StringEventParam("CONTENT_ID");

            /// <summary>
            /// Credit name - value type: string.
            /// </summary>
            public static StringEventParam CREDIT_NAME = new StringEventParam("CREDIT_NAME");

            /// <summary>
            /// Credit type - value type: string.
            /// </summary>
            public static StringEventParam CREDIT_TYPE = new StringEventParam("CREDIT_TYPE");

            /// <summary>
            /// Credit ID - value type: string.
            /// </summary>
            public static StringEventParam CREDIT_ID = new StringEventParam("CREDIT_ID");

            /// <summary>
            /// Is Currency soft - value type: bool
            /// </summary>
            public static BooleanEventParam IS_CURRENCY_SOFT = new BooleanEventParam("IS_CURRENCY_SOFT");

            /// <summary>
            /// Currency type - value type: string.
            /// </summary>
            public static StringEventParam CURRENCY_TYPE = new StringEventParam("CURRENCY_TYPE");

            /// <summary>
            /// Payment type - value type: string.
            /// </summary>
            public static StringEventParam PAYMENT_TYPE = new StringEventParam("PAYMENT_TYPE");

            /// <summary>
            /// Item name - value type: string.
            /// </summary>
            public static StringEventParam ITEM_NAME = new StringEventParam("ITEM_NAME");

            /// <summary>
            /// Item type - value type: string.
            /// </summary>
            public static StringEventParam ITEM_TYPE = new StringEventParam("ITEM_TYPE");

            /// <summary>
            /// Item ID - value type: string.
            /// </summary>
            public static StringEventParam ITEM_ID = new StringEventParam("ITEM_ID");

            /// <summary>
            /// Item count - value type: int.
            /// </summary>
            public static IntegerEventParam ITEM_COUNT = new IntegerEventParam("ITEM_COUNT");

            /// <summary>
            /// Item category - value type: string.
            /// </summary>
            public static StringEventParam ITEM_CATEGORY = new StringEventParam("ITEM_CATEGORY");

            /// <summary>
            /// Item list type - value type: string.
            /// </summary>
            public static StringEventParam ITEM_LIST_TYPE = new StringEventParam("ITEM_LIST_TYPE");

            /// <summary>
            /// Price - value type: double.
            /// </summary>
            public static DoubleEventParam PRICE = new DoubleEventParam("PRICE");

            /// <summary>
            /// Total amount - value type: double.
            /// </summary>
            public static DoubleEventParam TOTAL_AMOUNT = new DoubleEventParam("TOTAL_AMOUNT");

            /// <summary>
            /// Achievement ID - value type: string.
            /// </summary>
            public static StringEventParam ACHIEVEMENT_ID = new StringEventParam("ACHIEVEMENT_ID");

            /// <summary>
            /// Score - value type: int.
            /// </summary>
            public static IntegerEventParam SCORE = new IntegerEventParam("SCORE");

            /// <summary>
            /// Rating - value type: string.
            /// </summary>
            public static StringEventParam RATING = new StringEventParam("RATING");

            /// <summary>
            /// Transaction ID - value type: string.
            /// </summary>
            public static StringEventParam TRANSACTION_ID = new StringEventParam("TRANSACTION_ID");

            /// <summary>
            /// Success - value type: bool.
            /// </summary>
            public static BooleanEventParam SUCCESS = new BooleanEventParam("SUCCESS");

            /// <summary>
            /// Is annual subscription - value type: bool.
            /// </summary>
            public static BooleanEventParam IS_ANNUAL_SUBSCRIPTION = new BooleanEventParam("IS_ANNUAL_SUBSCRIPTION");

            /// <summary>
            /// Subscription country - value type: string.
            /// </summary>
            public static StringEventParam SUBSCRIPTION_COUNTRY = new StringEventParam("SUBSCRIPTION_COUNTRY");

            /// <summary>
            /// Trial days - value type: int.
            /// </summary>
            public static IntegerEventParam TRIAL_DAYS = new IntegerEventParam("TRIAL_DAYS");

            /// <summary>
            /// Predicted LTV - value type: string.
            /// </summary>
            public static StringEventParam PREDICTED_LTV = new StringEventParam("PREDICTED_LTV");

            /// <summary>
            /// Group name - value type: string.
            /// </summary>
            public static StringEventParam GROUP_NAME = new StringEventParam("GROUP_NAME");

            /// <summary>
            /// Tutorial name - value type: string.
            /// </summary>
            public static StringEventParam TUTORIAL_NAME = new StringEventParam("TUTORIAL_NAME");

            /// <summary>
            /// Step number - value type: int.
            /// </summary>
            public static IntegerEventParam STEP_NUMBER = new IntegerEventParam("STEP_NUMBER");

            /// <summary>
            /// User ID - value type: string.
            /// </summary>
            public static StringEventParam USER_ID = new StringEventParam("USER_ID");

            /// <summary>
            /// Method - value type: string.
            /// </summary>
            public static StringEventParam METHOD = new StringEventParam("METHOD");

            /// <summary>
            /// Query - value type: string.
            /// </summary>
            public static StringEventParam QUERY = new StringEventParam("QUERY");

            /// <summary>
            /// Search type - value type: string.
            /// </summary>
            public static StringEventParam SEARCH_TYPE = new StringEventParam("SEARCH_TYPE");

            /// <summary>
            /// Social content name - value type: string.
            /// </summary>
            public static StringEventParam SOCIAL_CONTENT_NAME = new StringEventParam("SOCIAL_CONTENT_NAME");

            /// <summary>
            /// Social content ID - value type: string.
            /// </summary>
            public static StringEventParam SOCIAL_CONTENT_ID = new StringEventParam("SOCIAL_CONTENT_ID");

            /// <summary>
            /// Like type - value type: string.
            /// </summary>
            public static StringEventParam LIKE_TYPE = new StringEventParam("LIKE_TYPE");

            /// <summary>
            /// Media name - value type: string.
            /// </summary>
            public static StringEventParam MEDIA_NAME = new StringEventParam("MEDIA_NAME");

            /// <summary>
            /// Media type - value type: string.
            /// </summary>
            public static StringEventParam MEDIA_TYPE = new StringEventParam("MEDIA_TYPE");

            /// <summary>
            /// Media ID - value type: string.
            /// </summary>
            public static StringEventParam MEDIA_ID = new StringEventParam("MEDIA_ID");

            /// <summary>
            /// Duration - value type: int.
            /// </summary>
            public static IntegerEventParam DURATION = new IntegerEventParam("DURATION");

        }

        public class EventParamBase
        {
            public string paramName;

            public EventParamBase(string paramName)
            {
                this.paramName = paramName;
            }

            public override string ToString()
            {
                return paramName;
            }
        }

        public class StringEventParam : EventParamBase
        {
            public StringEventParam(string paramName) : base(paramName) { }
        }

        public class DoubleEventParam : EventParamBase
        {
            public DoubleEventParam(string paramName) : base(paramName) { }
        }

        public class IntegerEventParam : EventParamBase
        {
            public IntegerEventParam(string paramName) : base(paramName) { }
        }

        public class BooleanEventParam : EventParamBase
        {
            public BooleanEventParam(string paramName) : base(paramName) { }
        }

        public class EventParams
        {
            private IDictionary<object, string> parameters = new Dictionary<object, string>();

            public EventParams()
            {
                parameters = new Dictionary<object, string>();
            }

            /// <summary>
            /// Create a parameters map object for logging the standard events.
            /// And copies all of the parameters from the specified map to this map.
            /// </summary>
            /// <param name="parameters"> parameters to be stored in this map
            public EventParams(EventParams paramsSource)
            {
                parameters = new Dictionary<object, string>();
                if (paramsSource.parameters != null)
                {
                    foreach (KeyValuePair<object, string> pair in paramsSource.parameters)
                    {
                        parameters.Add(pair);
                    }
                }
            }

            /// <summary>
            /// Get the map object of the parameters.
            /// </summary>
            /// <returns> the map object of the parameters.
            public IDictionary<object, string> GetParams()
            {
                return parameters;
            }

            /// <summary>
            /// Clear the parameters.
            /// </summary>
            /// <returns> The Params instance.
            public EventParams Clear()
            {
                parameters.Clear();
                return this;
            }

            /// <summary>
            /// Removes the parameter for a key if it is present.
            /// </summary>
            /// <param name="param"> key whose mapping is to be removed
            /// <returns> The Params instance.
            public EventParams Remove(EventParamBase param)
            {
                parameters.Remove(param);
                return this;
            }

            /// <summary>
            /// Removes the parameter for a key if it is present.
            /// </summary>
            /// <param name="key"> key whose mapping is to be removed
            /// <returns> The Params instance.
            public EventParams Remove(string key)
            {
                parameters.Remove(key);
                return this;
            }

            /// <summary>
            /// Copies all of the parameters from the specified map to this map.
            /// </summary>
            /// <param name="parameters"> parameters to be stored in this map
            /// <returns> The Params instance.
            public EventParams PutAll(EventParams paramsSource)
            {
                if (paramsSource.parameters != null)
                {
                    foreach (KeyValuePair<object, string> pair in paramsSource.parameters)
                    {
                        parameters.Add(pair);
                    }
                }
                return this;
            }

            /// <summary>
            /// Put a new parameter with the format of { FlurryEvent.Param, string }.
            /// </summary>
            /// <param name="param"> the enum of the FlurryEvent.Param.
            /// <param name="value"> the value of the parameter.
            /// <returns> The Params instance.
            public EventParams PutString(StringEventParam param, string value)
            {
                parameters.Add(param, value);
                return this;
            }

            /// <summary>
            /// Put a new parameter with the format of { string, string }.
            /// </summary>
            /// <param name="key">   provides the user defined key.
            /// <param name="value"> the value of the parameter.
            /// <returns> The Params instance.
            public EventParams PutString(string key, string value)
            {
                parameters.Add(key, value);
                return this;
            }

            /// <summary>
            /// Put a new parameter with the format of { FlurryEvent.Param, int }.
            /// </summary>
            /// <param name="param"> the enum of the FlurryEvent.Param.
            /// <param name="value"> the value of the parameter.
            /// <returns> The Params instance.
            public EventParams PutInteger(IntegerEventParam param, int value)
            {
                parameters.Add(param, value.ToString());
                return this;
            }

            /// <summary>
            /// Put a new parameter with the format of { string, int }.
            /// </summary>
            /// <param name="key">   provides the user defined key.
            /// <param name="value"> the value of the parameter.
            /// <returns> The Params instance.
            public EventParams PutInteger(string key, int value)
            {
                parameters.Add(key, value.ToString());
                return this;
            }

            /// <summary>
            /// Put a new parameter with the format of { FlurryEvent.Param, Long }.
            /// </summary>
            /// <param name="param"> the enum of the FlurryEvent.Param.
            /// <param name="value"> the value of the parameter.
            /// <returns> The Params instance.
            public EventParams PutLong(IntegerEventParam param, long value)
            {
                parameters.Add(param, value.ToString());
                return this;
            }

            /// <summary>
            /// Put a new parameter with the format of { string, Long }.
            /// </summary>
            /// <param name="key">   provides the user defined key.
            /// <param name="value"> the value of the parameter.
            /// <returns> The Params instance.
            public EventParams PutLong(string key, long value)
            {
                parameters.Add(key, value.ToString());
                return this;
            }

            /// <summary>
            /// Put a new parameter with the format of { FlurryEvent.Param, double }.
            /// </summary>
            /// <param name="param"> the enum of the FlurryEvent.Param.
            /// <param name="value"> the value of the parameter.
            /// <returns> The Params instance.
            public EventParams PutDouble(DoubleEventParam param, double value)
            {
                parameters.Add(param, value.ToString());
                return this;
            }

            /// <summary>
            /// Put a new parameter with the format of { string, double }.
            /// </summary>
            /// <param name="key">   provides the user defined key.
            /// <param name="value"> the value of the parameter.
            /// <returns> The Params instance.
            public EventParams PutDouble(string key, double value)
            {
                parameters.Add(key, value.ToString());
                return this;
            }

            /// <summary>
            /// Put a new parameter with the format of { FlurryEvent.Param, bool }.
            /// </summary>
            /// <param name="param"> the enum of the FlurryEvent.Param.
            /// <param name="value"> the value of the parameter.
            /// <returns> The Params instance.
            public EventParams PutBoolean(BooleanEventParam param, bool value)
            {
                parameters.Add(param, value.ToString());
                return this;
            }

            /// <summary>
            /// Put a new parameter with the format of { string, bool }.
            /// </summary>
            /// <param name="key">   provides the user defined key.
            /// <param name="value"> the value of the parameter.
            /// <returns> The Params instance.
            public EventParams PutBoolean(string key, bool value)
            {
                parameters.Add(key, value.ToString());
                return this;
            }

        }
    }
}