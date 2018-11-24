using System;

namespace NightlyCode.IRC.Chat {

    /// <summary>
    /// base implementation of a chat client
    /// </summary>
    public class IrcChatClient {
        readonly IrcClient client = new IrcClient();

        /// <summary>
        /// creates a new <see cref="IrcChatClient"/>
        /// </summary>
        public IrcChatClient() {
            client.Disconnected += () => Disconnected?.Invoke();
            client.MessageReceived += OnMessageReceived;
        }

        /// <summary>
        /// triggered when the client was disconnected from irc server
        /// </summary>
        public event Action Disconnected;

        /// <summary>
        /// triggered when a channel was joined
        /// arguments:
        ///     1.  string  name of channel
        ///     2.  string  name of user joining
        /// </summary>
        public event Action<string, string> ChannelJoined;

        /// <summary>
        /// triggered when a channel was left
        /// arguments:
        ///     1.  string  name of channel
        ///     2.  string  name of user leaving
        /// </summary>
        public event Action<string, string> ChannelLeft;

        /// <summary>
        /// connects to an irc server
        /// </summary>
        /// <param name="hostname">host to connect to</param>
        /// <param name="port">port of irc server</param>
        public void Connect(string hostname, int port = 6667) {
            client.Connect(hostname, port);
        }

        /// <summary>
        /// disconnects from irc server
        /// </summary>
        public void Disconnect() {
            client.Disconnect();
        }

        /// <summary>
        /// joins a channel
        /// </summary>
        /// <param name="channel">name of channel to join</param>
        /// <param name="key">key used to join channel (optional)</param>
        public void Join(string channel, string key=null) {
            if(!string.IsNullOrEmpty(key))
                client.SendMessage(new IrcMessage("JOIN", channel, key));
            else client.SendMessage(new IrcMessage("JOIN", channel));
        }

        void OnMessageReceived(IrcMessage message)
        {
            switch(message.Command) {
                case "PING":
                    client.SendMessage(new IrcMessage("PONG", message.Arguments));
                    break;
                case "JOIN":
                    ChannelJoined?.Invoke(message.Source, message.Arguments[0]);
                    break;
                case "PART":
                    ChannelLeft?.Invoke(message.Source, message.Arguments[0]);
                    break;
            }
        }
    }
}