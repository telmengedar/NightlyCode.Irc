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

        [Test]
        public void Bla() {
            float[] values = new float[25];
            for(int y=-2;y<3;++y)
                for(int x = -2; x < 3; ++x) {
                    values[(y + 2) * 5 + (x + 2)] = (float)Math.Pow((x * x + y * y), 0.3);
                }

            values[0] = 0.0f;
            values[4] = 0.0f;
            values[20] = 0.0f;
            values[24] = 0.0f;

            /*float max = values.Max();
            for(int i = 0; i < values.Length; ++i)
                values[i] = max - values[i];*/

            float sum = values.Sum();
            for(int i = 0; i < values.Length; ++i)
                values[i] = values[i] / sum;
        }
    }
}