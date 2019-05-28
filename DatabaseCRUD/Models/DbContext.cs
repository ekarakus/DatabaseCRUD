using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Db : DbContext
{
    public Db(DbContextOptions<Db> options) : base(options)
    {

    }
    public DbSet<cinsiyet> cinsiyetler { get; set; }
    public DbSet<personel> personeller { get; set; }
}

