using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SeguimientosDeGraduados.Models;

public partial class SeguimientoGraduadosContext : DbContext
{
    public SeguimientoGraduadosContext()
    {
    }

    public SeguimientoGraduadosContext(DbContextOptions<SeguimientoGraduadosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AplicacionesGraduado> AplicacionesGraduados { get; set; }

    public virtual DbSet<CatAreasAcademica> CatAreasAcademicas { get; set; }

    public virtual DbSet<CatAsignatura> CatAsignaturas { get; set; }

    public virtual DbSet<CatCarrera> CatCarreras { get; set; }

    public virtual DbSet<CatEmpresa> CatEmpresas { get; set; }

    public virtual DbSet<CatFormasCulminacion> CatFormasCulminacions { get; set; }

    public virtual DbSet<CatPensumCarreraAsignatura> CatPensumCarreraAsignaturas { get; set; }

    public virtual DbSet<CatSedesCur> CatSedesCurs { get; set; }

    public virtual DbSet<ContactosTelefonico> ContactosTelefonicos { get; set; }

    public virtual DbSet<ConveniosInstitucionale> ConveniosInstitucionales { get; set; }

    public virtual DbSet<CorreosElectronico> CorreosElectronicos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Direccione> Direcciones { get; set; }

    public virtual DbSet<Graduado> Graduados { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<OfertasLaborale> OfertasLaborales { get; set; }

    public virtual DbSet<ProveedoresTelefonico> ProveedoresTelefonicos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SituacionLaboral> SituacionLaborals { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AplicacionesGraduado>(entity =>
        {
            entity.HasKey(e => e.IdAplicacion).HasName("PK__aplicaci__D3D4F74ACCB64A6F");

            entity.ToTable("aplicaciones_graduados");

            entity.Property(e => e.IdAplicacion).HasColumnName("id_aplicacion");
            entity.Property(e => e.FechaAplicacion).HasColumnName("fecha_aplicacion");
            entity.Property(e => e.FueContratado).HasColumnName("fue_contratado");
            entity.Property(e => e.IdGraduado).HasColumnName("id_graduado");
            entity.Property(e => e.IdOferta).HasColumnName("id_oferta");

            entity.HasOne(d => d.IdGraduadoNavigation).WithMany(p => p.AplicacionesGraduados)
                .HasForeignKey(d => d.IdGraduado)
                .HasConstraintName("FK_aplicacion_graduado");

            entity.HasOne(d => d.IdOfertaNavigation).WithMany(p => p.AplicacionesGraduados)
                .HasForeignKey(d => d.IdOferta)
                .HasConstraintName("FK_aplicacion_oferta");
        });

        modelBuilder.Entity<CatAreasAcademica>(entity =>
        {
            entity.HasKey(e => e.IdArea).HasName("PK__cat_area__8A8C837BBC29F8E0");

            entity.ToTable("cat_areas_academicas");

            entity.Property(e => e.IdArea).HasColumnName("id_area");
            entity.Property(e => e.NombreArea)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_area");
        });

        modelBuilder.Entity<CatAsignatura>(entity =>
        {
            entity.HasKey(e => e.IdAsignatura).HasName("PK__cat_asig__33A22F4C39439C35");

            entity.ToTable("cat_asignaturas");

            entity.Property(e => e.IdAsignatura).HasColumnName("id_asignatura");
            entity.Property(e => e.CodigoClase)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codigo_clase");
            entity.Property(e => e.NombreClase)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_clase");
        });

        modelBuilder.Entity<CatCarrera>(entity =>
        {
            entity.HasKey(e => e.IdCarrera).HasName("PK__cat_carr__82525F2611F30203");

            entity.ToTable("cat_carreras");

            entity.Property(e => e.IdCarrera).HasColumnName("id_carrera");
            entity.Property(e => e.IdAreaFk).HasColumnName("id_area_FK");
            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre_carrera");

            entity.HasOne(d => d.IdAreaFkNavigation).WithMany(p => p.CatCarreras)
                .HasForeignKey(d => d.IdAreaFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_carrera_area");
        });

        modelBuilder.Entity<CatEmpresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__cat_empr__4A0B7E2CAA8CB9C4");

            entity.ToTable("cat_empresas");

            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.ContactoCargo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contacto_cargo");
            entity.Property(e => e.ContactoNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contacto_nombre");
            entity.Property(e => e.IdCorreoElectronicoFk).HasColumnName("id_correo_electronico_FK");
            entity.Property(e => e.IdDireccion).HasColumnName("id_direccion");
            entity.Property(e => e.IdTelefonoFk).HasColumnName("id_telefono_FK");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre_empresa");

            entity.HasOne(d => d.IdCorreoElectronicoFkNavigation).WithMany(p => p.CatEmpresas)
                .HasForeignKey(d => d.IdCorreoElectronicoFk)
                .HasConstraintName("FK_empresa_correo");

            entity.HasOne(d => d.IdDireccionNavigation).WithMany(p => p.CatEmpresas)
                .HasForeignKey(d => d.IdDireccion)
                .HasConstraintName("FK_empresa_direccion");

            entity.HasOne(d => d.IdTelefonoFkNavigation).WithMany(p => p.CatEmpresas)
                .HasForeignKey(d => d.IdTelefonoFk)
                .HasConstraintName("FK_empresa_telefono");
        });

        modelBuilder.Entity<CatFormasCulminacion>(entity =>
        {
            entity.HasKey(e => e.IdForma).HasName("PK__cat_form__A8D6EBFE6EA54579");

            entity.ToTable("cat_formas_culminacion");

            entity.Property(e => e.IdForma).HasColumnName("id_forma");
            entity.Property(e => e.NombreMetodo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_metodo");
        });

        modelBuilder.Entity<CatPensumCarreraAsignatura>(entity =>
        {
            entity.HasKey(e => new { e.IdCarreraFk, e.IdAsignaturaFk }).HasName("PK__cat_pens__6C6C54198D86DDF5");

            entity.ToTable("cat_pensum_carrera_asignatura");

            entity.Property(e => e.IdCarreraFk).HasColumnName("id_carrera_FK");
            entity.Property(e => e.IdAsignaturaFk).HasColumnName("id_asignatura_FK");
            entity.Property(e => e.AnioAsignado).HasColumnName("anio_asignado");

            entity.HasOne(d => d.IdAsignaturaFkNavigation).WithMany(p => p.CatPensumCarreraAsignaturas)
                .HasForeignKey(d => d.IdAsignaturaFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pensum_asignatura");

            entity.HasOne(d => d.IdCarreraFkNavigation).WithMany(p => p.CatPensumCarreraAsignaturas)
                .HasForeignKey(d => d.IdCarreraFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pensum_carrera");
        });

        modelBuilder.Entity<CatSedesCur>(entity =>
        {
            entity.HasKey(e => e.IdSede).HasName("PK__cat_sede__D693504B3AF808C8");

            entity.ToTable("cat_sedes_cur");

            entity.Property(e => e.IdSede).HasColumnName("id_sede");
            entity.Property(e => e.IdDireccionFk).HasColumnName("id_direccion_FK");
            entity.Property(e => e.NombreSede)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_sede");

            entity.HasOne(d => d.IdDireccionFkNavigation).WithMany(p => p.CatSedesCurs)
                .HasForeignKey(d => d.IdDireccionFk)
                .HasConstraintName("FK_sede_direccion");
        });

        modelBuilder.Entity<ContactosTelefonico>(entity =>
        {
            entity.HasKey(e => e.IdTelefono).HasName("PK__contacto__28CD680279EEC0AB");

            entity.ToTable("contactos_telefonicos");

            entity.Property(e => e.IdTelefono).HasColumnName("id_telefono");
            entity.Property(e => e.IdProveedorTelefonoFk).HasColumnName("id_proveedor_telefono_FK");
            entity.Property(e => e.TelefonoConvencional)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono_convencional");
            entity.Property(e => e.TelefonoMovil)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono_movil");

            entity.HasOne(d => d.IdProveedorTelefonoFkNavigation).WithMany(p => p.ContactosTelefonicos)
                .HasForeignKey(d => d.IdProveedorTelefonoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_telefono_proveedor");
        });

        modelBuilder.Entity<ConveniosInstitucionale>(entity =>
        {
            entity.HasKey(e => e.IdConvenio).HasName("PK__convenio__177BD43ED438D1FF");

            entity.ToTable("convenios_institucionales");

            entity.Property(e => e.IdConvenio).HasColumnName("id_convenio");
            entity.Property(e => e.EstadoConvenio).HasColumnName("estado_convenio");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.TipoConvenio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipo_convenio");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.ConveniosInstitucionales)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_convenio_empresa");
        });

        modelBuilder.Entity<CorreosElectronico>(entity =>
        {
            entity.HasKey(e => e.IdCorreoElectronico).HasName("PK__correos___D0A1E9D14A35F7C6");

            entity.ToTable("correos_electronicos");

            entity.HasIndex(e => e.CorreoInstitucional, "UQ__correos___107A1DDA646BD04B").IsUnique();

            entity.HasIndex(e => e.CorreoPersonal, "UQ__correos___C6CE90548B6FDB77").IsUnique();

            entity.Property(e => e.IdCorreoElectronico).HasColumnName("id_correo_electronico");
            entity.Property(e => e.CorreoInstitucional)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo_institucional");
            entity.Property(e => e.CorreoPersonal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo_personal");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__departam__64F37A16C4A59FB5");

            entity.ToTable("departamentos");

            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_departamento");
        });

        modelBuilder.Entity<Direccione>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__direccio__25C35D07E5A8441F");

            entity.ToTable("direcciones");

            entity.Property(e => e.IdDireccion).HasColumnName("id_direccion");
            entity.Property(e => e.DetalleDireccion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("detalle_direccion");
            entity.Property(e => e.IdMunicipioFk).HasColumnName("id_municipio_FK");

            entity.HasOne(d => d.IdMunicipioFkNavigation).WithMany(p => p.Direcciones)
                .HasForeignKey(d => d.IdMunicipioFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_direccion_municipio");
        });

        modelBuilder.Entity<Graduado>(entity =>
        {
            entity.HasKey(e => e.IdGraduado).HasName("PK__graduado__1B9B1B7E6C3D835E");

            entity.ToTable("graduados");

            entity.HasIndex(e => e.CedulaOPasaporte, "UQ__graduado__170801E23393AE88").IsUnique();

            entity.Property(e => e.IdGraduado).HasColumnName("id_graduado");
            entity.Property(e => e.CedulaOPasaporte)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cedula_o_pasaporte");
            entity.Property(e => e.EsExtranjero).HasColumnName("es_extranjero");
            entity.Property(e => e.EstadoAcademico)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado_academico");
            entity.Property(e => e.FechaEgreso).HasColumnName("fecha_egreso");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FechaTitulacion).HasColumnName("fecha_titulacion");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.IdCarreraFk).HasColumnName("id_carrera_FK");
            entity.Property(e => e.IdCorreoElectronicoFk).HasColumnName("id_correo_electronico_FK");
            entity.Property(e => e.IdDireccionFk).HasColumnName("id_direccion_FK");
            entity.Property(e => e.IdFormaFk).HasColumnName("id_forma_FK");
            entity.Property(e => e.IdSedeIngreso).HasColumnName("id_sede_ingreso");
            entity.Property(e => e.IdTelefonoFk).HasColumnName("id_telefono_FK");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nacionalidad");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("primer_apellido");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("primer_nombre");
            entity.Property(e => e.RutaCartaEgreso)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ruta_carta_egreso");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("segundo_apellido");
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("segundo_nombre");

            entity.HasOne(d => d.IdCarreraFkNavigation).WithMany(p => p.Graduados)
                .HasForeignKey(d => d.IdCarreraFk)
                .HasConstraintName("FK_graduado_carrera");

            entity.HasOne(d => d.IdCorreoElectronicoFkNavigation).WithMany(p => p.Graduados)
                .HasForeignKey(d => d.IdCorreoElectronicoFk)
                .HasConstraintName("FK_graduado_correo");

            entity.HasOne(d => d.IdDireccionFkNavigation).WithMany(p => p.Graduados)
                .HasForeignKey(d => d.IdDireccionFk)
                .HasConstraintName("FK_graduado_direccion");

            entity.HasOne(d => d.IdFormaFkNavigation).WithMany(p => p.Graduados)
                .HasForeignKey(d => d.IdFormaFk)
                .HasConstraintName("FK_graduado_forma");

            entity.HasOne(d => d.IdSedeIngresoNavigation).WithMany(p => p.Graduados)
                .HasForeignKey(d => d.IdSedeIngreso)
                .HasConstraintName("FK_graduado_sede");

            entity.HasOne(d => d.IdTelefonoFkNavigation).WithMany(p => p.Graduados)
                .HasForeignKey(d => d.IdTelefonoFk)
                .HasConstraintName("FK_graduado_telefono");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK__municipi__01C9EB99AF7EAFD3");

            entity.ToTable("municipios");

            entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");
            entity.Property(e => e.IdDepartamentoFk).HasColumnName("id_departamento_FK");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_municipio");

            entity.HasOne(d => d.IdDepartamentoFkNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdDepartamentoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_municipio_departamento");
        });

        modelBuilder.Entity<OfertasLaborale>(entity =>
        {
            entity.HasKey(e => e.IdOferta).HasName("PK__ofertas___2B7BF92F0FF99B59");

            entity.ToTable("ofertas_laborales");

            entity.Property(e => e.IdOferta).HasColumnName("id_oferta");
            entity.Property(e => e.IdCarreraRequerida).HasColumnName("id_carrera_requerida");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.OfertaActiva).HasColumnName("oferta_activa");
            entity.Property(e => e.PuestoOfrecido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("puesto_ofrecido");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.OfertasLaborales)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_oferta_empresa");
        });

        modelBuilder.Entity<ProveedoresTelefonico>(entity =>
        {
            entity.HasKey(e => e.IdProveedorTelefonico).HasName("PK__proveedo__F2A5B71C1E601BA1");

            entity.ToTable("proveedores_telefonicos");

            entity.Property(e => e.IdProveedorTelefonico).HasColumnName("id_proveedor_telefonico");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__roles__6ABCB5E0B3C85665");

            entity.ToTable("roles");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_rol");
        });

        modelBuilder.Entity<SituacionLaboral>(entity =>
        {
            entity.HasKey(e => e.IdLaboral).HasName("PK__situacio__C1A1B90D920EF44F");

            entity.ToTable("situacion_laboral");

            entity.Property(e => e.IdLaboral).HasColumnName("id_laboral");
            entity.Property(e => e.AfinidadCarrera).HasColumnName("afinidad_carrera");
            entity.Property(e => e.Cargo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cargo");
            entity.Property(e => e.EstaEmpleado).HasColumnName("esta_empleado");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdGraduado).HasColumnName("id_graduado");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre_empresa");

            entity.HasOne(d => d.IdGraduadoNavigation).WithMany(p => p.SituacionLaborals)
                .HasForeignKey(d => d.IdGraduado)
                .HasConstraintName("FK_situacion_graduado");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuarios__4E3E04ADA461E733");

            entity.ToTable("usuarios");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.EmailUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email_usuario");
            entity.Property(e => e.EstadoCuenta).HasColumnName("estado_cuenta");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");

            entity.HasMany(d => d.IdRols).WithMany(p => p.IdUsuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "RolesUsuario",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_rol"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_usuario"),
                    j =>
                    {
                        j.HasKey("IdUsuario", "IdRol").HasName("PK__roles_us__5895CFF3B354C0CF");
                        j.ToTable("roles_usuarios");
                        j.IndexerProperty<int>("IdUsuario").HasColumnName("id_usuario");
                        j.IndexerProperty<int>("IdRol").HasColumnName("id_rol");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
