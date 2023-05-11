using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackDigita.Models;

public partial class ProcessoSeletivoContext : DbContext
{
    public ProcessoSeletivoContext()
    {
    }
   
    public ProcessoSeletivoContext(DbContextOptions<ProcessoSeletivoContext> options): base(options)
    {
       
    }
    

    public virtual DbSet<Adm> Adms { get; set; }

    public virtual DbSet<Candidato> Candidatos { get; set; }

    public virtual DbSet<CandidatoxProcesso> CandidatoxProcessos { get; set; }

    public virtual DbSet<Fase> Fases { get; set; }

    public virtual DbSet<ProcessoSeletivo> ProcessoSeletivos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

        if(!optionsBuilder.IsConfigured){
            optionsBuilder.UseSqlServer("Server=CT-C-000E2\\SQLEXPRESS;Database=ProcessoSeletivo;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Adm__3214EC27EAB60A90");

            entity.ToTable("Adm");

            entity.Property(e => e.Id)
              
                .HasColumnName("ID");
            entity.Property(e => e.Ativo).HasColumnName("ativo");
            entity.Property(e => e.DataDeNascimento).HasColumnType("datetime");
            entity.Property(e => e.Edv)
                .IsUnicode(false)
                .HasColumnName("EDV");
            entity.Property(e => e.Nome).IsUnicode(false);
            entity.Property(e => e.Senha)
                .IsUnicode(false)
                .HasColumnName("senha");
        });

        modelBuilder.Entity<Candidato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Candidat__3214EC2774F9D416");

            entity.ToTable("Candidato");

            entity.Property(e => e.Id)
                
                .HasColumnName("ID");
            entity.Property(e => e.Curriculo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DataNascimento).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CandidatoxProcesso>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CandidatoxProcesso");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdCandidato).HasColumnName("ID_Candidato");
            entity.Property(e => e.IdFase).HasColumnName("ID_Fase");
            entity.Property(e => e.IdProcesso).HasColumnName("ID_Processo");

            entity.HasOne(d => d.IdCandidatoNavigation).WithMany()
                .HasForeignKey(d => d.IdCandidato)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Candidato__ID_Ca__2D27B809");

            entity.HasOne(d => d.IdFaseNavigation).WithMany()
                .HasForeignKey(d => d.IdFase)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Candidato__ID_Fa__2F10007B");

            entity.HasOne(d => d.IdProcessoNavigation).WithMany()
                .HasForeignKey(d => d.IdProcesso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Candidato__ID_Pr__2E1BDC42");
        });

        modelBuilder.Entity<Fase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Fase__3214EC27387ED9DE");

            entity.ToTable("Fase");

            entity.Property(e => e.Id)
               
                .HasColumnName("ID");
            entity.Property(e => e.Descrição).IsUnicode(false);
            entity.Property(e => e.IdProcessoSeletivo).HasColumnName("ID_ProcessoSeletivo");
            entity.Property(e => e.Local)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProcessoSeletivoNavigation).WithMany(p => p.Fases)
                .HasForeignKey(d => d.IdProcessoSeletivo)
                .HasConstraintName("FK__Fase__ID_Process__2B3F6F97");
        });

        modelBuilder.Entity<ProcessoSeletivo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Processo__3214EC272341FB85");

            entity.ToTable("ProcessoSeletivo");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nome).IsUnicode(false);
            entity.Property(e => e.DataFim).HasColumnType("datetime");
            entity.Property(e => e.DataInicio).HasColumnType("datetime");
            entity.HasOne(p => p.adm);
        });

        OnModelCreatingPartial(modelBuilder);
    }   

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
