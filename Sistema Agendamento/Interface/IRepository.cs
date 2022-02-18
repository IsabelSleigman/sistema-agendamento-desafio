using System.Collections.Generic;

namespace Sistema_Agendamento.Interface
{
    public interface IRepository<T>
    {
        List<T> Listar();
        T RetornaPorId(int id);
        void Criar(T entidade);
        void Excluir(int id);
        void Editar(T entidade);
    }
}
