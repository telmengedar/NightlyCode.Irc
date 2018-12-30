using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using NightlyCode.IRC;
using NUnit.Framework;

namespace IRC.Tests {

    [TestFixture]
    public class MessageTests {

        static IEnumerable<string> TestCommands
        {
            get
            {
                yield return ":Macha!~macha@unaffiliated/macha PRIVMSG #botwar :Test response";
                yield return "USER username 0 * :Real name";
                yield return ":source JOIN #channel";
                yield return ":source PART #channel reason";
                yield return ":source PRIVMSG <target> Message";
                yield return ":source QUIT reason";
                yield return "PING message";
                yield return "@aaa=bbb;ccc;example.com/ddd=eee :nick!ident@host.com PRIVMSG me Hello";
                yield return "@ban-reason=Follow\\sthe\\srules :tmi.twitch.tv CLEARCHAT #dallas ronni";
                yield return ":<user>!<user>@<user>.tmi.twitch.tv JOIN #<channel>";
                yield return ":thronezilla!thronezilla@thronezilla.tmi.twitch.tv JOIN #rugenforth";
                yield return ":tmi.twitch.tv HOSTTARGET #rugenforth :xanias 1";
                yield return ":tmi.twitch.tv :tmi.twitch.tv RECONNECT";
            }
        }

        static IEnumerable<Tuple<IrcMessage, string>> TestMessages
        {
            get
            {
                yield return new Tuple<IrcMessage, string>(new IrcMessage("JOIN", "#channel"), "JOIN #channel");
            }
        }

        [Test]
        public void ParseCommand([ValueSource(nameof(TestCommands))] string message) {
            IrcMessage command = IrcParser.Parse(message);
            Assert.AreEqual(message, command.ToString());
        }

        [Test]
        public void GenerateMessage([ValueSource(nameof(TestMessages))] Tuple<IrcMessage, string> message) {
            Assert.AreEqual(message.Item2, message.Item1.ToString());
        }
    }
}