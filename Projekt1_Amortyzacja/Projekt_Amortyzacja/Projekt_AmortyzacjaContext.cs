using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Projekt1_Amortyzacja.Projekt_Amortyzacja
{
    public partial class Projekt_AmortyzacjaContext : DbContext
    {
        public Projekt_AmortyzacjaContext()
        {
        }

        public Projekt_AmortyzacjaContext(DbContextOptions<Projekt_AmortyzacjaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Amortyzacja> Amortyzacjas { get; set; } = null!;
        public virtual DbSet<Klasyfikacja> Klasyfikacjas { get; set; } = null!;
        public virtual DbSet<PlanAmortyzacji> PlanAmortyzacjis { get; set; } = null!;
        public virtual DbSet<SrodekTrwaly> SrodekTrwalies { get; set; } = null!;
        public virtual DbSet<WartoscSrodkaTrwalego> WartoscSrodkaTrwalegos { get; set; } = null!;
        public virtual DbSet<Wytworca> Wytworcas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-IKCEP9LL\\SQLEXPRESS;Initial Catalog=Projekt_Amortyzacja;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amortyzacja>(entity =>
            {
                entity.HasKey(e => e.IdAmortyzacji)
                    .HasName("PK__Amortyza__2E81E58328DA4DD5");

                entity.ToTable("Amortyzacja", "Ksiegowosc");

                entity.Property(e => e.IdAmortyzacji)
                    .IsRequired()
                    .HasColumnName("Id_amortyzacji");

                entity.Property(e => e.IdPlanu).HasColumnName("Id_planu");

                entity.Property(e => e.KwotaRozliczona)
                    .HasColumnType("money")
                    .HasColumnName("Kwota_rozliczona");

                entity.Property(e => e.WartoscRozliczenia)
                    .HasColumnType("money")
                    .HasColumnName("Wartosc_rozliczenia");

                entity.HasOne(d => d.IdPlanuNavigation)
                    .WithMany(p => p.Amortyzacjas)
                    .HasForeignKey(d => d.IdPlanu)
                    .HasConstraintName("rAmortyzacja_Plan");
            });

            modelBuilder.Entity<Klasyfikacja>(entity =>
            {
                entity.HasKey(e => e.IdKlasy)
                    .HasName("PK__Klasyfik__C462818CB4A98AB3");

                entity.ToTable("Klasyfikacja", "Ksiegowosc");

                entity.Property(e => e.IdKlasy)
                    .IsRequired()
                    .HasColumnName("Id_klasy");

                entity.Property(e => e.NrGrupy).HasColumnName("Nr_grupy");

                entity.Property(e => e.NrPodgrupy).HasColumnName("Nr_podgrupy");

                entity.Property(e => e.Opis).HasColumnType("text");

                entity.Property(e => e.StawkaAmortyzacji).HasColumnName("Stawka_amortyzacji");
            });

            modelBuilder.Entity<PlanAmortyzacji>(entity =>
            {
                entity.HasKey(e => e.IdPlanu)
                    .HasName("PK__Plan_amo__E3B65692EC35D93B");

                entity.ToTable("Plan_amortyzacji", "Ksiegowosc");

                entity.Property(e => e.IdPlanu)
                    .IsRequired()
                    .HasColumnName("Id_planu");

                entity.Property(e => e.DataWprowadzenia)
                    .HasColumnType("date")
                    .HasColumnName("Data_wprowadzenia");

                entity.Property(e => e.IdWartosci).HasColumnName("Id_wartosci");

                entity.Property(e => e.WartoscAmortyzacji)
                    .HasColumnType("money")
                    .HasColumnName("Wartosc_amortyzacji");

                entity.HasOne(d => d.IdWartosciNavigation)
                    .WithMany(p => p.PlanAmortyzacjis)
                    .HasForeignKey(d => d.IdWartosci)
                    .HasConstraintName("rPlan_Wartosc");
            });

            modelBuilder.Entity<SrodekTrwaly>(entity =>
            {
                entity.HasKey(e => e.NrSrodkaTrwalego)
                    .HasName("PK__Srodek_t__C1BB9D2859BC8E89");

                entity.ToTable("Srodek_trwaly", "K_UR");

                entity.Property(e => e.NrSrodkaTrwalego)
                    .IsRequired()
                    .HasColumnName("Nr_srodka_trwalego");

                entity.Property(e => e.DataPrzyjecia)
                    .HasColumnType("date")
                    .HasColumnName("Data_przyjecia");

                entity.Property(e => e.DataZakupu)
                    .HasColumnType("date")
                    .HasColumnName("Data_zakupu");

                entity.Property(e => e.IdKlasy).HasColumnName("Id_klasy");

                entity.Property(e => e.IdWytworcy).HasColumnName("Id_wytworcy");

                entity.Property(e => e.Lokalizacja)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Opis).HasColumnType("nvarchar");

                entity.HasOne(d => d.IdKlasyNavigation)
                    .WithMany(p => p.SrodekTrwalies)
                    .HasForeignKey(d => d.IdKlasy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rST_Klasa");

                entity.HasOne(d => d.IdWytworcyNavigation)
                    .WithMany(p => p.SrodekTrwalies)
                    .HasForeignKey(d => d.IdWytworcy)
                    .HasConstraintName("rST_Wytworca");
            });

            modelBuilder.Entity<WartoscSrodkaTrwalego>(entity =>
            {
                entity.HasKey(e => e.IdWartosci)
                    .HasName("PK__Wartosc___22A5AC06A5A496FF");

                entity.ToTable("Wartosc_srodka_trwalego", "K_UR");

                entity.Property(e => e.IdWartosci)
                    .IsRequired()
                    .HasColumnName("Id_wartosci");

                entity.Property(e => e.DataAktualizacji)
                    .HasColumnType("date")
                    .HasColumnName("Data_aktualizacji");

                entity.Property(e => e.NrSrodkaTrwalego).HasColumnName("Nr_srodka_trwalego");

                entity.Property(e => e.Wartosc).HasColumnType("money");

                entity.HasOne(d => d.NrSrodkaTrwalegoNavigation)
                    .WithMany(p => p.WartoscSrodkaTrwalegos)
                    .HasForeignKey(d => d.NrSrodkaTrwalego)
                    .HasConstraintName("rWartosc_ST");
            });

            modelBuilder.Entity<Wytworca>(entity =>
            {
                entity.HasKey(e => e.IdWytworcy)
                    .HasName("PK__Wytworca__7E85593F20911A0B");

                entity.ToTable("Wytworca", "K_UR");

                entity.Property(e => e.IdWytworcy)
                    .IsRequired()
                    .HasColumnName("Id_wytworcy");

                entity.Property(e => e.Email).HasMaxLength(32);

                entity.Property(e => e.Kraj).HasMaxLength(32);

                entity.Property(e => e.Miejscowosc).HasMaxLength(32);

                entity.Property(e => e.Nazwa).HasMaxLength(32);

                entity.Property(e => e.Nip)
                    .HasMaxLength(10)
                    .HasColumnName("NIP");

                entity.Property(e => e.NrLokalu)
                    .HasMaxLength(10)
                    .HasColumnName("Nr_lokalu");

                entity.Property(e => e.Telefon).HasMaxLength(16);

                entity.Property(e => e.Ulica).HasMaxLength(32);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
