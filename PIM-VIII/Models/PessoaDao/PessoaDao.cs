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

        public bool Exclua(PessoaDTO p)
        {
            var listaPessoa = _context.Pessoa.ToList();
            var pessoa = listaPessoa.FirstOrDefault(x => x.Nome);

            listaPessoa.Remove(pessoa);
            _context.SaveChanges();
            return true;
        }

        public bool Insira(PessoaDTO p)
        {
            try
            {
                p.Pessoa.Id = GetMaxId("pessoa");
                p.Pessoa.Telefone.Id = GetMaxId("telefone");
                p.Pessoa.Endereco.Id = GetMaxId("endereco");
                var tipoTelefone = _context.TipoTelefone.ToList().FirstOrDefault(x => x.Id == p.Pessoa.Telefone.TipoTelefone.Id);
                _context.Telefone.AddRange(new Telefone {
                                            Id = p.Pessoa.Telefone.Id,
                                            DDD = p.Pessoa.Telefone.DDD,
                                            Numero = p.Pessoa.Telefone.Numero,
                                            TipoTelefone = tipoTelefone
                                           });

                _context.Telefone.Add(p.Pessoa.Telefone);
                _context.Pessoa.Add(p.Pessoa);              
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Aletere(PessoaDTO p)
        {
            var tipoTelefone = _context.TipoTelefone.ToList().FirstOrDefault(x => x.Id == p.Pessoa.Telefone.TipoTelefone.Id);
            _context.Telefone.AddRange(new Telefone
            {
                Id = p.Pessoa.Telefone.Id,
                DDD = p.Pessoa.Telefone.DDD,
                Numero = p.Pessoa.Telefone.Numero,
                TipoTelefone = tipoTelefone
            });

            _context.Telefone.Add(p.Pessoa.Telefone);
            _context.Pessoa.Add(p.Pessoa);
            _context.SaveChanges();
            
            return true;
        }

        public Pessoa Consulte(PessoaDTO p)
        {
            var pessoa = _context.Pessoa.ToList().FirstOrDefault(x => x.Nome == p.Pessoa.Nome);
            if (pessoa == null)
            {
                return new Pessoa
                {
                    Nome = p.Pessoa.Nome,
                    Id = 0,
                };
            } else
            {
                return pessoa;
            }
        }

        public List<Pessoa> ConsulteTodos()
        {
            return _context.Pessoa.ToList();
        }

        private int GetMaxId(string obj)
        {
            int maxId = 0;
            switch(obj)
            {
                case "pessoa":                 
                    maxId = _context.Pessoa.ToList().Select(x => x.Id).Max() + 1;
                    break;
                case "telefone":
                    maxId = _context.Telefone.ToList().Select(x => x.Id).Max() + 1;
                    break;
                case "endereco":
                    maxId = _context.Endereco.ToList().Select(x => x.Id).Max() + 1;
                    break;
                case "tipoTelefone":
                    maxId = _context.TipoTelefone.ToList().Select(x => x.Id).Max() + 1;
                    break;
                default: return maxId;
            }
            return maxId;
        }
    }
}
