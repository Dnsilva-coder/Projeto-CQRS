﻿using Eventos.IO.Domain.Core.Events;

namespace Eventos.IO.Domain.Eventos.Events
{
    public class EventoEventHandler :
        IHandler<EventoRegistradoEvent>,
        IHandler<EventoAtualizadoEvent>,
        IHandler<EventoExcluidoEvent>
    {
        public void Handle(EventoRegistradoEvent message)
        {
            // Enviar um e-mail
        }

        public void Handle(EventoAtualizadoEvent message)
        {
            // Enviar um e-mail  
        }

        public void Handle(EventoExcluidoEvent message)
        {
            // Enviar um e-mail
        }
    }
}
