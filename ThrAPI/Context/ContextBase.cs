using Microsoft.EntityFrameworkCore;
using ThrAPI.Models.Estoque;
using ThrAPI.Models.Login;

namespace ThrAPI.Context
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLazyLoadingProxies();
        //Login
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<ClaimsModel> Claims { get; set; }
        public DbSet<ClaimsTypeModel> ClaimsType { get; set; }
        
        //Estoque
        public DbSet<EstoqueModel> Estoque { get; set; }
        public DbSet<MovimentaoEstoqueModel> Movimentacao { get; set; }
        public DbSet<LocaisEstocagemModel> LocaisEstocagem { get; set; }
        public DbSet<MovimentacaoIdentificaoModel> MovimentacaoIdentificao { get; set; }
        public DbSet<IdentificaoMaterialModel> IdentificaoMaterial { get; set; }
    }
}
