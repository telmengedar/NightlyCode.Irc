﻿using System;

namespace NightlyCode.IRC {

    /// <summary>
    /// numeric response types to commands
    /// </summary>
    /// <remarks>
    /// this is not defines as enum as responses are initially strings and a conversion to int just for evaluation would be kind of silly
    /// </remarks>
    public class IrcCommandResponse
    {
        /// <summary>
        /// Welcome to the Internet Relay Network &lt;nick&gt;!&lt;user&gt;@&lt;host&gt;
        /// </summary>
        public const string RPL_WELCOME = "001";

        /// <summary>
        /// Your host is &lt;servername&gt;, running version &lt;ver&gt;
        /// </summary>
        public const string RPL_YOURHOST = "002";

        /// <summary>
        /// This server was created &lt;date&gt;
        /// </summary>
        public const string RPL_CREATED = "003";

        /// <summary>
        /// &lt;servername&gt; &lt;version&gt; &lt;available user modes&gt; &lt;available channel modes&gt;
        /// </summary>
        public const string RPL_MYINFO = "004";

        /// <summary>
        /// Sent by the server to a user to suggest an alternative
        /// server.This is often used when the connection is
        /// refused because the server is already full.
        /// </summary>
        /// <remarks>
        /// Try server &lt;server name&gt;, port &lt;port number&gt;
        /// </remarks>
        public const string RPL_BOUNCE = "005";

        public const string RPL_TRACELINK = "200";

        public const string RPL_TRACECONNECTING = "201";

        public const string RPL_TRACEHANDSHAKE = "202";

        public const string RPL_TRACEUNKNOWN = "203";

        public const string RPL_TRACEOPERATOR = "204";

        public const string RPL_TRACEUSER = "205";

        public const string RPL_TRACESERVER = "206";

        public const string RPL_TRACESERVICE = "207";

        public const string RPL_TRACENEWTYPE = "208";

        public const string RPL_TRACECLASS = "209";

        public const string RPL_TRACERECONNECT = "210";

        public const string RPL_STATSLINKINFO = "211";

        public const string RPL_STATSCOMMANDS = "212";

        public const string RPL_ENDOFSTATS = "219";

        public const string RPL_UMODEIS = "221";

        public const string RPL_SERVLIST = "234";

        public const string RPL_SERVLISTEND = "235";

        public const string RPL_STATSUPTIME = "242";

        public const string RPL_STATSOLINE = "243";

        public const string RPL_LUSERCLIENT = "251";

        public const string RPL_LUSEROP = "252";

        public const string RPL_LUSERUNKNOWN = "253";

        public const string RPL_LUSERCHANNELS = "254";

        public const string RPL_LUSERME = "255";

        public const string RPL_ADMINME = "256";
        public const string RPL_ADMINLOC1 = "257";
        public const string RPL_ADMINLOC2 = "258";
        public const string RPL_ADMINEMAIL = "259";
        public const string RPL_TRACELOG = "261";

        public const string RPL_TRACEEND = "262";

        public const string RPL_TRYAGAIN = "263";
        /// <summary>
        /// &lt;nick&gt; :&lt;away message&gt;
        /// </summary>
        public const string RPL_AWAY = "301";

        /// <summary>
        /// Reply format used by USERHOST to list replies to the query list
        /// </summary>
        public const string RPL_USERHOST = "302";

        /// <summary>
        /// Reply format used by ISON to list replies to the query list.
        /// </summary>
        public const string RPL_ISON = "303";

        public const string RPL_UNAWAY = "305";

        public const string RPL_NOWAWAY = "306";

        public const string RPL_WHOISUSER = "311";

        public const string RPL_WHOISSERVER = "312";

        public const string RPL_WHOISOPERATOR = "313";

        public const string RPL_WHOWASUSER = "314";

        public const string RPL_ENDOFWHO = "315";

        public const string RPL_WHOISIDLE = "317";

        public const string RPL_ENDOFWHOIS = "318";

        public const string RPL_WHOISCHANNELS = "319";

        [Obsolete("Not used")]
        public const string RPL_LISTSTART = "321";

        public const string RPL_LIST = "322";

        public const string RPL_LISTEND = "323";

        public const string RPL_CHANNELMODEIS = "324";

        public const string RPL_UNIQOPIS = "325";

        public const string RPL_NOTOPIC = "331";

        public const string RPL_TOPIC = "332";

        public const string RPL_INVITING = "341";

