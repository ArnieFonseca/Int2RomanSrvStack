using Funq;
using ServiceStack;
using NUnit.Framework;
using Int2Roman.ServiceInterface;
using Int2Roman.ServiceModel;
using Int2Roman.Lib;
using System;

namespace Int2Roman.Tests;

public class IntegrationTest
{
    const string BaseUri = "http://localhost:2000/";
    private readonly ServiceStackHost appHost;

    class AppHost : AppSelfHostBase
    {
        public AppHost() : base(nameof(IntegrationTest), typeof(Int2RomanService).Assembly) { }

        public override void Configure(Container container)
        {
        }
    }

    public IntegrationTest()
    {
        appHost = new AppHost()
            .Init()
            .Start(BaseUri);

        HostContext.AppHost.Container.Register<IInt2Roman>(new IntToRoman());
    }

    [OneTimeTearDown]
    public void OneTimeTearDown() => appHost.Dispose();

    public IServiceClient CreateClient() => new JsonServiceClient(BaseUri);

    [Test]
    public void Test67()
    {
        var client = CreateClient();

        var response = client.Post(new Int2RomanDTO { Number = 67});

        Assert.That(response.Result, Is.EqualTo("LXVII"));
    }
    [Test]
    public void Test99()
    {
        var client = CreateClient();

        var response = client.Post(new Int2RomanDTO { Number = 99 });

        Assert.That(response.Result, Is.EqualTo("XCIX"));
    }
    [Test]
    public void TestZero()
    {
        var client = CreateClient();

        try
        {
            var response = client.Post(new Int2RomanDTO { Number = 0 });
        }
        catch (System.Exception e)
        {

            Assert.Pass(e.Message);
            return;
        }

        Assert.Fail();
    }
}