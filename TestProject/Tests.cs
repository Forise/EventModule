using System;
using NUnit.Framework;
using EventModule;
using EventModule.Example;

namespace TestProject
{
    [TestFixture]
    public class Tests
    {
        private bool responceGot = false;
        private readonly ExampleGameEventModule module = new ExampleGameEventModule();
        
        [Test]
        public void Test1()
        {
            module.SubscribeT(ExampleEnum.Test1, Test1Response);
            Assert.True(module.exampleEventObserver.Subscribes.ContainsKey(ExampleEnum.Test1));
        }

        private void Test1Response(object sender, GameEventArgs<ExampleEnum> e)
        {
            responceGot = true;
            Assert.True(true, "called from notification");
        }

        [Test]
        public void Test2()
        {
            module.NotifyT(this, new GameEventArgs<ExampleEnum>(ExampleEnum.Test1));
            Assert.IsTrue(responceGot);
        } 
    }
}