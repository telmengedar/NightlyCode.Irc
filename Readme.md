# NightlyCode.Irc

Currently this project contains structures necessary to communicate using the IRC protocol.

## Client

The IrcClient class can be used to initiate a connection to an Irc server. Messages received by the server have to be processed in custom code.

### Connect to an Irc server

The following code example shows a class which connects to an irc server and responds to PING messages.

```
public class Example {
	IrcClient client=new IrcClient();

	public Example(){
		client.MessageReceived+=OnMessageReceived;
		client.Connect("irc.someplace.net")
	}

	void OnMessageReceived(IrcMessage message) {
		switch (message.Command) {
			case "PING":
				client.SendMessage(new IrcMessage("PONG", message.Arguments));
				break;
		}
	}
}
```