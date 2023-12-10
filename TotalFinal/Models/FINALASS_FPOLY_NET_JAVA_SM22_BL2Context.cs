using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TotalFinal.Models
{
    public partial class FINALASS_FPOLY_NET_JAVA_SM22_BL2Context : DbContext
    {
        public FINALASS_FPOLY_NET_JAVA_SM22_BL2Context()
        {
        }

        public FINALASS_FPOLY_NET_JAVA_SM22_BL2Context(DbContextOptions<FINALASS_FPOLY_NET_JAVA_SM22_BL2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Ban> Bans { get; set; } = null!;
        public virtual DbSet<ChucVu> ChucVus { get; set; } = null!;
        public virtual DbSet<LoaiSp> LoaiSps { get; set; } = null!;
        public virtual DbSet<LoaiXm> LoaiXms { get; set; } = null!;
        public virtual DbSet<MoiQuanHe> MoiQuanHes { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<Nxb> Nxbs { get; set; } = null!;
        public virtual DbSet<Sach> Saches { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;
        public virtual DbSet<XeMay> XeMays { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SHANGHAIK;Database=FINALASS_FPOLY_NET_JAVA_SM22_BL2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ban>(entity =>
            {
                entity.ToTable("Ban");

                entity.HasIndex(e => e.Ma, "UQ__Ban__3214CC9EE4978E83")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.GioiTinh).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdMqh).HasColumnName("IdMQH");

                entity.Property(e => e.Ma)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.SoThich).HasMaxLength(30);

                entity.Property(e => e.Ten).HasMaxLength(30);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdMqhNavigation)
                    .WithMany(p => p.Bans)
                    .HasForeignKey(d => d.IdMqh)
                    .HasConstraintName("FK1_MQH");
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.ToTable("ChucVu");

                entity.HasIndex(e => e.Ma, "UQ__ChucVu__3214CC9E21F38A60")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<LoaiSp>(entity =>
            {
                entity.ToTable("LoaiSP");

                entity.HasIndex(e => e.Ma, "UQ__LoaiSP__3214CC9EB815686E")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<LoaiXm>(entity =>
            {
                entity.ToTable("LoaiXM");

                entity.HasIndex(e => e.Ma, "UQ__LoaiXM__3214CC9E027E7B96")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<MoiQuanHe>(entity =>
            {
                entity.ToTable("MoiQuanHe");

                entity.HasIndex(e => e.Ma, "UQ__MoiQuanH__3214CC9E4A21A193")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.ToTable("NhanVien");

                entity.HasIndex(e => e.Ma, "UQ__NhanVien__3214CC9EB0D318CF")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.Ho).HasMaxLength(30);

                entity.Property(e => e.IdCv).HasColumnName("IdCV");

                entity.Property(e => e.Ma)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau).IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ten).HasMaxLength(30);

                entity.Property(e => e.TenDem).HasMaxLength(30);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdCvNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.IdCv)
                    .HasConstraintName("FK1_NV");
            });

            modelBuilder.Entity<Nxb>(entity =>
            {
                entity.ToTable("NXB");

                entity.HasIndex(e => e.Ma, "UQ__NXB__3214CC9EEDFE26F0")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.ToTable("Sach");

                entity.HasIndex(e => e.Ma, "UQ__Sach__3214CC9EEECF0D62")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DonGia)
                    .HasColumnType("decimal(20, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IdNxb).HasColumnName("IdNXB");

                entity.Property(e => e.Ma)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NgayXuatBan).HasColumnType("date");

                entity.Property(e => e.SoTrang).HasDefaultValueSql("((0))");

                entity.Property(e => e.Ten).HasMaxLength(30);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdNxbNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.IdNxb)
                    .HasConstraintName("FK1_NXB");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.ToTable("SanPham");

                entity.HasIndex(e => e.Ma, "UQ__SanPham__3214CC9E6461F029")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.GiaBan)
                    .HasColumnType("decimal(20, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IdLoaiSp).HasColumnName("IdLoaiSP");

                entity.Property(e => e.Ma)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mota).HasMaxLength(30);

                entity.Property(e => e.NgaySx)
                    .HasColumnType("date")
                    .HasColumnName("NgaySX");

                entity.Property(e => e.SoLuong).HasDefaultValueSql("((0))");

                entity.Property(e => e.Ten).HasMaxLength(30);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.Property(e => e.Website).HasMaxLength(30);

                entity.HasOne(d => d.IdLoaiSpNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.IdLoaiSp)
                    .HasConstraintName("FK1_LSP");
            });

            modelBuilder.Entity<XeMay>(entity =>
            {
                entity.ToTable("XeMay");

                entity.HasIndex(e => e.Ma, "UQ__XeMay__3214CC9EBE7A687B")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.GiaBan)
                    .HasColumnType("decimal(20, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GiaNhap)
                    .HasColumnType("decimal(20, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IdLxm).HasColumnName("IdLXM");

                entity.Property(e => e.Ma)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mota).HasMaxLength(30);

                entity.Property(e => e.NgaySx)
                    .HasColumnType("date")
                    .HasColumnName("NgaySX");

                entity.Property(e => e.SoLuong).HasDefaultValueSql("((0))");

                entity.Property(e => e.Ten).HasMaxLength(30);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.Property(e => e.Website).HasMaxLength(30);

                entity.HasOne(d => d.IdLxmNavigation)
                    .WithMany(p => p.XeMays)
                    .HasForeignKey(d => d.IdLxm)
                    .HasConstraintName("FK1_LXM");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
