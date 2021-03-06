﻿using System;

namespace NetIRC
{
    public class Server
    {
        public string HostName
        {
            get;
            private set;
        }

        public int Port
        {
            get;
            private set;
        }

        public Server(string hostName, int port)
        {
            this.HostName = hostName;
            this.Port = port;
        }

        public Messages.Send.MotdMessage Motd()
        {
            return new Messages.Send.MotdMessage();
        }

        public delegate void OnWelcomeHandler(Server server, string message);
        public event OnWelcomeHandler OnWelcome;

        internal void TriggerOnWelcome(string message)
        {
            if (OnWelcome != null)
            {
                OnWelcome(this, message);
            }
        }

        public delegate void OnWhoHandler(Server server, string message);
        public event OnWelcomeHandler OnWho;

        internal void TriggerOnWho(string message)
        {
            if (OnWho != null)
            {
                OnWho(this, message);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", this.HostName, this.Port);
        }
    }
}
