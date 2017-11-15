using System;
using NightlyCode.IRC;
using NUnit.Framework;

namespace IRC.Tests {

    [TestFixture]
    public class ClientTests {

        [Test, Category("Local Connection")]
        public void Login() {
            Assert.Ignore("Only to be run with a local running server");

            IrcClient client = new IrcClient();
            client.MessageReceived += c => Console.WriteLine(c.ToString());
            client.Connect("localhost");
            client.SendMessage(new IrcMessage("PASS", "test"));
            client.SendMessage(new IrcMessage("NICK", "test"));
            client.SendMessage(new IrcMessage("USER", "test", "0", "*", "Test"));
            client.SendMessage(new IrcMessage("QUIT", "Login Test End"));
            client.Disconnect();
        }
    }
}