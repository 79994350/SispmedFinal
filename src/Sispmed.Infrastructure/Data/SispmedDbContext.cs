using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sispmed.Core.Domain;

namespace Sispmed.Infrastructure.Data
{
    public partial class SispmedDbContext : DbContext
    {
        public SispmedDbContext()
        {
        }

        public SispmedDbContext(DbContextOptions<SispmedDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acompanantes> Acompanantes { get; set; }
        public virtual DbSet<Arl> Arl { get; set; }
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<CategoriasInsumos> CategoriasInsumos { get; set; }
        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<Convenios> Convenios { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Eps> Eps { get; set; }
        public virtual DbSet<FailedJobs> FailedJobs { get; set; }
        public virtual DbSet<Gastos> Gastos { get; set; }
        public virtual DbSet<Insumos> Insumos { get; set; }
        public virtual DbSet<Migrations> Migrations { get; set; }
        public virtual DbSet<MovInsumos> MovInsumos { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }
        public virtual DbSet<PasswordResets> PasswordResets { get; set; }
        public virtual DbSet<Procedimientos> Procedimientos { get; set; }
        public virtual DbSet<Recaudos> Recaudos { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sedes> Sedes { get; set; }
        public virtual DbSet<StockInsumos> StockInsumos { get; set; }
        public virtual DbSet<Tiposid> Tiposid { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("database=sispmednew;server=localhost;port=3306;user id=root;password=");
            }
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acompanantes>(entity =>
            {
                entity.ToTable("acompanantes");

                entity.HasComment("Tabla para almacenar los acompañantes de los pacientes");

                entity.HasIndex(e => e.NIdAcom)
                    .HasName("Número Identificación Acompañante")
                    .IsUnique();

                entity.HasIndex(e => e.PacienteId)
                    .HasName("acompanante_paciente");

                entity.HasIndex(e => e.TipoIdId)
                    .HasName("acompanante_tipoId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Edad)
                    .HasColumnName("edad")
                    .HasColumnType("int(2)");

                entity.Property(e => e.MailAcom)
                    .IsRequired()
                    .HasColumnName("mailAcom")
                    .HasMaxLength(45);

                entity.Property(e => e.NIdAcom)
                    .IsRequired()
                    .HasColumnName("nIdAcom")
                    .HasMaxLength(15);

                entity.Property(e => e.PApe)
                    .IsRequired()
                    .HasColumnName("pApe")
                    .HasMaxLength(15);

                entity.Property(e => e.PNom)
                    .IsRequired()
                    .HasColumnName("pNom")
                    .HasMaxLength(15);

                entity.Property(e => e.PacienteId)
                    .HasColumnName("paciente_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ParPac)
                    .IsRequired()
                    .HasColumnName("parPac")
                    .HasMaxLength(15);

                entity.Property(e => e.SApe)
                    .IsRequired()
                    .HasColumnName("sApe")
                    .HasMaxLength(15);

                entity.Property(e => e.SNom)
                    .IsRequired()
                    .HasColumnName("sNom")
                    .HasMaxLength(15);

                entity.Property(e => e.TelAcom)
                    .IsRequired()
                    .HasColumnName("telAcom")
                    .HasMaxLength(15);

                entity.Property(e => e.TipoIdId)
                    .HasColumnName("tipoId_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.Acompanantes)
                    .HasForeignKey(d => d.PacienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("acompanante_paciente");

                entity.HasOne(d => d.TipoId)
                    .WithMany(p => p.Acompanantes)
                    .HasForeignKey(d => d.TipoIdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("acompanante_tipoId");
            });

            modelBuilder.Entity<Arl>(entity =>
            {
                entity.ToTable("arl");

                entity.HasIndex(e => e.NomArl)
                    .HasName("nomArl")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomArl)
                    .IsRequired()
                    .HasColumnName("nomArl")
                    .HasMaxLength(30);

                entity.Property(e => e.TelArl)
                    .IsRequired()
                    .HasColumnName("telArl")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Cargos>(entity =>
            {
                entity.ToTable("cargos");

                entity.HasComment("Tabla que almacena los cargos");

                entity.HasIndex(e => e.NomCar)
                    .HasName("Nombre del cargo")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomCar)
                    .IsRequired()
                    .HasColumnName("nomCar")
                    .HasMaxLength(30)
                    .HasComment("Nombre del cargo");

                entity.Property(e => e.SalCar)
                    .HasColumnName("salCar")
                    .HasComment("Salario del cargo");
            });

            modelBuilder.Entity<CategoriasInsumos>(entity =>
            {
                entity.ToTable("categorias_insumos");

                entity.HasIndex(e => e.NomCate)
                    .HasName("Nombre de la categoría")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomCate)
                    .IsRequired()
                    .HasColumnName("nomCate")
                    .HasMaxLength(30)
                    .HasComment("Nombre de la categoría");

                entity.Property(e => e.TipoCate)
                    .HasColumnName("tipoCate")
                    .HasColumnType("int(1)")
                    .HasComment("Tipo de categoría, 0 para medicamentos, 1 para insumos");
            });

            modelBuilder.Entity<Citas>(entity =>
            {
                entity.ToTable("citas");

                entity.HasIndex(e => e.AcompananteId)
                    .HasName("cita_acompanante");

                entity.HasIndex(e => e.EmpleadoId)
                    .HasName("cita_empleado");

                entity.HasIndex(e => e.PacienteId)
                    .HasName("cita_paciente");

                entity.HasIndex(e => e.SedeId)
                    .HasName("cita_sede");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AcompananteId)
                    .HasColumnName("acompanante_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpleadoId)
                    .HasColumnName("empleado_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.PacienteId)
                    .HasColumnName("paciente_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SedeId)
                    .HasColumnName("sede_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Acompanante)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(d => d.AcompananteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cita_acompanante");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cita_empleado");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(d => d.PacienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cita_paciente");

                entity.HasOne(d => d.Sede)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(d => d.SedeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cita_sede");
            });

            modelBuilder.Entity<Convenios>(entity =>
            {
                entity.ToTable("convenios");

                entity.HasComment("Tabla que almacena los convenios que se tienen con las EPS");

                entity.HasIndex(e => e.EpsId)
                    .HasName("convenio_eps");

                entity.HasIndex(e => e.NomConv)
                    .HasName("Nombre del convenio")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CosConv).HasColumnName("cosConv");

                entity.Property(e => e.DurConv).HasColumnName("durConv");

                entity.Property(e => e.EpsId)
                    .HasColumnName("eps_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FecAper)
                    .HasColumnName("fecAper")
                    .HasColumnType("date");

                entity.Property(e => e.NomConv)
                    .IsRequired()
                    .HasColumnName("nomConv")
                    .HasMaxLength(100);

                entity.Property(e => e.ObjConv)
                    .IsRequired()
                    .HasColumnName("objConv")
                    .HasMaxLength(120);

                entity.Property(e => e.Resolu)
                    .IsRequired()
                    .HasColumnName("resolu")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Eps)
                    .WithMany(p => p.Convenios)
                    .HasForeignKey(d => d.EpsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("convenio_eps");
            });

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.ToTable("empleados");

                entity.HasComment("Tabla que almacena los datos de los empleados");

                entity.HasIndex(e => e.ArlId)
                    .HasName("empleado_arl");

                entity.HasIndex(e => e.CargoId)
                    .HasName("empleado_cargo");

                entity.HasIndex(e => e.EpsId)
                    .HasName("empleado_eps");

                entity.HasIndex(e => e.NIdEmp)
                    .HasName("nIdEmp")
                    .IsUnique();

                entity.HasIndex(e => e.TiposIdId)
                    .HasName("empleado_tipoId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArlId)
                    .HasColumnName("arl_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CargoId)
                    .HasColumnName("cargo_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CiuRes)
                    .HasColumnName("ciuRes")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'''N/A'''");

                entity.Property(e => e.DirRes)
                    .HasColumnName("dirRes")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'''N/A'''");

                entity.Property(e => e.ECivil)
                    .HasColumnName("eCivil")
                    .HasColumnType("enum('C','S','U','V')")
                    .HasDefaultValueSql("'''S'''");

                entity.Property(e => e.EpsId)
                    .HasColumnName("eps_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FecIng)
                    .HasColumnName("fecIng")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FecNac)
                    .HasColumnName("fecNac")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Genero)
                    .HasColumnName("genero")
                    .HasColumnType("enum('M','F','I')")
                    .HasDefaultValueSql("'''I'''");

                entity.Property(e => e.MailEmp)
                    .HasColumnName("mailEmp")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'''N/A'''");

                entity.Property(e => e.NIdEmp)
                    .HasColumnName("nIdEmp")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'''N/A'''");

                entity.Property(e => e.PApe)
                    .HasColumnName("pApe")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'''N/A'''");

                entity.Property(e => e.PNom)
                    .HasColumnName("pNom")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'''N/A'''");

                entity.Property(e => e.Rh)
                    .HasColumnName("rh")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("'''N/A'''");

                entity.Property(e => e.SApe)
                    .HasColumnName("sApe")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'''N/A'''");

                entity.Property(e => e.SNom)
                    .HasColumnName("sNom")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'''N/A'''");

                entity.Property(e => e.TelEmp)
                    .HasColumnName("telEmp")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'''N/A'''");

                entity.Property(e => e.TiposIdId)
                    .HasColumnName("tiposId_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Arl)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.ArlId)
                    .HasConstraintName("empleado_arl");

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.CargoId)
                    .HasConstraintName("empleado_cargo");

                entity.HasOne(d => d.Eps)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.EpsId)
                    .HasConstraintName("empleado_eps");

                entity.HasOne(d => d.TiposId)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.TiposIdId)
                    .HasConstraintName("empleado_tipoId");
            });

            modelBuilder.Entity<Eps>(entity =>
            {
                entity.ToTable("eps");

                entity.HasIndex(e => e.NomEps)
                    .HasName("nomEps")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomEps)
                    .IsRequired()
                    .HasColumnName("nomEps")
                    .HasMaxLength(30);

                entity.Property(e => e.TelEps)
                    .IsRequired()
                    .HasColumnName("telEps")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<FailedJobs>(entity =>
            {
                entity.ToTable("failed_jobs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Connection)
                    .IsRequired()
                    .HasColumnName("connection");

                entity.Property(e => e.Exception)
                    .IsRequired()
                    .HasColumnName("exception")
                    .HasColumnType("longtext");

                entity.Property(e => e.Payload)
                    .IsRequired()
                    .HasColumnName("payload")
                    .HasColumnType("longtext");

                entity.Property(e => e.Queue)
                    .IsRequired()
                    .HasColumnName("queue");
            });

            modelBuilder.Entity<Gastos>(entity =>
            {
                entity.ToTable("gastos");

                entity.HasComment("Tabla que almacena los gastos");

                entity.HasIndex(e => e.EmpleadoId)
                    .HasName("gasto_empleado");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Concepto)
                    .IsRequired()
                    .HasColumnName("concepto")
                    .HasMaxLength(45);

                entity.Property(e => e.EmpleadoId)
                    .HasColumnName("empleado_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FecGasto)
                    .HasColumnName("fecGasto")
                    .HasColumnType("date");

                entity.Property(e => e.ForPago)
                    .IsRequired()
                    .HasColumnName("forPago")
                    .HasColumnType("enum('EF','TD','TC','CH')");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Gastos)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gasto_empleado");
            });

            modelBuilder.Entity<Insumos>(entity =>
            {
                entity.ToTable("insumos");

                entity.HasIndex(e => e.CategoriaId)
                    .HasName("insumo_categoria");

                entity.HasIndex(e => e.CodIns)
                    .HasName("codIns")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoriaId)
                    .HasColumnName("categoria_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodIns)
                    .IsRequired()
                    .HasColumnName("codIns")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Concen)
                    .IsRequired()
                    .HasColumnName("concen")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Labora)
                    .IsRequired()
                    .HasColumnName("labora")
                    .HasMaxLength(20);

                entity.Property(e => e.NomIns)
                    .IsRequired()
                    .HasColumnName("nomIns")
                    .HasMaxLength(20);

                entity.Property(e => e.PrecioU)
                    .HasColumnName("precioU")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.Pres)
                    .IsRequired()
                    .HasColumnName("pres")
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Unid)
                    .IsRequired()
                    .HasColumnName("unid")
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Insumos)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("insumo_categoria");
            });

            modelBuilder.Entity<Migrations>(entity =>
            {
                entity.ToTable("migrations");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Migration)
                    .IsRequired()
                    .HasColumnName("migration")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<MovInsumos>(entity =>
            {
                entity.ToTable("mov_insumos");

                entity.HasIndex(e => e.InsumoId)
                    .HasName("movimiento_insumo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("int(3)");

                entity.Property(e => e.Concepto)
                    .IsRequired()
                    .HasColumnName("concepto")
                    .HasMaxLength(50);

                entity.Property(e => e.InsumoId)
                    .HasColumnName("insumo_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasColumnType("enum('0','1')");

                entity.HasOne(d => d.Insumo)
                    .WithMany(p => p.MovInsumos)
                    .HasForeignKey(d => d.InsumoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("movimiento_insumo");
            });

            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.ToTable("pacientes");

                entity.HasIndex(e => e.EpsId)
                    .HasName("paciente_eps");

                entity.HasIndex(e => e.NIdPac)
                    .HasName("nIdPac")
                    .IsUnique();

                entity.HasIndex(e => e.TipoIdId)
                    .HasName("paciente_tipoId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CiuRes)
                    .IsRequired()
                    .HasColumnName("ciuRes")
                    .HasMaxLength(20);

                entity.Property(e => e.DirRes)
                    .IsRequired()
                    .HasColumnName("dirRes")
                    .HasMaxLength(45);

                entity.Property(e => e.ECivil)
                    .IsRequired()
                    .HasColumnName("eCivil")
                    .HasColumnType("enum('C','S','U','V')");

                entity.Property(e => e.EpsId)
                    .HasColumnName("eps_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FecNac)
                    .HasColumnName("fecNac")
                    .HasColumnType("date");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasColumnName("genero")
                    .HasColumnType("enum('F','I','M')");

                entity.Property(e => e.MailPac)
                    .IsRequired()
                    .HasColumnName("mailPac")
                    .HasMaxLength(40);

                entity.Property(e => e.NIdPac)
                    .IsRequired()
                    .HasColumnName("nIdPac")
                    .HasMaxLength(15);

                entity.Property(e => e.PApe)
                    .IsRequired()
                    .HasColumnName("pApe")
                    .HasMaxLength(20);

                entity.Property(e => e.PNom)
                    .IsRequired()
                    .HasColumnName("pNom")
                    .HasMaxLength(20);

                entity.Property(e => e.Regimen)
                    .IsRequired()
                    .HasColumnName("regimen")
                    .HasColumnType("enum('C','S')");

                entity.Property(e => e.Rh)
                    .IsRequired()
                    .HasColumnName("rh")
                    .HasMaxLength(3);

                entity.Property(e => e.SApe)
                    .IsRequired()
                    .HasColumnName("sApe")
                    .HasMaxLength(20);

                entity.Property(e => e.SNom)
                    .IsRequired()
                    .HasColumnName("sNom")
                    .HasMaxLength(20);

                entity.Property(e => e.TelPac)
                    .IsRequired()
                    .HasColumnName("telPac")
                    .HasMaxLength(15);

                entity.Property(e => e.TipoIdId)
                    .HasColumnName("tipoId_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Eps)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.EpsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("paciente_eps");

                entity.HasOne(d => d.TipoId)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.TipoIdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("paciente_tipoId");
            });

            modelBuilder.Entity<PasswordResets>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("password_resets");

                entity.HasIndex(e => e.Email)
                    .HasName("password_resets_email_index");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Procedimientos>(entity =>
            {
                entity.ToTable("procedimientos");

                entity.HasIndex(e => e.CodProc)
                    .HasName("codProc")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodProc)
                    .IsRequired()
                    .HasColumnName("codProc")
                    .HasMaxLength(10);

                entity.Property(e => e.NomProc)
                    .IsRequired()
                    .HasColumnName("nomProc")
                    .HasMaxLength(30);

                entity.Property(e => e.PreProc)
                    .IsRequired()
                    .HasColumnName("preProc")
                    .HasMaxLength(50);

                entity.Property(e => e.Valor).HasColumnName("valor");
            });

            modelBuilder.Entity<Recaudos>(entity =>
            {
                entity.ToTable("recaudos");

                entity.HasIndex(e => e.EmpleadoId)
                    .HasName("recaudo_empleado");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Concep)
                    .IsRequired()
                    .HasColumnName("concep")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpleadoId)
                    .HasColumnName("empleado_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ForPago)
                    .IsRequired()
                    .HasColumnName("forPago")
                    .HasColumnType("enum('EF','TD','TC','CH')");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Recaudos)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recaudo_empleado");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomRol)
                    .IsRequired()
                    .HasColumnName("nomRol")
                    .HasColumnType("enum('Administrador','Enfermera','Jefe','Medico','Secretaria')");
            });

            modelBuilder.Entity<Sedes>(entity =>
            {
                entity.ToTable("sedes");

                entity.HasIndex(e => e.NomSede)
                    .HasName("nomSede")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DirSede)
                    .IsRequired()
                    .HasColumnName("dirSede")
                    .HasMaxLength(45);

                entity.Property(e => e.NomSede)
                    .IsRequired()
                    .HasColumnName("nomSede")
                    .HasMaxLength(20);

                entity.Property(e => e.TelSede)
                    .IsRequired()
                    .HasColumnName("telSede")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<StockInsumos>(entity =>
            {
                entity.ToTable("stock_insumos");

                entity.HasIndex(e => e.InsumoId)
                    .HasName("stock_insumo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Disponi)
                    .HasColumnName("disponi")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Entradas)
                    .HasColumnName("entradas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InsumoId)
                    .HasColumnName("insumo_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Salidas)
                    .HasColumnName("salidas")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Insumo)
                    .WithMany(p => p.StockInsumos)
                    .HasForeignKey(d => d.InsumoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("stock_insumo");
            });

            modelBuilder.Entity<Tiposid>(entity =>
            {
                entity.ToTable("tiposid");

                entity.HasIndex(e => e.Tipo)
                    .HasName("tipoId")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomTipo)
                    .IsRequired()
                    .HasColumnName("nomTipo")
                    .HasMaxLength(25);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("users_email_unique")
                    .IsUnique();

                entity.HasIndex(e => e.EmpleadoId)
                    .HasName("users_empleado_id_foreign");

                entity.HasIndex(e => e.RolId)
                    .HasName("users_rol_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.EmpleadoId)
                    .HasColumnName("empleado_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.RememberToken)
                    .HasColumnName("remember_token")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RolId)
                    .HasColumnName("rol_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_empleado_id_foreign");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_rol_id_foreign");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
