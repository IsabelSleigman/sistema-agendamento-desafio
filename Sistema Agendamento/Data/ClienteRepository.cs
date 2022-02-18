using Sistema_Agendamento.Entidades;
using Sistema_Agendamento.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_Agendamento.Data
{
    public class ClienteRepository : IRepository<Cliente>
    {
        public static int contadorCliente = 0;
        public static int contadorProcesso = 0;

        private static List<Cliente> listaClientes = new List<Cliente>();
        public void Editar(Cliente cliente)
        {
            listaClientes.ForEach(c =>
            {
                if (c.ClienteId == cliente.ClienteId)
                {
                    c.Cnpj = cliente.Cnpj;
                    c.EstadoClienteEnum = cliente.EstadoClienteEnum;
                    c.Nome = cliente.Nome;
                    c.Excluido = cliente.Excluido;
                }
            });
        }

        public void Excluir(int clienteId)
        {
            listaClientes.ForEach(c =>
            {
                if (c.ClienteId == clienteId)
                {
                    c.Excluido = true;
                }
            });
        }

        public void Criar(Cliente cliente)
        {
            listaClientes.Add(cliente);
        }

        public List<Cliente> Listar()
        {
            return listaClientes
                .Where(c => c.Excluido != true)
                .ToList();
        }

        public Cliente RetornaPorId(int ClienteId)
        {
            return listaClientes
                .Where(c => c.ClienteId == ClienteId)
                .FirstOrDefault();
        }

        public void RemoverProcesso(Processo processo)
        {
            listaClientes.ForEach(c =>
            {
                if (c.ClienteId == processo.ClienteId)
                {
                    c.Processos.Remove(processo);
                }
            });
        }

        public void InserirProcesso(Processo processo)
        {
            listaClientes.ForEach(c =>
            {
                if (c.ClienteId == processo.ClienteId)
                {
                    c.Processos.Add(processo);
                }
            });
        }
        public void AlterarStatusProcesso(Processo processoAlterado)
        {
            listaClientes.ForEach(c =>
            {
                if (c.ClienteId == processoAlterado.ClienteId)
                {
                    var processo = c.Processos
                        .Where(p => p.ProcessoId == processoAlterado.ProcessoId)
                        .FirstOrDefault();

                    processo.Status = processoAlterado.Status;

                    c.Processos[processo.ProcessoId] = processo;
                }
            });
        }

        public List<Processo> ListarProcessosPorClienteId(int clienteId)
        {
            var processos = listaClientes
                .Where(c => c.ClienteId == clienteId)
                .Select(c => c.Processos)
                .FirstOrDefault();

            return processos
                .Where(p => p.Excluido != true)
                .ToList();
        }

        public List<Processo> ListarProcessos()
        {
            var listaProcesso = new List<Processo>();

            var processosClientes = listaClientes
            .Where(c => c.Excluido != true)
            .Select(c => c.Processos)
            .ToList();

           if(processosClientes.Count > 0)
           {
               foreach (var processos in processosClientes)
               {
                    listaProcesso.AddRange(processos);
               }
           }

            return listaProcesso;
        }
        public bool VerificarClienteId(int clienteId)
        {
            return listaClientes
            .Any(c => c.ClienteId == clienteId && c.Excluido != true);
        }
    }
}
