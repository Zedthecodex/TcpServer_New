﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Class
{
    [Serializable]
    public class ChatMessagePacket : Packet
    {
        public string message = String.Empty;
        public ChatMessagePacket(string message)
        {
            this.type = PacketType.CHATMESSAGE;
            this.message = message;
        }
         
    }
}
