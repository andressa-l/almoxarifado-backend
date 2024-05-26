using AlmoxarifadoDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace AlmoxarifadoInfrastructure.Data {
    public partial class xAlmoxarifadoContext : DbContext
    {
        public xAlmoxarifadoContext()
        {
        }

        public xAlmoxarifadoContext(DbContextOptions<xAlmoxarifadoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ano> Anos { get; set; } = null!;
        public virtual DbSet<Classe> Classes { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Demonstrativo> Demonstrativos { get; set; } = null!;
        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<Estoque> Estoques { get; set; } = null!;
        public virtual DbSet<Fornecedor> Fornecedors { get; set; } = null!;
        public virtual DbSet<Grupo> Grupos { get; set; } = null!;
        public virtual DbSet<ItensNota> ItensNota { get; set; } = null!;
        public virtual DbSet<ItensReq> ItensReqs { get; set; } = null!;
        public virtual DbSet<MesCompetencium> MesCompetencia { get; set; } = null!;
        public virtual DbSet<Movimentacao> Movimentacaos { get; set; } = null!;
        public virtual DbSet<NotaFiscal> NotaFiscals { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;
        public virtual DbSet<Requisicao> Requisicaos { get; set; } = null!;
        public virtual DbSet<Secretarium> Secretaria { get; set; } = null!;
        public virtual DbSet<Setor> Setors { get; set; } = null!;
        public virtual DbSet<Sistema> Sistemas { get; set; } = null!;
        public virtual DbSet<Subgrupo> Subgrupos { get; set; } = null!;
        public virtual DbSet<TipoNotum> TipoNota { get; set; } = null!;
        public virtual DbSet<UnidadeMedidum> UnidadeMedida { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<XVersao> XVersaos { get; set; } = null!;

     


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ano>(entity =>
            {
                entity.HasKey(e => e.Ano1);

                entity.ToTable("ANO");

                entity.Property(e => e.Ano1)
                    .ValueGeneratedNever()
                    .HasColumnName("ANO");

                entity.Property(e => e.Aberto)
                    .HasColumnName("ABERTO")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(e => e.IdClas)
                    .HasName("PK__CLASSE__108B795B");

                entity.ToTable("CLASSE");

                entity.HasIndex(e => e.IdSubGru, "IDX_CLASSE1");

                entity.HasIndex(e => e.IdClas, "IDX_CLASSE2")
                    .IsUnique();

                entity.Property(e => e.IdClas).HasColumnName("ID_CLAS");

                entity.Property(e => e.IdSubGru).HasColumnName("ID_SUB_GRU");

                entity.Property(e => e.NomeCla)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("NOME_CLA");

                entity.HasOne(d => d.IdSubGruNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdSubGru)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CLASSE__ID_SUB_G__1BFD2C07");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCli)
                    .HasName("PK__CLIENTE__2BF8836D2466B393");

                entity.ToTable("CLIENTE");

                entity.HasIndex(e => e.IdSec, "IDX_CLIENTE1");

                entity.HasIndex(e => e.IdCli, "IDX_CLIENTE2")
                    .IsUnique();

                entity.Property(e => e.IdCli).HasColumnName("ID_CLI");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CARGO");

                entity.Property(e => e.IdSec).HasColumnName("ID_SEC");

                entity.Property(e => e.NomeCli)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME_CLI");

                entity.Property(e => e.Portaria).HasColumnName("PORTARIA");

                entity.HasOne(d => d.IdSecNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdSec)
                    .HasConstraintName("FK__CLIENTE__ID_SEC__1367E606");
            });

            modelBuilder.Entity<Demonstrativo>(entity =>
            {
                entity.HasKey(e => new { e.IdSec, e.IdPro });

                entity.ToTable("DEMONSTRATIVO");

                entity.Property(e => e.IdSec).HasColumnName("ID_SEC");

                entity.Property(e => e.IdPro).HasColumnName("ID_PRO");

                entity.Property(e => e.DescricaoPro)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DESCRICAO_PRO");

                entity.Property(e => e.EntradaQtd)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("ENTRADA_QTD");

                entity.Property(e => e.EntradaVlUnit)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("ENTRADA_VL_UNIT");

                entity.Property(e => e.IdCla).HasColumnName("ID_CLA");

                entity.Property(e => e.IdGru).HasColumnName("ID_GRU");

                entity.Property(e => e.IdSubGru).HasColumnName("ID_SUB_GRU");

                entity.Property(e => e.NomeCla)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NOME_CLA");

                entity.Property(e => e.NomeGru)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NOME_GRU");

                entity.Property(e => e.NomeSec)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NOME_SEC");

                entity.Property(e => e.NomeSubGru)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NOME_SUB_GRU");

                entity.Property(e => e.SaidaCm)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("SAIDA_CM");

                entity.Property(e => e.SaidaQtd)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("SAIDA_QTD");

                entity.Property(e => e.SaldoAntCusto)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("SALDO_ANT_CUSTO");

                entity.Property(e => e.SaldoAnterior)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("SALDO_ANTERIOR");

                entity.Property(e => e.SaldoCm)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("SALDO_CM");

                entity.Property(e => e.SaldoQtd)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("SALDO_QTD");

                entity.Property(e => e.UniMed)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("UNI_MED");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EMPRESA");

                entity.Property(e => e.BairroEmpresa)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BAIRRO_EMPRESA");

                entity.Property(e => e.CepEmpresa)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CEP_EMPRESA");

                entity.Property(e => e.CidadeEmpresa)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CIDADE_EMPRESA");

                entity.Property(e => e.CnpjEmpresa)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ_EMPRESA");

                entity.Property(e => e.EnderecoEmpresa)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("ENDERECO_EMPRESA");

                entity.Property(e => e.FoneEmresa)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FONE_EMRESA");

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");

                entity.Property(e => e.LogoEmpresa)
                    .HasColumnType("image")
                    .HasColumnName("LOGO_EMPRESA");

                entity.Property(e => e.NomeEmpresa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME_EMPRESA");

                entity.Property(e => e.UfEmpresa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UF_EMPRESA");
            });

            modelBuilder.Entity<Estoque>(entity =>
            {
                entity.HasKey(e => new { e.IdSec, e.IdPro });

                entity.ToTable("ESTOQUE");

                entity.Property(e => e.IdSec).HasColumnName("ID_SEC");

                entity.Property(e => e.IdPro).HasColumnName("ID_PRO");

                entity.Property(e => e.QtdPro)
                    .HasColumnType("numeric(10, 4)")
                    .HasColumnName("QTD_PRO");
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.HasKey(e => e.Cnpj)
                    .HasName("PK__FORNECEDOR__76CBA758");

                entity.ToTable("FORNECEDOR");

                entity.HasIndex(e => e.IdFor, "IDX_FORNECEDOR1")
                    .IsUnique();

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("BAIRRO");

                entity.Property(e => e.Celular)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CELULAR");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ENDERECO");

                entity.Property(e => e.Fantasia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FANTASIA");

                entity.Property(e => e.Fax)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.IdFor)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_FOR");

                entity.Property(e => e.InsEstadual)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("INS_ESTADUAL");

                entity.Property(e => e.InsMunicipal)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("INS_MUNICIPAL");

                entity.Property(e => e.Responsavel)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("RESPONSAVEL");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONE");

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("UF");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.IdGru)
                    .HasName("PK__GRUPO__07F6335A");

                entity.ToTable("GRUPO");

                entity.HasIndex(e => e.IdGru, "IDX_GRUPO1")
                    .IsUnique();

                entity.Property(e => e.IdGru).HasColumnName("ID_GRU");

                entity.Property(e => e.NomeGru)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("NOME_GRU");

                entity.Property(e => e.SugestaoGru)
                    .HasColumnType("text")
                    .HasColumnName("SUGESTAO_GRU");
            });

            modelBuilder.Entity<ItensNota>(entity =>
            {
                entity.HasKey(e => new { e.ItemNum, e.IdPro, e.IdNota, e.IdSec })
                    .HasName("PK__ITENS_NOTA__08EA5793");

                entity.ToTable("ITENS_NOTA");

                entity.HasIndex(e => e.IdNota, "IDX_ITENS_NOTA1");

                entity.HasIndex(e => e.IdPro, "IDX_ITENS_NOTA2");

                entity.Property(e => e.ItemNum).HasColumnName("ITEM_NUM");

                entity.Property(e => e.IdPro).HasColumnName("ID_PRO");

                entity.Property(e => e.IdNota).HasColumnName("ID_NOTA");

                entity.Property(e => e.IdSec).HasColumnName("ID_SEC");

                entity.Property(e => e.EstLin)
                    .HasColumnType("numeric(12, 4)")
                    .HasColumnName("EST_LIN");

                entity.Property(e => e.PreUnit)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("PRE_UNIT");

                entity.Property(e => e.QtdPro)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("QTD_PRO");

                entity.Property(e => e.TotalItem)
                    .HasColumnType("numeric(37, 8)")
                    .HasColumnName("TOTAL_ITEM")
                    .HasComputedColumnSql("([QTD_PRO]*[PRE_UNIT])", false);

                entity.HasOne(d => d.IdNotaNavigation)
                    .WithMany(p => p.ItensNota)
                    .HasPrincipalKey(p => p.IdNota)
                    .HasForeignKey(d => d.IdNota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ITENS_NOT__ID_NO__1B0907CE");

                entity.HasOne(d => d.IdProNavigation)
                    .WithMany(p => p.ItensNota)
                    .HasForeignKey(d => d.IdPro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ITENS_NOT__ID_PR__1BFD2C07");
            });

            modelBuilder.Entity<ItensReq>(entity =>
            {
                entity.HasKey(e => new { e.NumItem, e.IdPro, e.IdReq, e.IdSec });

                entity.ToTable("ITENS_REQ");

                entity.HasIndex(e => e.IdReq, "IDX_ITENS_REQ1");

                entity.HasIndex(e => e.IdPro, "IDX_ITENS_REQ2");

                entity.Property(e => e.NumItem).HasColumnName("NUM_ITEM");

                entity.Property(e => e.IdPro).HasColumnName("ID_PRO");

                entity.Property(e => e.IdReq).HasColumnName("ID_REQ");

                entity.Property(e => e.IdSec).HasColumnName("ID_SEC");

                entity.Property(e => e.PreUnit)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("PRE_UNIT");

                entity.Property(e => e.QtdPro)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("QTD_PRO");

                entity.Property(e => e.TotalItem)
                    .HasColumnType("numeric(37, 8)")
                    .HasColumnName("TOTAL_ITEM")
                    .HasComputedColumnSql("([qtd_pro]*[pre_unit])", false);

                entity.Property(e => e.TotalReal)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("TOTAL_REAL");

                entity.HasOne(d => d.IdProNavigation)
                    .WithMany(p => p.ItensReqs)
                    .HasForeignKey(d => d.IdPro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ITENS_REQ__ID_PR__1ED998B2");

                entity.HasOne(d => d.IdReqNavigation)
                    .WithMany(p => p.ItensReqs)
                    .HasForeignKey(d => d.IdReq)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ITENS_REQ__ID_RE__1DE57479");
            });

            modelBuilder.Entity<MesCompetencium>(entity =>
            {
                entity.HasKey(e => new { e.Mes, e.Ano })
                    .HasName("PK_MES");

                entity.ToTable("MES_COMPETENCIA");

                entity.Property(e => e.Mes).HasColumnName("MES");

                entity.Property(e => e.Ano).HasColumnName("ANO");

                entity.Property(e => e.Aberto)
                    .HasColumnName("ABERTO")
                    .HasDefaultValueSql("((-1))");

                entity.HasOne(d => d.AnoNavigation)
                    .WithMany(p => p.MesCompetencia)
                    .HasForeignKey(d => d.Ano)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANO_MES");
            });

            modelBuilder.Entity<Movimentacao>(entity =>
            {
                entity.HasKey(e => e.IdMovi)
                    .HasName("PK__MOVIMENTACAO__08EA5793");

                entity.ToTable("MOVIMENTACAO");

                entity.Property(e => e.IdMovi).HasColumnName("ID_MOVI");

                entity.Property(e => e.AnoMov).HasColumnName("ANO_MOV");

                entity.Property(e => e.DataMov)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_MOV");

                entity.Property(e => e.EstAnt)
                    .HasColumnType("numeric(10, 4)")
                    .HasColumnName("EST_ANT");

                entity.Property(e => e.IdNota).HasColumnName("ID_NOTA");

                entity.Property(e => e.IdPro).HasColumnName("ID_PRO");

                entity.Property(e => e.IdReq).HasColumnName("ID_REQ");

                entity.Property(e => e.IdSec).HasColumnName("ID_SEC");

                entity.Property(e => e.IdSet).HasColumnName("ID_SET");

                entity.Property(e => e.MesMov).HasColumnName("MES_MOV");

                entity.Property(e => e.PreUnit)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("PRE_UNIT");

                entity.Property(e => e.QtdPro)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("QTD_PRO");

                entity.Property(e => e.Saldo)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("SALDO");

                entity.Property(e => e.TipoMov).HasColumnName("TIPO_MOV");
            });

            modelBuilder.Entity<NotaFiscal>(entity =>
            {
                entity.HasKey(e => new { e.IdNota, e.IdTipoNota })
                    .HasName("PK__NOTA_FISCAL__7E6CC920");

                entity.ToTable("NOTA_FISCAL");

                entity.HasIndex(e => e.IdSec, "IDX_NOTA_FISCAL1");

                entity.HasIndex(e => e.IdNota, "IDX_NOTA_FISCAL2")
                    .IsUnique();

                entity.HasIndex(e => e.IdFor, "IDX_NOTA_FISCAL3");

                entity.HasIndex(e => e.IdTipoNota, "IDX_NOTA_FISCAL4");

                entity.Property(e => e.IdNota)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_NOTA");

                entity.Property(e => e.IdTipoNota).HasColumnName("ID_TIPO_NOTA");

                entity.Property(e => e.Ano).HasColumnName("ANO");

                entity.Property(e => e.DataNota)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DATA_NOTA");

                entity.Property(e => e.EmpenhoNum).HasColumnName("EMPENHO_NUM");

                entity.Property(e => e.Icms).HasColumnName("ICMS");

                entity.Property(e => e.IdFor).HasColumnName("ID_FOR");

                entity.Property(e => e.IdSec).HasColumnName("ID_SEC");

                entity.Property(e => e.Iss).HasColumnName("ISS");

                entity.Property(e => e.Mes).HasColumnName("MES");

                entity.Property(e => e.NumNota)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("NUM_NOTA");

                entity.Property(e => e.ObservacaoNota)
                    .HasColumnType("text")
                    .HasColumnName("OBSERVACAO_NOTA");

                entity.Property(e => e.QtdItem).HasColumnName("QTD_ITEM");

                entity.Property(e => e.ValorNota)
                    .HasColumnType("money")
                    .HasColumnName("VALOR_NOTA");

                entity.HasOne(d => d.IdForNavigation)
                    .WithMany(p => p.NotaFiscals)
                    .HasPrincipalKey(p => p.IdFor)
                    .HasForeignKey(d => d.IdFor)
                    .HasConstraintName("FORNECEDOR_NOTA_FISCAL");

                entity.HasOne(d => d.IdSecNavigation)
                    .WithMany(p => p.NotaFiscals)
                    .HasForeignKey(d => d.IdSec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NOTA_FISC__ID_SE__145C0A3F");

                entity.HasOne(d => d.IdTipoNotaNavigation)
                    .WithMany(p => p.NotaFiscals)
                    .HasForeignKey(d => d.IdTipoNota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NOTA_FISC__ID_TI__164452B1");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdPro)
                    .HasName("PK__PRODUTO__060DEAE8");

                entity.ToTable("PRODUTO");

                entity.HasIndex(e => e.IdClas, "IDX_PRODUTO1");

                entity.HasIndex(e => e.IdPro, "IDX_PRODUTO2")
                    .IsUnique();

                entity.HasIndex(e => e.IdUnMed, "IDX_PRODUTO3");

                entity.Property(e => e.IdPro).HasColumnName("ID_PRO");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DESCRICAO");

                entity.Property(e => e.EstoqueMin)
                    .HasColumnName("ESTOQUE_MIN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IdClas).HasColumnName("ID_CLAS");

                entity.Property(e => e.IdUnMed).HasColumnName("ID_UN_MED");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OBSERVACAO");

                entity.Property(e => e.Perecivel).HasColumnName("PERECIVEL");

                entity.Property(e => e.QtdEmbalagem).HasColumnName("QTD_EMBALAGEM");

                entity.HasOne(d => d.IdClasNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdClas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRODUTO__ID_CLAS__1920BF5C");

                entity.HasOne(d => d.IdUnMedNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdUnMed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRODUTO__ID_UN_M__1A14E395");
            });

            modelBuilder.Entity<Requisicao>(entity =>
            {
                entity.HasKey(e => e.IdReq)
                    .HasName("PK__REQUISICAO__0AD2A005");

                entity.ToTable("REQUISICAO");

                entity.HasIndex(e => e.IdCli, "IDX_REQUISICAO1");

                entity.HasIndex(e => e.IdReq, "IDX_REQUISICAO2")
                    .IsUnique();

                entity.Property(e => e.IdReq).HasColumnName("ID_REQ");

                entity.Property(e => e.Ano).HasColumnName("ANO");

                entity.Property(e => e.DataReq)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_REQ");

                entity.Property(e => e.IdCli).HasColumnName("ID_CLI");

                entity.Property(e => e.IdSec).HasColumnName("ID_SEC");

                entity.Property(e => e.IdSet).HasColumnName("ID_SET");

                entity.Property(e => e.Mes).HasColumnName("MES");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("OBSERVACAO");

                entity.Property(e => e.QtdIten).HasColumnName("QTD_ITEN");

                entity.Property(e => e.TotalReq)
                    .HasColumnType("money")
                    .HasColumnName("TOTAL_REQ");

                entity.HasOne(d => d.IdCliNavigation)
                    .WithMany(p => p.Requisicaos)
                    .HasForeignKey(d => d.IdCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REQUISICA__ID_CL__1CF15040");

                entity.HasOne(d => d.IdSetNavigation)
                    .WithMany(p => p.Requisicaos)
                    .HasForeignKey(d => d.IdSet)
                    .HasConstraintName("FK_REQUISICAO_SETOR");
            });

            modelBuilder.Entity<Secretarium>(entity =>
            {
                entity.HasKey(e => e.IdSec)
                    .HasName("PK__SECRETARIA__78B3EFCA");

                entity.ToTable("SECRETARIA");

                entity.HasIndex(e => e.IdSec, "IDX_SECRETARIA1")
                    .IsUnique();

                entity.Property(e => e.IdSec).HasColumnName("ID_SEC");

                entity.Property(e => e.BairroSec)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BAIRRO_SEC");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.EndrecoSec)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ENDRECO_SEC");

                entity.Property(e => e.NomeSec)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME_SEC");

                entity.Property(e => e.Tel)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("TEL");
            });

            modelBuilder.Entity<Setor>(entity =>
            {
                entity.HasKey(e => e.IdSet);

                entity.ToTable("SETOR");

                entity.Property(e => e.IdSet).HasColumnName("ID_SET");

                entity.Property(e => e.IdSec).HasColumnName("ID_SEC");

                entity.Property(e => e.NomeSet)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NOME_SET");

                entity.HasOne(d => d.IdSecNavigation)
                    .WithMany(p => p.Setors)
                    .HasForeignKey(d => d.IdSec)
                    .HasConstraintName("FK_SETOR_SECRETARIA");
            });

            modelBuilder.Entity<Sistema>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SISTEMAS");

                entity.Property(e => e.Da)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("DA");

                entity.Property(e => e.Du)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("DU");

                entity.Property(e => e.Sischave)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SISCHAVE");

                entity.Property(e => e.Sisdescricao)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SISDESCRICAO");

                entity.Property(e => e.Sisid)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SISID");
            });

            modelBuilder.Entity<Subgrupo>(entity =>
            {
                entity.HasKey(e => e.IdSubGru)
                    .HasName("PK__SUBGRUPO__0F975522");

                entity.ToTable("SUBGRUPO");

                entity.HasIndex(e => e.IdSubGru, "IDX_SUBGRUPO1")
                    .IsUnique();

                entity.HasIndex(e => e.IdGru, "IDX_SUBGRUPO2");

                entity.Property(e => e.IdSubGru).HasColumnName("ID_SUB_GRU");

                entity.Property(e => e.IdGru).HasColumnName("ID_GRU");

                entity.Property(e => e.NomeSubGru)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("NOME_SUB_GRU");

                entity.HasOne(d => d.IdGruNavigation)
                    .WithMany(p => p.Subgrupos)
                    .HasForeignKey(d => d.IdGru)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SUBGRUPO__ID_GRU__1B0907CE");
            });

            modelBuilder.Entity<TipoNotum>(entity =>
            {
                entity.HasKey(e => e.IdTipoNota)
                    .HasName("PK__TIPO_NOT__D38C3A0C0A030BA8");

                entity.ToTable("TIPO_NOTA");

                entity.HasIndex(e => e.IdTipoNota, "IDX_TIPO_NOTA1")
                    .IsUnique();

                entity.Property(e => e.IdTipoNota).HasColumnName("ID_TIPO_NOTA");

                entity.Property(e => e.DescricaoTipoNota)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DESCRICAO_TIPO_NOTA");
            });

            modelBuilder.Entity<UnidadeMedidum>(entity =>
            {
                entity.HasKey(e => e.IdUnMed)
                    .HasName("PK__UNIDADE___1185B3A2DAC42E80");

                entity.ToTable("UNIDADE_MEDIDA");

                entity.HasIndex(e => e.IdUnMed, "IDX_UNIDADE_MEDIDA1")
                    .IsUnique();

                entity.Property(e => e.IdUnMed).HasColumnName("ID_UN_MED");

                entity.Property(e => e.NomeUnMed)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NOME_UN_MED");

                entity.Property(e => e.Sigla)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SIGLA");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("USUARIO");

                entity.Property(e => e.IdUsu)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_USU");

                entity.Property(e => e.LogonUsu)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("LOGON_USU");

                entity.Property(e => e.NomeUsu)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("NOME_USU");

                entity.Property(e => e.SenhaUsu)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("SENHA_USU");

                entity.Property(e => e.TipoUsu)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_USU")
                    .IsFixedLength();
            });

            modelBuilder.Entity<XVersao>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("xVersao");

                entity.Property(e => e.IdVer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("ID_VER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
