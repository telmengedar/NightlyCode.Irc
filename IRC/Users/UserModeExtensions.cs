using System;

namespace NightlyCode.IRC.Users {
    public static class UserModeExtensions {

        public static UserMode Parse(string letter) {
            switch(letter) {
                case "o":
                    return UserMode.Operator;
                case "s":
                    return UserMode.ServerNotices;
                case "i":
                    return UserMode.Invisible;
                case "w":
                    return UserMode.Wallops;
                default:
                    throw new Exception($"unknown user mode {letter}");
            }
        }
    }
}