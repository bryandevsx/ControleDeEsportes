using ControleDeEsportes.Models;

namespace ControleDeEsportes.Repositorio
{
    public interface IEspacoRepositorio
    {
        EspacoModel ListarPorId(int id);
        List<EspacoModel> BuscarTodos();
        EspacoModel Adicionar(EspacoModel espaco);
        EspacoModel Atualizar(EspacoModel espaco);
        bool Apagar(int id);
    }
}
