using System.Collections.Generic;

using FlurrySDK;

using NUnit.Framework;

public class FlurryApiTests
{
    [Test]
    public void BuilderInitializesWithoutNativePlatform()
    {
        Assert.DoesNotThrow(() => new Flurry.Builder()
            .WithCrashReporting()
            .WithContinueSessionMillis(10000)
            .WithLogEnabled()
            .Build("test-api-key"));
    }

    [Test]
    public void LogEventReturnsRecordedStatus()
    {
        Flurry.EventRecordStatus status = Flurry.LogEvent("unity_test_event");

        Assert.That(status, Is.EqualTo(Flurry.EventRecordStatus.FlurryEventRecorded));
    }

    [Test]
    public void ParameterizedTimedEventReturnsRecordedStatus()
    {
        IDictionary<string, string> parameters = new Dictionary<string, string>
        {
            { "source", "unity-test" },
            { "status", "passed" }
        };

        Flurry.EventRecordStatus status = Flurry.LogEvent("unity_test_timed_event", parameters, true);

        Assert.That(status, Is.EqualTo(Flurry.EventRecordStatus.FlurryEventRecorded));
        Assert.DoesNotThrow(() => Flurry.EndTimedEvent("unity_test_timed_event"));
    }
}
