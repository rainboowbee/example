using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace laba6.Models;

public partial class EventsContext : DbContext
{
    public EventsContext()
    {
    }

    public EventsContext(DbContextOptions<EventsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=Events;Username=postgres;Password=Jocker365365");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_pkey");

            entity.ToTable("events");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.EventName)
                .HasMaxLength(255)
                .HasColumnName("event_name");
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .HasColumnName("street");
            entity.Property(e => e.TicketPrice).HasColumnName("ticket_price");
            entity.Property(e => e.TicketQuantity).HasColumnName("ticket_quantity");
            entity.Property(e => e.VenueName)
                .HasMaxLength(255)
                .HasColumnName("venue_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
