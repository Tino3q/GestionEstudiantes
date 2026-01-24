using GestionEstudiantes.DAL;
using GestionEstudiantes.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionEstudiantes.Services;

public class EstudiantesService
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public EstudiantesService(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<List<Estudiante>> Listar(Expression<Func<Estudiante, bool>> criterio)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Estudiante?> Buscar(int id)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EstudianteId == id);
    }

    public async Task Guardar(Estudiante estudiante)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();

        if (estudiante.EstudianteId == 0)
            contexto.Estudiantes.Add(estudiante);
        else
            contexto.Estudiantes.Update(estudiante);

        await contexto.SaveChangesAsync();
    }

    public async Task Eliminar(int id)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        var estudiante = await contexto.Estudiantes.FindAsync(id);

        if (estudiante != null)
        {
            contexto.Estudiantes.Remove(estudiante);
            await contexto.SaveChangesAsync();
        }
    }
}
