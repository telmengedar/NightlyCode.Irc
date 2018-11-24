using System.Linq;
using System.Text;

namespace NightlyCode.IRC {

    /// <summary>
    /// command sent over irc protocol
    /// </summary>
    public class IrcMessage {

        internal IrcMessage() { }

        /// <summary>
        /// creates a new <see cref="IrcMessage"/>
        /// </summary>
        /// <param name="command">command specifier</param>
        /// <param name="arguments">arguments for command</param>
        public IrcMessage(string command, params string[] arguments) {
            Command = command;
            Arguments = arguments;
        }

        /// <summary>
        /// source of message (optional)
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// command name
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// arguments for command
        /// </summary>
        public string[] Arguments { get; set; }

        /// <summary>
        /// attributes of message
        /// </summary>
        public IrcTag[] Tags { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            if(Tags?.Length > 0)
                sb.Append('@').Append(string.Join(";", Tags.Select(a => a.ToString()))).Append(' ');

            if(Source != null)
                sb.Append(":").Append(Source).Append(' ');
            sb.Append(Command);

            if(Arguments?.Length > 0) {
                foreach(string argument in Arguments.Take(Arguments.Length - 1))
                    sb.Append(' ').Append(argument);

                string lastargument = Arguments.Last();
                if(lastargument.Contains(' '))
                    sb.Append(" :").Append(lastargument);
                else sb.Append(' ').Append(lastargument);
            }
            return sb.ToString();
        }
    }
}