# Unity Tests

`Editor/FlurryApiTests.cs` contains Unity Test Framework coverage for the
public Flurry initialization and event APIs.

To run the tests:

1. Import `dist/flurry-sdk-6.2.0.unitypackage` into a Unity 6 project.
2. Copy `Tests/Editor/FlurryApiTests.cs` into that project's `Assets/Tests/Editor`
   directory.
3. Open **Window > General > Test Runner**, choose **EditMode**, and run
   `FlurryApiTests`.

The tests use the editor fallback, so they do not send analytics or require a
platform API key. Android and iOS native integration still requires a device
build for end-to-end verification.
