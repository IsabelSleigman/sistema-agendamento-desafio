using Sistema_Agendamento.Entidades;
using Sistema_Agendamento.Enum;
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
            AtualizarProcessos();

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
            AtualizarProcessos();

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
            AtualizarProcessos();

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
            AtualizarProcessos();

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
               if (listaProcessos.Count() == 0 || !(listaProcessos.Any(p => p.ProcessoId == processo.ProcessoId)))
               {
                  listaProcessos.Add(processo);
               }
            }
        }

        public List<Processo> ListarProcessosPorClienteId(int clienteId)
        {
            AtualizarProcessos();

            var processos = listaProcessos
               .Where(c => c.ClienteId == clienteId)
               .ToList();

            return processos
                .Where(p => p.Excluido != true)
                .ToList();
        }

        public Processo RetornaPorId(int processoId)
        {
            AtualizarProcessos();

            return listaProcessos
                .Where(p => p.ProcessoId == processoId)
                .FirstOrDefault();
        }
        public bool VerificarProcessoId(int processoId)
        {
            return listaProcessos
            .Any(p => p.ProcessoId == processoId && p.Excluido != true);
        }
        public double CalcularSomaProcessosAtivos()
        {
            AtualizarProcessos();

            return listaProcessos
                .Where(p => p.Status == StatusProcessoEnum.Ativo)
                .Select(p => p.Valor)
                .Sum();
        }

        public double CalcularMediaPorEstado(EstadosEnum estado, int clienteId)
        {
            AtualizarProcessos();

            var processosEstadoEspecifico = listaProcessos
                .Where(p => p.ClienteId == clienteId && p.EstadoProcessoEnum == estado)
                .Select(p => p.Valor)
                .ToList();

            if(processosEstadoEspecifico.Count > 0)
            {
                var quantidadeProcessos = processosEstadoEspecifico.Count();

                var valorTotal = processosEstadoEspecifico.Sum();

                var media = valorTotal / quantidadeProcessos;

                return media;
            }
            else
            {
                return 0;
            }
        }
        public List<string> ListarProcessosMesAno(int mes, int ano)
        {
            AtualizarProcessos();

            return listaProcessos
                .Where(p => p.DataInicio.Year == ano && p.DataInicio.Month == mes)
                .Select(p => p.NumeroProcesso)
                .ToList();
        }
    }
}
