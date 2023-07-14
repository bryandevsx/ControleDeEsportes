using ControleDeEsportes.Data;
using ControleDeEsportes.Models;
using K4os.Hash.xxHash;

namespace ControleDeEsportes.Repositorio
{
    public class EspacoRepositorio : IEspacoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public EspacoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public EspacoModel ListarPorId(int id)
        {
            return _bancoContext.Espacos.FirstOrDefault(x => x.Id == id);
        }
        public List<EspacoModel> BuscarTodos()
        {
            return _bancoContext.Espacos.ToList();
        }
        public EspacoModel Adicionar(EspacoModel espaco)
        {
            _bancoContext.Espacos.Add(espaco);
            _bancoContext.SaveChanges();

            return espaco;
        }

        public EspacoModel Atualizar(EspacoModel espaco)
        {
            EspacoModel espacoDB = ListarPorId(espaco.Id);

            if (espacoDB == null) throw new System.Exception("Houve um erro na atualização do espaço");
            
            espacoDB.Empresa = espaco.Empresa;
            espacoDB.Endereco = espaco.Endereco;
            espacoDB.Telefone = espaco.Telefone;

            _bancoContext.Espacos.Update(espacoDB);
            _bancoContext.SaveChanges();
            
            return espacoDB;
        }

        public bool Apagar(int id)
        {
            EspacoModel espacoDB = ListarPorId(id);

            if (espacoDB == null) throw new System.Exception("Houve um erro na deleção do espaço!");

            _bancoContext.Espacos.Remove(espacoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
