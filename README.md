Flurry Unity SDK
================

This repository packages Flurry Unity SDK 6.2.0 for current Unity projects,
with Android and iOS native SDKs included.

## Installation

1. Import `dist/flurry-sdk-6.2.0.unitypackage` through **Assets > Import
   Package > Custom Package**.
2. Replace the platform API key placeholders in the sample or your own
   initialization code.
3. Add `using FlurrySDK;` and initialize Flurry once at application startup:

```csharp
new Flurry.Builder()
    .WithCrashReporting(true)
    .WithLogEnabled(true)
    .Build(apiKey);
```

The package includes Android AARs and iOS static libraries. The old Android
JAR, Unity 4 package, and custom native wrapper are no longer used.

## Unity 6

The plugin uses Unity's current `UNITY_IOS` platform symbol, while retaining
the legacy symbol as a compatibility fallback. It can be imported into Unity
6 projects through the `.unitypackage`; this repository contains plugin
assets only and does not define a Unity Editor project or editor version.

For event logging, use `Flurry.LogEvent("event_name")`. The full API surface
includes timed and parameterized events, user properties, privacy controls,
remote config, publisher segmentation, and iOS SKAdNetwork support.

The upstream release notes and API examples are available in the official
[Flurry Unity SDK repository](https://github.com/flurry/unity-flurry-sdk).


## License

    Copyright (c) 2015 PRADA Hsiung

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
    Come on, don't tell me you read that.
