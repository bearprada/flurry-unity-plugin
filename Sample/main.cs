using UnityEngine;
using FlurrySDK;

public class Main : MonoBehaviour
{
#if UNITY_ANDROID
    private const string FlurryApiKey = "FLURRY_ANDROID_API_KEY";
#elif UNITY_IOS || UNITY_IPHONE
    private const string FlurryApiKey = "FLURRY_IOS_API_KEY";
#else
    private const string FlurryApiKey = null;
#endif

    private void Start()
    {
        new Flurry.Builder()
            .WithCrashReporting(true)
            .WithLogEnabled(true)
            .Build(FlurryApiKey);
    }

    private void Update()
    {
        if (Time.frameCount % 300 == 0)
        {
            Flurry.LogEvent("test_update");
        }
    }
}
