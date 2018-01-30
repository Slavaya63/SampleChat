using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Text;
using WebSocketChat.Communication.Faces;

namespace WebSocketChat.Communication
{
    public class SocketIOManager : ISocketIOManager
    {
        private string Uri { get; } = @"http://10.0.3.2:5555/test";

        Socket _socket;

        private void Connect() => _socket = IO.Socket(Uri);

        private Socket EnsureSocket()
        {
            if (_socket == null)
                Connect();

            return _socket;
        }

        public void JoinToRoom(string userId, string oponentId)
        {
            var msg = new JObject();
            msg.Add("user_id", userId);
            msg.Add("oponent_id", oponentId);

            EnsureSocket().Emit("join", (response) => 
            {
                
            } , msg);
        }
    }
}
