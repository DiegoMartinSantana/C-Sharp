using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework;

public partial class UnivContext : DbContext
{
    public UnivContext()
    {
    }

    public UnivContext(DbContextOptions<UnivContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Certificacione> Certificaciones { get; set; }

    public virtual DbSet<Clase> Clases { get; set; }

    public virtual DbSet<Contenido> Contenidos { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<DatosPersonale> DatosPersonales { get; set; }

    public virtual DbSet<FormatosIdioma> FormatosIdiomas { get; set; }

    public virtual DbSet<Idioma> Idiomas { get; set; }

    public virtual DbSet<IdiomasXCurso> IdiomasXCursos { get; set; }

    public virtual DbSet<Inscripcione> Inscripciones { get; set; }

    public virtual DbSet<Localidade> Localidades { get; set; }

    public virtual DbSet<Nivele> Niveles { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<Reseña> Reseñas { get; set; }

    public virtual DbSet<TiposContenido> TiposContenidos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC2783BB7E03");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Certificacione>(entity =>
        {
            entity.HasKey(e => e.Idinscripcion).HasName("PK__Certific__B4FD8345A31F9043");

            entity.Property(e => e.Idinscripcion)
                .ValueGeneratedNever()
                .HasColumnName("IDInscripcion");
            entity.Property(e => e.Costo).HasColumnType("money");
            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdinscripcionNavigation).WithOne(p => p.Certificacione)
                .HasForeignKey<Certificacione>(d => d.Idinscripcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Certifica__IDIns__6E01572D");
        });

        modelBuilder.Entity<Clase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clases__3214EC27200E836F");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idcurso).HasColumnName("IDCurso");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdcursoNavigation).WithMany(p => p.Clases)
                .HasForeignKey(d => d.Idcurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clases__IDCurso__45F365D3");
        });

        modelBuilder.Entity<Contenido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contenid__3214EC2714DCCD6F");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idclase).HasColumnName("IDClase");
            entity.Property(e => e.Idtipo).HasColumnName("IDTipo");

            entity.HasOne(d => d.IdclaseNavigation).WithMany(p => p.Contenidos)
                .HasForeignKey(d => d.Idclase)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contenido__IDCla__4AB81AF0");

            entity.HasOne(d => d.IdtipoNavigation).WithMany(p => p.Contenidos)
                .HasForeignKey(d => d.Idtipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contenido__IDTip__4BAC3F29");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cursos__3214EC27FCCB2B1E");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CostoCertificacion).HasColumnType("money");
            entity.Property(e => e.CostoCurso).HasColumnType("money");
            entity.Property(e => e.Idnivel).HasColumnName("IDNivel");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdnivelNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.Idnivel)
                .HasConstraintName("FK__Cursos__IDNivel__412EB0B6");

            entity.HasMany(d => d.Idcategoria).WithMany(p => p.Idcursos)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoriasXCurso",
                    r => r.HasOne<Categoria>().WithMany()
                        .HasForeignKey("Idcategoria")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Categoria__IDCat__5535A963"),
                    l => l.HasOne<Curso>().WithMany()
                        .HasForeignKey("Idcurso")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Categoria__IDCur__5441852A"),
                    j =>
                    {
                        j.HasKey("Idcurso", "Idcategoria").HasName("PK__Categori__033959472DC54AB1");
                        j.ToTable("Categorias_x_Curso");
                        j.IndexerProperty<long>("Idcurso").HasColumnName("IDCurso");
                        j.IndexerProperty<short>("Idcategoria").HasColumnName("IDCategoria");
                    });
        });

        modelBuilder.Entity<DatosPersonale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Datos_Pe__3214EC27E0C32C2E");

            entity.ToTable("Datos_Personales");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Domicilio)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(140)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Idlocalidad).HasColumnName("IDLocalidad");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.DatosPersonale)
                .HasForeignKey<DatosPersonale>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Datos_Person__ID__5FB337D6");

            entity.HasOne(d => d.IdlocalidadNavigation).WithMany(p => p.DatosPersonales)
                .HasForeignKey(d => d.Idlocalidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Datos_Per__IDLoc__60A75C0F");
        });

        modelBuilder.Entity<FormatosIdioma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Formatos__3214EC275C1A6063");

            entity.ToTable("FormatosIdioma");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Idioma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Idiomas__3214EC275F304C6F");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IdiomasXCurso>(entity =>
        {
            entity.HasKey(e => new { e.Idcurso, e.Ididioma, e.IdformatoIdioma }).HasName("PK__Idiomas___099616D408BF19A8");

            entity.ToTable("Idiomas_x_Curso");

            entity.Property(e => e.Idcurso).HasColumnName("IDCurso");
            entity.Property(e => e.Ididioma).HasColumnName("IDIdioma");
            entity.Property(e => e.IdformatoIdioma).HasColumnName("IDFormatoIdioma");

            entity.HasOne(d => d.IdcursoNavigation).WithMany(p => p.IdiomasXCursos)
                .HasForeignKey(d => d.Idcurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Idiomas_x__IDCur__4F7CD00D");

            entity.HasOne(d => d.IdformatoIdiomaNavigation).WithMany(p => p.IdiomasXCursos)
                .HasForeignKey(d => d.IdformatoIdioma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Idiomas_x__IDFor__5165187F");

            entity.HasOne(d => d.IdidiomaNavigation).WithMany(p => p.IdiomasXCursos)
                .HasForeignKey(d => d.Ididioma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Idiomas_x__IDIdi__5070F446");
        });

        modelBuilder.Entity<Inscripcione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inscripc__3214EC27B77D4213");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Costo).HasColumnType("money");
            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Idcurso).HasColumnName("IDCurso");
            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

            entity.HasOne(d => d.IdcursoNavigation).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.Idcurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inscripci__IDCur__6477ECF3");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inscripci__IDUsu__6383C8BA");
        });

        modelBuilder.Entity<Localidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Localida__3214EC2763305A59");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Idpais).HasColumnName("IDPais");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdpaisNavigation).WithMany(p => p.Localidades)
                .HasForeignKey(d => d.Idpais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Localidad__IDPai__59FA5E80");
        });

        modelBuilder.Entity<Nivele>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Niveles__3214EC273994E153");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pagos__3214EC27803D6A08");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Idinscripcion).HasColumnName("IDInscripcion");
            entity.Property(e => e.Importe).HasColumnType("money");

            entity.HasOne(d => d.IdinscripcionNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.Idinscripcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pagos__IDInscrip__693CA210");
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paises__3214EC27C2065FCD");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reseña>(entity =>
        {
            entity.HasKey(e => e.Idinscripcion).HasName("PK__Reseñas__B4FD8345B10DF221");

            entity.Property(e => e.Idinscripcion)
                .ValueGeneratedNever()
                .HasColumnName("IDInscripcion");
            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.Puntaje).HasColumnType("decimal(3, 1)");

            entity.HasOne(d => d.IdinscripcionNavigation).WithOne(p => p.Reseña)
                .HasForeignKey<Reseña>(d => d.Idinscripcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reseñas__IDInscr__72C60C4A");
        });

        modelBuilder.Entity<TiposContenido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TiposCon__3214EC2725B145D5");

            entity.ToTable("TiposContenido");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC2733B055C6");

            entity.HasIndex(e => e.NombreUsuario, "UQ__Usuarios__6B0F5AE08F88F34D").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.Idcursos).WithMany(p => p.Idusuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "InstructoresXCurso",
                    r => r.HasOne<Curso>().WithMany()
                        .HasForeignKey("Idcurso")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Instructo__IDCur__787EE5A0"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("Idusuario")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Instructo__IDUsu__778AC167"),
                    j =>
                    {
                        j.HasKey("Idusuario", "Idcurso").HasName("PK__Instruct__1B726CD3BE294639");
                        j.ToTable("Instructores_x_Curso");
                        j.IndexerProperty<long>("Idusuario").HasColumnName("IDUsuario");
                        j.IndexerProperty<long>("Idcurso").HasColumnName("IDCurso");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
