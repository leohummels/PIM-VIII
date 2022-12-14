using PIM_VIII.DB;
using PIM_VIII.Models.DTO;
using System.ComponentModel;

namespace PIM_VIII.Models.PessoaDao.PessoaDao
{
    public class PessoaDao : IPessoaDao
    {
        private readonly AppDbContext _context;
        public PessoaDao(AppDbContext context)
        {
            _context = context;
        }

        public bool Exclua(int i)
        {
            //Pessoa pessoaDTO = p.Pessoa;
            var listaPessoa = _context.Pessoa.ToList();
            var pessoa = _context.Pessoa.ToList().FirstOrDefault(x => x.Id == i);
            var telefoneId = _context.Telefone.ToList().FirstOrDefault(x => x.Id == i);
            var enderecoId = _context.Endereco.ToList().FirstOrDefault(x => x.Id == i);
            _context.Pessoa.Remove(pessoa);
            _context.Telefone.Remove(telefoneId);
            _context.Endereco.Remove(enderecoId);
            _context.SaveChanges();
            return true;
        }

        public bool Insira(PessoaDTO p)
        {
            var tipoTelefone = _context.TipoTelefone.ToList().FirstOrDefault(x => x.Tipo == p.Tipo);
            Telefone telefone = new Telefone
            {
                Numero = p.Numero,
                DDD = p.DDD,
                TipoTelefone = tipoTelefone

            };
            Endereco endereco = new Endereco
            {
                Bairro = p.Bairro,
                Logradouro = p.Logradouro,
                Cidade = p.Cidade,
                Estado = p.Estado,
                Cep = p.Cep,
                Numero = p.NumeroEndereco
            };
            Pessoa pessoaDTO = new Pessoa
            {
                Nome = p.Nome,
                Cpf = p.Cpf,
                Endereco = endereco,
                Telefone = telefone
            };

            if(_context.Pessoa.ToList().Count() == 0)
            {
                pessoaDTO.Id = 1;
                pessoaDTO.Telefone.Id = 1;
                pessoaDTO.Endereco.Id = 1;
            } else
            {
                pessoaDTO.Id = GetMaxId("pessoa");
                pessoaDTO.Telefone.Id = GetMaxId("telefone");
                pessoaDTO.Endereco.Id = GetMaxId("endereco");

                                                    
            }

            _context.Telefone.AddRange(new Telefone {
                Id = pessoaDTO.Telefone.Id,
                DDD = pessoaDTO.Telefone.DDD,
                Numero = pessoaDTO.Telefone.Numero,
                TipoTelefone = tipoTelefone
            });
            _context.Pessoa.Add(new Pessoa {
                Id = pessoaDTO.Id,
                Nome = pessoaDTO.Nome,
                Cpf = pessoaDTO.Cpf,
                Telefone = pessoaDTO.Telefone,
                Endereco = pessoaDTO.Endereco });
            _context.SaveChanges();
            AdicionaPessoaTelefone(pessoaDTO.Id, pessoaDTO.Telefone.Id);
            return true;
        }

        private bool AdicionaPessoaTelefone(int pessoaId, int TelefoneId)
        {   
           _context.PessoaTelefone.AddRange(new PessoaTelefone {
                                             Id = GetMaxId("pessoaTelefone"),
                                             Id_Pessoa= pessoaId,
                                             Id_Telefone = TelefoneId
                                             });
            _context.SaveChanges();
            return true;
        }

        public bool Aletere(PessoaDTO p, int i)
        {
            var pessoa = _context.Pessoa.ToList().FirstOrDefault(x => x.Id == i);
            var telefoneId = _context.Telefone.ToList().FirstOrDefault(x => x.Id == i);
            var enderecoId = _context.Endereco.ToList().FirstOrDefault(x => x.Id == i);
            _context.Pessoa.Remove(pessoa);
            _context.Telefone.Remove(telefoneId);
            _context.Endereco.Remove(enderecoId);
            _context.SaveChanges();

            var tipoTelefone = _context.TipoTelefone.ToList().FirstOrDefault(x => x.Tipo == p.Tipo);
            Telefone telefone = new Telefone
            {
                Numero = p.Numero,
                DDD = p.DDD,
                TipoTelefone = tipoTelefone

            };
            Endereco endereco = new Endereco
            {
                Bairro = p.Bairro,
                Logradouro = p.Logradouro,
                Cidade = p.Cidade,
                Estado = p.Estado,
                Cep = p.Cep,
                Numero = p.NumeroEndereco
            };
            Pessoa pessoaDTO = new Pessoa
            {
                Nome = p.Nome,
                Cpf = p.Cpf,
                Endereco = endereco,
                Telefone = telefone
            };

            pessoaDTO.Id = i;
            pessoaDTO.Telefone.Id = telefoneId.Id;
            pessoaDTO.Endereco.Id = enderecoId.Id;
            AdicionaPessoaTelefone(pessoaDTO.Id, pessoaDTO.Telefone.Id);

            _context.Telefone.AddRange(new Telefone
            {
                Id = pessoaDTO.Telefone.Id,
                DDD = pessoaDTO.Telefone.DDD,
                Numero = pessoaDTO.Telefone.Numero,
                TipoTelefone = tipoTelefone
            });
            _context.Pessoa.Add(new Pessoa
            {
                Id = pessoaDTO.Id,
                Nome = pessoaDTO.Nome,
                Cpf = pessoaDTO.Cpf,
                Telefone = pessoaDTO.Telefone,
                Endereco = pessoaDTO.Endereco
            });
            _context.SaveChanges();
            return true;
        }

        public Pessoa Consulte(int p)
        {
            var pessoa = _context.Pessoa.ToList().Where(x => x.Id == p).FirstOrDefault();
            var telefone = _context.Telefone.ToList().FirstOrDefault(x => x.Id == p);
            var endereco = _context.Endereco.ToList().FirstOrDefault(x => x.Id == p);
            if (pessoa == null)
            {
                return new Pessoa
                {
                    Nome = "Não encontrado",
                    Id = 0,
                };
            } else
            {
                return new Pessoa { Id = pessoa.Id,
                                    Nome = pessoa.Nome,
                                    Cpf = pessoa.Cpf,
                                    Telefone = telefone,
                                    Endereco = endereco
                };
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
                case "pessoaTelefone":
                    maxId = _context.PessoaTelefone.ToList().Select(x => x.Id).Max() + 1;
                    break;
                default: return maxId;
            }
            return maxId;
        }
    }
}
