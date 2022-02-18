using Sistema_Agendamento.Data;
using Sistema_Agendamento.Entidades;
using Sistema_Agendamento.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_Agendamento.Service
{
    public static class ClienteService
    {
        public static ClienteRepository clienteRepository = new ClienteRepository();

        public static void Listar()
        {
            Console.WriteLine("\nClientes\n");

            var lista = clienteRepository.Listar();

            if (lista.Count() == 0)
            {
                Console.WriteLine("Nenhuma Cliente Cadastrado.");
            }
            else
            {
                foreach (var cliente in lista)
                {
                    Console.WriteLine(cliente.ToString());
                }
            }
        }
        public static void CadastrarCliente()
        {
            Console.WriteLine("\nCadastrar Cliente\n");

            Console.Write("Digite o nome da Empresa: ");

            string nomeEmpresa = Console.ReadLine();

            Console.Write("Digite o CNPJ: ");

            string cnpjEmpresa = Console.ReadLine();

            foreach (int i in EstadosEnum.GetValues(typeof(EstadosEnum)))
            {
                Console.WriteLine("{0}-{1}", i, EstadosEnum.GetName(typeof(EstadosEnum), i));
            };

            Console.Write("Digite o estado entre as opções acima: ");

            int estadoEmpresa = int.Parse(Console.ReadLine());

            var novoCliente = new Cliente
            {
                Nome = nomeEmpresa,
                Cnpj = cnpjEmpresa,
                EstadoClienteEnum = (EstadosEnum)estadoEmpresa,
                Excluido = false,
                ClienteId = ClienteRepository.contadorCliente += 1
            };

            clienteRepository.Criar(novoCliente);

            Console.Clear();
        }
        public static void EditarCliente()
        {
            Console.Write("\nDigite o id do Cliente: ");

            int clienteId = int.Parse(Console.ReadLine());

            while (!(clienteRepository.VerificarClienteId(clienteId)))
            {
                Console.Write("Cliente não  encontrado, digite novamente o id do Cliente: ");

                clienteId = int.Parse(Console.ReadLine());
            };

            var cliente = clienteRepository.RetornaPorId(clienteId);

            Console.Clear();

            Console.WriteLine("Deseja realmente editar esse cliente? (S/n)\n");
            Console.WriteLine(cliente.ToString());
            Console.WriteLine();

            var opcaoUsuario = Console.ReadLine().ToUpper();

            if (opcaoUsuario == "S")
            {
                Console.Write("Digite o nome da Empresa: ");

                string nomeEmpresa = Console.ReadLine();

                Console.Write("Digite o CNPJ: ");

                string cnpjEmpresa = Console.ReadLine();

                foreach (int i in EstadosEnum.GetValues(typeof(EstadosEnum)))
                {
                    Console.WriteLine("{0}-{1}", i, EstadosEnum.GetName(typeof(EstadosEnum), i));
                };

                Console.Write("Digite o estado entre as opções acima: ");

                int estadoEmpresa = int.Parse(Console.ReadLine());

                var clienteEditado = new Cliente
                {
                    Nome = nomeEmpresa,
                    Cnpj = cnpjEmpresa,
                    EstadoClienteEnum = (EstadosEnum)estadoEmpresa,
                    Excluido = false,
                    ClienteId = clienteId
                };

                Console.Clear();

                clienteRepository.Editar(clienteEditado);

                Console.WriteLine("Cliente Editado com sucesso, aperte enter para continuar");
                Console.ReadLine();
                Console.Clear();
            }
        }
        public static void ExcluirCliente()
        {
            Console.Write("\nDigite o id do Cliente: ");

            int clienteId = int.Parse(Console.ReadLine());

            while (!(clienteRepository.VerificarClienteId(clienteId)))
            {
                Console.Write("Cliente não  encontrado, digite novamente o id do Cliente: ");

                clienteId = int.Parse(Console.ReadLine());
            }

            var cliente = clienteRepository.RetornaPorId(clienteId);

            Console.Clear();

            Console.WriteLine("Deseja Realmente excluir esse cliente? (S/n)\n");
            Console.WriteLine(cliente.ToString());
            Console.WriteLine();

            var opcaoUsuario = Console.ReadLine().ToUpper();

            if (opcaoUsuario == "S")
            {
                clienteRepository.Excluir(clienteId);

                Console.WriteLine("Cliente excluido com sucesso, aperte enter para continuar");
                Console.ReadLine();
                Console.Clear();
            }
        }
        public static void AdicionarDados()
        {
            var clienteA = new Cliente
            {
                ClienteId = ClienteRepository.contadorCliente += 1,
                Cnpj = "00000000001",
                EstadoClienteEnum = Enum.EstadosEnum.Rio_De_Janeiro,
                Excluido = false,
                Nome = "Empresa A",
            };

            clienteA.Processos = new List<Processo>
            {
                new Processo
                {
                    ClienteId = clienteA.ClienteId,
                    NomeCliente = clienteA.Nome,
                    DataInicio = new DateTime(2007, 10, 10),
                    EstadoProcessoEnum =Enum.EstadosEnum.Rio_De_Janeiro,
                    Excluido = false,
                    NumeroProcesso = "00001CIVELRJ",
                    ProcessoId = ClienteRepository.contadorProcesso += 1,
                    Status = Enum.StatusProcessoEnum.Ativo,
                    Valor = 20000000,
                },
                new Processo
                {
                    ClienteId = clienteA.ClienteId,
                    NomeCliente = clienteA.Nome,
                    DataInicio = new DateTime(2007, 10, 20),
                    EstadoProcessoEnum =Enum.EstadosEnum.Sao_Paulo,
                    Excluido = false,
                    NumeroProcesso = "00002CIVELSP",
                    ProcessoId = ClienteRepository.contadorProcesso += 1,
                    Status = Enum.StatusProcessoEnum.Ativo,
                    Valor = 10000000,

                },
                new Processo
                {
                    ClienteId = clienteA.ClienteId,
                    NomeCliente = clienteA.Nome,
                    DataInicio = new DateTime(2007, 10, 30),
                    EstadoProcessoEnum =Enum.EstadosEnum.Minas_Gerais,
                    Excluido = false,
                    NumeroProcesso = "00003TRABMG",
                    ProcessoId = ClienteRepository.contadorProcesso += 1,
                    Status = Enum.StatusProcessoEnum.Inativo,
                    Valor = 1000000,
                },
                new Processo
                {
                    ClienteId = clienteA.ClienteId,
                    NomeCliente = clienteA.Nome,
                    DataInicio = new DateTime(2007, 11, 10),
                    EstadoProcessoEnum =Enum.EstadosEnum.Rio_De_Janeiro,
                    Excluido = false,
                    NumeroProcesso = "00004CIVELRJ",
                    ProcessoId = ClienteRepository.contadorProcesso += 1,
                    Status = Enum.StatusProcessoEnum.Inativo,
                    Valor = 2000000,
                },
                new Processo
                {
                    ClienteId = clienteA.ClienteId,
                    NomeCliente = clienteA.Nome,
                    DataInicio = new DateTime(2007, 10, 15),
                    EstadoProcessoEnum = Enum.EstadosEnum.Sao_Paulo,
                    Excluido = false,
                    NumeroProcesso = "00005CIVELSP",
                    ProcessoId = ClienteRepository.contadorProcesso += 1,
                    Status = Enum.StatusProcessoEnum.Ativo,
                    Valor = 3500000,
                },
            };

            clienteRepository.Criar(clienteA);

            var clienteB = new Cliente
            {
                ClienteId = ClienteRepository.contadorCliente += 1,
                Cnpj = "00000000002",
                EstadoClienteEnum = Enum.EstadosEnum.Sao_Paulo,
                Excluido = false,
                Nome = "Empresa B",
            };

            clienteB.Processos = new List<Processo>
            {
                new Processo
                {
                    ClienteId = clienteB.ClienteId,
                    NomeCliente = clienteB.Nome,
                    DataInicio = new DateTime(2007, 05, 01),
                    EstadoProcessoEnum =Enum.EstadosEnum.Rio_De_Janeiro,
                    Excluido = false,
                    NumeroProcesso = "00006CIVELRJ",
                    ProcessoId = ClienteRepository.contadorProcesso += 1,
                    Status = Enum.StatusProcessoEnum.Ativo,
                    Valor = 2000000,
                },
                new Processo
                {
                    ClienteId = clienteB.ClienteId,
                    NomeCliente = clienteB.Nome,
                    DataInicio = new DateTime(2007, 06, 2),
                    EstadoProcessoEnum =Enum.EstadosEnum.Rio_De_Janeiro,
                    Excluido = false,
                    NumeroProcesso = "00007CIVELRJ",
                    ProcessoId = ClienteRepository.contadorProcesso += 1,
                    Status = Enum.StatusProcessoEnum.Ativo,
                    Valor = 70000000,

                },
                new Processo
                {
                    ClienteId = clienteB.ClienteId,
                    NomeCliente = clienteB.Nome,
                    DataInicio = new DateTime(2007, 07, 3),
                    EstadoProcessoEnum =Enum.EstadosEnum.Minas_Gerais,
                    Excluido = false,
                    NumeroProcesso = "00008CIVELSP",
                    ProcessoId = ClienteRepository.contadorProcesso += 1,
                    Status = Enum.StatusProcessoEnum.Inativo,
                    Valor = 50000,
                },
                new Processo
                {
                    ClienteId = clienteB.ClienteId,
                    NomeCliente = clienteB.Nome,
                    DataInicio = new DateTime(2007, 08, 04),
                    EstadoProcessoEnum =Enum.EstadosEnum.Rio_De_Janeiro,
                    Excluido = false,
                    NumeroProcesso = "00009CIVELSP",
                    ProcessoId = ClienteRepository.contadorProcesso += 1,
                    Status = Enum.StatusProcessoEnum.Ativo,
                    Valor = 3200000,
                },
                new Processo
                {
                    ClienteId = clienteB.ClienteId,
                    NomeCliente = clienteB.Nome,
                    DataInicio = new DateTime(2007, 10, 15),
                    EstadoProcessoEnum = Enum.EstadosEnum.Amazonas,
                    Excluido = false,
                    NumeroProcesso = "000010TRABAM",
                    ProcessoId = ClienteRepository.contadorProcesso += 1,
                    Status = Enum.StatusProcessoEnum.Inativo,
                    Valor = 100000,
                },
            };

            clienteRepository.Criar(clienteB);
        }
    }
   
}
