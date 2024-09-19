using AutoMapper;
using Eventos.IO.Application.Interfaces;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Eventos.Commands;
using Eventos.IO.Domain.Eventos.Repository;

namespace Eventos.IO.Application.Services
{
    public class EventoAppService : IEventoAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IEventoRepository _repository;
        public EventoAppService(IBus ibus,IMapper mapper,IEventoRepository eventoRepository)
        {
            _bus = ibus;
            _mapper = mapper;
            _repository = eventoRepository;
        }
        public void Registrar(EventoViewModel eventoViewModel)
        {
            var regisroCommand = _mapper.Map<RegistrarEventoCommand>(eventoViewModel);
            _bus.SendCommand(regisroCommand);
        }
        public void Atualizar(EventoViewModel eventoViewModel)
        {
            var AtualizarCommand = _mapper.Map<AtualizarEventoCommand>(eventoViewModel);
            _bus.SendCommand(AtualizarCommand);
        }

        public void Excluir(Guid id)
        {
            _bus.SendCommand(new ExcluirEventoCommand(id));
        }
        public EventoViewModel obterPorId(Guid id)
        {
            return _mapper.Map<EventoViewModel>(_repository.ObterPorId(id));
        }
        public IEnumerable<EventoViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<EventoViewModel>>(_repository.ObterTodos());
        }

        public IEnumerable<EventoViewModel> ObterEventoPorOrganizador(Guid organizadorId)
        {
            return _mapper.Map<IEnumerable<EventoViewModel>>(_repository.ObterEventoPorOrganizador(organizadorId));
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
