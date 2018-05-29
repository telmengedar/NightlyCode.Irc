using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NightlyCode.IRC {

    /// <summary>
    /// parser for <see cref="IrcMessage"/>s
    /// </summary>
    public static class IrcParser {

        static string Unescape(string value) {
            StringBuilder sb=new StringBuilder();
            for(int i = 0; i < value.Length; ++i) {
                switch(value[i]) {
                    case '\\':
                        if(++i < value.Length) {
                            switch(value[i]) {
                                case 's':
                                    sb.Append(' ');
                                    break;
                                case 'r':
                                    sb.Append('\r');
                                    break;
                                case 'n':
                                    sb.Append('\n');
                                    break;
                                case ':':
                                    sb.Append(';');
                                    break;
                                default:
                                    sb.Append(value[i]);
                                    break;

                            }
                        }
                        break;
                    default:
                        sb.Append(value[i]);
                        break;
                }
            }
            return sb.ToString();
        }

        static IrcTag ParseTag(string tag) {
            Match match = Regex.Match(tag, "((?<vendor>.+)/)?(?<key>[^=]+)(=(?<value>.+))?");
            return new IrcTag(match.Groups["vendor"].Value, match.Groups["key"].Value, Unescape(match.Groups["value"].Value));
        }

        static IEnumerable<string> ParseArguments(string messagetext, int offset) {
            while(offset < messagetext.Length) {
                if(messagetext[offset] == ':') {
                    yield return messagetext.Substring(offset + 1);
                    yield break;
                }

                int nextindex = messagetext.IndexOf(' ', offset);
                if(nextindex == -1) {
                    yield return messagetext.Substring(offset);
                    yield break;
                }

                yield return messagetext.Substring(offset, nextindex - offset);
                offset = nextindex + 1;
            }
        }

        /// <summary>
        /// parses an <see cref="IrcMessage"/> from a string
        /// </summary>
        /// <param name="messagetext">message received by server</param>
        /// <returns>command parsed from message</returns>
        public static IrcMessage Parse(string messagetext) {
            if(string.IsNullOrEmpty(messagetext))
                throw new ArgumentException("messagetext is empty");

            int offset = 0;
            int nextindex = 0;
            IrcMessage message = new IrcMessage();
            if(messagetext[0] == '@') {
                nextindex = messagetext.IndexOf(' ');
                message.Tags = messagetext.Substring(1, nextindex - 1).Split(';').Select(ParseTag).ToArray();
                offset = nextindex + 1;
            }

            if(messagetext[offset] == ':') {
                nextindex = messagetext.IndexOf(' ', offset);
                message.Source = messagetext.Substring(offset + 1, nextindex - offset - 1);
                offset = nextindex + 1;
            }

            nextindex = messagetext.IndexOf(' ', offset);
            if(nextindex == -1) {
                message.Command = messagetext;
                message.Arguments = new string[0];
            }
            else {
                message.Command = messagetext.Substring(offset, nextindex - offset);
                offset = nextindex + 1;

                message.Arguments = ParseArguments(messagetext, offset).ToArray();
            }
            return message;
        }
    }
}