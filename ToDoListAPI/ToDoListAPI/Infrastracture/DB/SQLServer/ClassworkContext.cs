using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;

namespace ToDoListAPI.Infrastracture.DB.SQLServer;

public partial class ClassworkContext : DbContext
{
    public ClassworkContext()
    {
    }

    public ClassworkContext(DbContextOptions<ClassworkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ToDoList> ToDoLists { get; set; }

    public virtual DbSet<ToDoListUser> ToDoListUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:sqlserver");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__to_do_li__3213E83FE94F8674");

            entity.ToTable("to_do_list");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Deadline).HasColumnName("deadline");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Detail)
                .HasColumnType("text")
                .HasColumnName("detail");
            entity.Property(e => e.Place)
                .IsUnicode(false)
                .HasColumnName("place");
            entity.Property(e => e.Remarks)
                .HasColumnType("text")
                .HasColumnName("remarks");
            entity.Property(e => e.Title)
                .HasColumnType("text")
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<ToDoListUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__to_do_li__3213E83F09402684");

            entity.ToTable("to_do_list_user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.ToDoListId).HasColumnName("to_do_list_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.ToDoList).WithMany(p => p.ToDoListUsers)
                .HasForeignKey(d => d.ToDoListId)
                .HasConstraintName("FK_ToDoList_ID");

            entity.HasOne(d => d.User).WithMany(p => p.ToDoListUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ToDoList_User_ID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83F85EC9DCF");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
