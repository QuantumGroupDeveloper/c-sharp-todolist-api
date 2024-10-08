﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;

namespace ToDoListAPI.Infrastracture.DB.MySQL;

public partial class TodolistContext : DbContext
{
    public TodolistContext()
    {
    }

    public TodolistContext(DbContextOptions<TodolistContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ToDoList> ToDoLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Server=localhost;Database=todolist;User ID=root;Password=");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("to_do_list");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Deadline)
                .HasMaxLength(6)
                .HasColumnName("deadline");
            entity.Property(e => e.DeletedAt)
                .HasMaxLength(6)
                .HasColumnName("deleted_at");
            entity.Property(e => e.Detail)
                .HasColumnType("text")
                .HasColumnName("detail");
            entity.Property(e => e.Place)
                .HasMaxLength(50)
                .HasColumnName("place");
            entity.Property(e => e.Remarks)
                .HasColumnType("text")
                .HasColumnName("remarks");
            entity.Property(e => e.Title)
                .HasColumnType("text")
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
