using System;

namespace NightlyCode.IRC.Channels {
    public static class ChannelModeExtensions {

        public static ChannelMode Parse(string letter) {
            switch(letter) {
                case "o":
                    return ChannelMode.Operator;
                case "p":
                    return ChannelMode.Private;
                case "s":
                    return ChannelMode.Secret;
                case "i":
                    return ChannelMode.InviteOnly;
                case "t":
                    return ChannelMode.TopicByOperator;
                case "n":
                    return ChannelMode.NoOutsideMessages;
                case "m":
                    return ChannelMode.Moderated;
                case "l":
                    return ChannelMode.UserLimit;
                case "b":
                    return ChannelMode.BanMask;
                case "v":
                    return ChannelMode.Speak;
                case "k":
                    return ChannelMode.ChannelKey;
                default:
                    throw new Exception($"unknown channel mode {letter}");
            }
        }
    }
}