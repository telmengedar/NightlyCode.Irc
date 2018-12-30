namespace NightlyCode.IRC.Channels {

    /// <summary>
    /// mode command types for a channel
    /// </summary>
    public enum ChannelMode {

        /// <summary>
        /// give/take channel operator privileges
        /// </summary>
        Operator,

        /// <summary>
        /// private channel flag
        /// </summary>
        Private,

        /// <summary>
        /// secret channel flag
        /// </summary>
        Secret,

        /// <summary>
        /// invite-only channel flag
        /// </summary>
        InviteOnly,

        /// <summary>
        /// topic settable by channel operator only flag
        /// </summary>
        TopicByOperator,

        /// <summary>
        /// no messages to channel from clients on the outside
        /// </summary>
        NoOutsideMessages,

        /// <summary>
        /// moderated channel
        /// </summary>
        Moderated,

        /// <summary>
        /// set the user limit to channel
        /// </summary>
        UserLimit,

        /// <summary>
        /// set a ban mask to keep users out
        /// </summary>
        BanMask,

        /// <summary>
        /// give/take the ability to speak on a moderated channel
        /// </summary>
        Speak,

        /// <summary>
        /// set a channel key (password)
        /// </summary>
        ChannelKey
    }
}