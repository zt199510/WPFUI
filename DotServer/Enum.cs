using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotServer
{
    public enum DisconnectReason : byte
    {
        Unknown,
        TimedOut,
        WrongVersion,
        ServerClosing,
        AnotherUser,
        AnotherUserPassword,
        AnotherUserAdmin,
        Banned,
        Crashed
    }
}
