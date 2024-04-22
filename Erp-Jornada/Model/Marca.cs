namespace Erp_Jornada.Model
{
    public class Marca : Entidade
    {
        public Marca(string? nome, string? email, string? cnpj, string? senha)
        {
            Nome = nome;
            Senha = senha;
            Email = email;
            Cnpj = cnpj;
            Ativo = true;
        }

        public string? Nome { get; set; }
        public string? Cnpj { get; set; }
        public string? Senha { get; set; }
        public string? Email { get; set; }
    }
}
