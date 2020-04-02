using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHub
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(MessageVM messageVM);

        Task UserLogInControl(MessageVM messageVM);



    }
}