        public const string RPL_SUMMONING = "342";

        public const string RPL_INVITELIST = "346";

        public const string RPL_ENDOFINVITELIST = "347";

        public const string RPL_EXCEPTLIST = "348";

        public const string RPL_ENDOFEXCEPTLIST = "349";

        public const string RPL_VERSION = "351";

        public const string RPL_WHOREPLY = "352";

        public const string RPL_NAMREPLY = "353";

        public const string RPL_LINKS = "364";

        public const string RPL_ENDOFLINKS = "365";

        public const string RPL_ENDOFNAMES = "366";

        public const string RPL_BANLIST = "367";

        public const string RPL_ENDOFBANLIST = "368";

        public const string RPL_ENDOFWHOWAS = "369";

        public const string RPL_INFO = "371";

        public const string RPL_MOTD = "372";

        public const string RPL_ENDOFINFO = "374";

        public const string RPL_MOTDSTART = "375";

        public const string RPL_ENDOFMOTD = "376";

        public const string RPL_YOUREOPER = "381";

        public const string RPL_REHASHING = "382";

        public const string RPL_YOURESERVICE = "383";

        public const string RPL_TIME = "391";

        public const string RPL_USERSSTART = "392";

        public const string RPL_USERS = "393";

        public const string RPL_ENDOFUSERS = "394";

        public const string RPL_NOUSERS = "395";

        public const string ERR_NOSUCHNICK = "401";

        public const string ERR_NOSUCHSERVER = "402";

        public const string ERR_NOSUCHCHANNEL = "403";

        public const string ERR_CANNOTSENDTOCHAN = "404";

        public const string ERR_TOOMANYCHANNELS = "405";

        public const string ERR_WASNOSUCHNICK = "406";

        public const string ERR_TOOMANYTARGETS = "407";

        public const string ERR_NOSUCHSERVICE = "408";

        public const string ERR_NOORIGIN = "409";

        public const string ERR_NORECIPIENT = "411";

        public const string ERR_NOTEXTTOSEND = "412";

        public const string ERR_NOTOPLEVEL = "413";

        public const string ERR_WILDTOPLEVEL = "414";

        public const string ERR_BADMASK = "415";

        public const string ERR_UNKNOWNCOMMAND = "421";

        public const string ERR_NOMOTD = "422";

        public const string ERR_NOADMININFO = "423";

        public const string ERR_FILEERROR = "424";

        public const string ERR_NONICKNAMEGIVEN = "431";

        public const string ERR_ERRONEUSNICKNAME = "432";

        public const string ERR_NICKNAMEINUSE = "433";

        public const string ERR_NICKCOLLISION = "436";

        public const string ERR_UNAVAILRESOURCE = "437";

        public const string ERR_USERNOTINCHANNEL = "441";

        public const string ERR_NOTONCHANNEL = "442";

        public const string ERR_USERONCHANNEL = "443";

        public const string ERR_NOLOGIN = "444";

        public const string ERR_SUMMONDISABLED = "445";

        public const string ERR_USERSDISABLED = "446";

        public const string ERR_NOTREGISTERED = "451";

        public const string ERR_NEEDMOREPARAMS = "461";

        public const string ERR_ALREADYREGISTRED = "462";

        public const string ERR_NOPERMFORHOST = "463";

        public const string ERR_PASSWDMISMATCH = "464";

        public const string ERR_YOUREBANNEDCREEP = "465";

        public const string ERR_YOUWILLBEBANNED = "466";

        public const string ERR_KEYSET = "467";

        public const string ERR_CHANNELISFULL = "471";

        public const string ERR_UNKNOWNMODE = "472";

        public const string ERR_INVITEONLYCHAN = "473";

        public const string ERR_BANNEDFROMCHAN = "474";

        public const string ERR_BADCHANNELKEY = "475";

        public const string ERR_BADCHANMASK = "476";

        public const string ERR_NOCHANMODES = "477";

        public const string ERR_BANLISTFULL = "478";

        public const string ERR_NOPRIVILEGES = "481";

        public const string ERR_CHANOPRIVSNEEDED = "482";

        public const string ERR_CANTKILLSERVER = "483";

        public const string ERR_RESTRICTED = "484";

        public const string ERR_UNIQOPPRIVSNEEDED = "485";

        public const string ERR_NOOPERHOST = "491";

        public const string ERR_UMODEUNKNOWNFLAG = "501";

        public const string ERR_USERSDONTMATCH = "502";
    }
}