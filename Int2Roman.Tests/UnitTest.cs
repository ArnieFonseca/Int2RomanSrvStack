using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;

using Int2Roman.ServiceInterface;
using Int2Roman.ServiceModel;
using Int2Roman.Lib;

namespace Int2Roman.Tests;

public class UnitTest
{
    private readonly ServiceStackHost appHost;

    public UnitTest()
    {
        appHost = new BasicAppHost().Init();

        //Wire up the IoC for the dependency Injection
        appHost.Container.AddTransient<Int2RomanService>();
        appHost.Container.AddTransient<IInt2Roman, IntToRoman>();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown() => appHost.Dispose();


    [Test]
    public void Int2RomanTestWithZero
        ()
    {
        var service = appHost.Container.Resolve<Int2RomanService>();

        var response = service.Post(new Int2RomanDTO { Number = 0 });

        Assert.That(response.ResponseStatus.ErrorCode, Is.EqualTo("GreaterThan"));
    }

    [Test]
    public void Int2RomanTestMaxLimit
        ()
    {
        var service = appHost.Container.Resolve<Int2RomanService>();

        var response = service.Post(new Int2RomanDTO { Number = 1_000_001 });

        Assert.That(response.ResponseStatus.ErrorCode, Is.EqualTo("LessThanOrEqual"));
    }

    [Test]
    public void Int2RomanTestWithFour()
    {
        var service = appHost.Container.Resolve<Int2RomanService>();

        var response = service.Post(new Int2RomanDTO { Number = 4 });

        Assert.That(response.Result, Is.EqualTo("IV"));
    }
    [Test]
    public void Int2RomanTestFortyNine()
    {
        var service = appHost.Container.Resolve<Int2RomanService>();

        var response = service.Post(new Int2RomanDTO { Number = 49 });

        Assert.That(response.Result, Is.EqualTo("XLIX"));
    }
    [Test]
    public void Int2RomanTestSeventyTwo()
    {
        var service = appHost.Container.Resolve<Int2RomanService>();

        var response = service.Post(new Int2RomanDTO { Number = 72 });
        Assert.That(response.Result, Is.EqualTo("LXXII"));


    }
}