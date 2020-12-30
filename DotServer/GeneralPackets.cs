
namespace DotServer.GeneralPackets
{
    public sealed class Disconnect : Packet
    {
        public DisconnectReason Reason { get; set; }
    }
}
