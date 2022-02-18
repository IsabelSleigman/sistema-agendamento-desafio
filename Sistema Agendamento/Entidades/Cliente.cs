using Sistema_Agendamento.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Sistema_Agendamento.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public EstadosEnum EstadoClienteEnum { get; set; }
        public List<Processo> Processos { get; set; }
        public bool Excluido { get; set; }

        public override string ToString()
        {
            string retorno = "---------------------------------------------------------\n";
            retorno += "Empresa - " + this.ClienteId + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "CNPJ: " + this.Cnpj + Environment.NewLine;
            retorno += "Estado: " + EstadosEnum.GetName(typeof(EstadosEnum),(int)this.EstadoClienteEnum) + Environment.NewLine;
            retorno += "---------------------------------------------------------\n";  
            return retorno;
        }
    }
}
