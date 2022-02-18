using Sistema_Agendamento.Entidades;
using Sistema_Agendamento.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_Agendamento.Data
{
    public class ProcessoRepository : IRepository<Processo>
    {
        private readonly ClienteRepository _clienteRepository;
        public ProcessoRepository(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        private static List<Processo> listaProcessos = new List<Processo>();
        public void Editar(Processo processo)
        {
            listaProcessos.ForEach(p =>
            {
                if (p.ProcessoId == processo.ProcessoId)
                {
                    p.DataInicio = processo.DataInicio;
                    p.EstadoProcessoEnum = processo.EstadoProcessoEnum;
                    p.ClienteId = processo.ClienteId;
                    p.Excluido = processo.Excluido;
                    p.Valor = processo.Valor;
                }
            });
        }

        public void Excluir(int processoId)
        {
            listaProcessos.ForEach(p =>
            {
                if (p.ProcessoId == processoId)
                {
                    p.Excluido = true;
                    _clienteRepository.RemoverProcesso(p);
                }
            });
        }
        public void MudarStatus(int processoId)
        {
            listaProcessos.ForEach(p =>
            {
                if (p.ProcessoId == processoId)
                {
                    p.Status = p.Status == Enum.StatusProcessoEnum.Ativo ? Enum.StatusProcessoEnum.Inativo : Enum.StatusProcessoEnum.Ativo;
                    _clienteRepository.AlterarStatusProcesso(p);
                }
            });
        }

        public void Criar(Processo processo)
        {
            listaProcessos.Add(processo);
            _clienteRepository.InserirProcesso(processo);
        }

        public List<Processo> Listar()
        {
            AtualizarProcessos();

            return listaProcessos
                .Where(p => p.Excluido != true)
                .ToList();
        }

        public void AtualizarProcessos()
        {
            var processos = _clienteRepository.ListarProcessos();

            foreach (var processo in processos)
            {
               if (listaProcessos.Count() == 0 || listaProcessos.Any(p => p.ProcessoId != processo.ProcessoId))
               {
                  listaProcessos.Add(processo);
               }
            }
        }

        public List<Processo> ListarProcessosPorClienteId(int clienteId)
        {
            var processos = listaProcessos
               .Where(c => c.ClienteId == clienteId)
               .ToList();

            return processos
                .Where(p => p.Excluido != true)
                .ToList();
        }

        public Processo RetornaPorId(int processoId)
        {
            return listaProcessos
                .Where(p => p.ProcessoId == processoId)
                .FirstOrDefault();
        }
    }
}
