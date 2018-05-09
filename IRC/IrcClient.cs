using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace NightlyCode.IRC {

    /// <summary>
    /// client using irc protocol
    /// </summary>
    public class IrcClient {
        TcpClient client;
        StreamWriter writer;

        /// <summary>
        /// triggered when a command was received
        /// </summary>
        public event Action<IrcMessage> MessageReceived;

        /// <summary>
        /// triggered when client has disconnected
        /// </summary>
        public event Action Disconnected;

        /// <summary>
        /// connects to an irc server
        /// </summary>
        /// <param name="hostname">host to connect to</param>
        /// <param name="port">port of irc server</param>
        public void Connect(string hostname, int port=6667) {
            if(client?.Connected ?? false)
                client.Close();

            client = new TcpClient(hostname, port);
            writer = new StreamWriter(client.GetStream());
            Task.Run(() => ReadMessages(client));
        }

        void ReadMessages(TcpClient tcpclient) {
            try {
                using(StreamReader reader = new StreamReader(tcpclient.GetStream())) {
                    while(tcpclient.Connected) {
                        string line = reader.ReadLine();
                        if(line != null) {
                            IrcMessage message;
                            try {
                                message = IrcParser.Parse(line);
                            }
                            catch(Exception pe) {
                                Logger.Error(this, $"Error parsing irc message '{line}'", pe);
                                continue;
                            }
                            MessageReceived?.Invoke(message);
                        }
                    }
                }
            }
            catch(Exception e) {
                Logger.Error(this, "Error reading messages from server.", e);
            }
            Disconnected?.Invoke();
        }

        /// <summary>
        /// disconnects from irc server
        /// </summary>
        public void Disconnect() {
            client.Close();
        }

        /// <summary>
        /// sends a command to the server
        /// </summary>
        /// <param name="message">command containing irc message</param>
        public void SendMessage(IrcMessage message) {
            writer.WriteLine(message.ToString());
            writer.Flush();
        }
    }
}