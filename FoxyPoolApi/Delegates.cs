namespace FoxyPoolApi
{
    public delegate void SocketIO_State_Changed(SocketIOState oldState, SocketIOState newState);
    public delegate void SocketIO_Connected();
    public delegate void SocketIO_Disconnected(string reason);
    public delegate void SocketIO_Error(string reason);
}
