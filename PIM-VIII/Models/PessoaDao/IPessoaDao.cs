using PIM_VIII.Models.DTO;

namespace PIM_VIII.Models.PessoaDao.PessoaDao
{
    public interface IPessoaDao
    {

        public bool Exclua(PessoaDTO p)
        {
            return false;
        }
        public bool Insira(PessoaDTO p)
        {
            return false;
        }
        public bool Aletere(PessoaDTO p)
        {
            return false;
        }
        public PessoaDTO Consulte(PessoaDTO p)
        {
            return new PessoaDTO();
        }

        public List<Pessoa> ConsulteTodos()
        {
            return new List<Pessoa>();
        }
    }
}