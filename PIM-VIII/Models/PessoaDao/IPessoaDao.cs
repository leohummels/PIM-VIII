using PIM_VIII.Models.DTO;

namespace PIM_VIII.Models.PessoaDao.PessoaDao
{
    public interface IPessoaDao
    {

        public bool Exclua(int p)
        {
            return false;
        }
        public bool Insira(PessoaDTO p)
        {
            return false;
        }
        public bool Aletere(PessoaDTO p, int i)
        {
            return false;
        }
        public Pessoa Consulte(int p)
        {
            return new Pessoa();
        }

        public List<Pessoa> ConsulteTodos()
        {
            return new List<Pessoa>();
        }
    }
}