using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.IO.Domain.Eventos.Commands
{
    public class RegistrarEventoCommand : BaseEventoCommand 
    {

        public RegistrarEventoCommand(
           string nome,
           string decCurta,
           string decLonga,
           DateTime dataInicio,
           DateTime dataFim,
           bool gratuito,
           decimal valor,
           bool online,
           string nomeEmpresa,
           Guid organizadorId,
           Guid categoriaId,
           IncluirEnderecoEventoCommand endereco
           )
        {
            Nome = nome;
            DescricaoCurta = decCurta;
            DescricaoLonga = decLonga;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeEmpresa = nomeEmpresa;
            OrganizadorId = organizadorId;
            CategoriaId = categoriaId;
            Endereco = endereco;
        }
        public IncluirEnderecoEventoCommand Endereco { get; private set; }
    }
}
