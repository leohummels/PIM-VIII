using PIM_VIII.DB;
using PIM_VIII.Models.DTO;

namespace PIM_VIII.Models.PessoaDao.PessoaDao
{
    public class PessoaDao : IPessoaDao
    {
        private readonly AppDbContext _context;
        public PessoaDao(AppDbContext context)
        {
            _context = context;
        }

        public bool Exclua(Pessoa p)
        {
            return false;
        }

        public bool Insira(PessoaDTO p)
        {
            //try
            //{
                //_context.Endereco.Add(p.Endereco);              
                _context.Pessoa.Add(p.Pessoa);              
                _context.SaveChanges();
                return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }
        public bool Aletere(Pessoa p)
        {
            return false;
        }

        public Pessoa Consulte(Pessoa p)
        {
            return new Pessoa();
        }
    }
}
