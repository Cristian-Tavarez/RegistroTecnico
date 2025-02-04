﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tecnico> Tecnicos { get; set; }
}
// Data/ApplicationDbContext.cs
public DbSet<Ticket> Tickets { get; set; }