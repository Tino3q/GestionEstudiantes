using GestionEstudiantes.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEstudiantes.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Estudiante> Estudiantes { get; set;}
    public DbSet<Asignatura> Asignaturas { get; set;}

    public DbSet<TiposPuntos> TiposPuntos { get; set; }



}
