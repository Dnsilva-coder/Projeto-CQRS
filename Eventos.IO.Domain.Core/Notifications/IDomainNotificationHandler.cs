﻿using Eventos.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.IO.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNOtificaions();
        List<T> GetNotifications();
    }
}
