﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog.Contrib.Targets.WebSocket.CommandHandlers
{
    public interface ICommandHandler
    {
        Boolean CanHandle(String commandName);
        void Handle(JObject command, IWebSocketWrapper wswrapper);
    }
}
