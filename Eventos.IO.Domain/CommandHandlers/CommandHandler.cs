
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Interfaces;
using FluentValidation.Results;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Eventos.IO.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _ouw;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notificationHandler;
        protected CommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> domainNotificationHandler)
        {
            _ouw = uow;
            _bus = bus;
            _notificationHandler = domainNotificationHandler;
        }
        protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
               
            }
        }

        protected bool Commit()
        {
            //TODO: Validar se há alguma validaçao de negocio com erro!
            if (_notificationHandler.HasNOtificaions()) return false;
            var commandResponse = _ouw.Commit();
            if (commandResponse.Success)return true;

            Console.WriteLine("Ocorreu um erro ao salvar os dados no banco");
            _bus.RaiseEvent(new DomainNotification("Commit", "Ocorreu um erro ao salvar is dadis no banco"));
            return false;
        }
    }
}
