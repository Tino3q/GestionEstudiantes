using Microsoft.EntityFrameworkCore;
using GestionEstudiantes.Models;
using GestionEstudiantes.DAL;

namespace GestionEstudiantes.Services;

public class AsignaturaService
{
    private readonly Contexto _contexto;

    public AsignaturaService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int asignaturaId, string nombre)
    {
        return await _contexto.Asignaturas
            .AnyAsync(a => a.AsignaturaId != asignaturaId
                      && a.Nombre.ToLower() == nombre.ToLower());
    }

    public async Task<bool> Guardar(Asignatura asignatura)
    {
        if (await Existe(asignatura.AsignaturaId, asignatura.Nombre))
            return false;

        if (asignatura.AsignaturaId == 0)
            _contexto.Asignaturas.Add(asignatura);
        else
            _contexto.Entry(asignatura).State = EntityState.Modified;

        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        var asignatura = await _contexto.Asignaturas.FindAsync(id);
        if (asignatura == null)
            return false;

        _contexto.Asignaturas.Remove(asignatura);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<Asignatura?> Buscar(int id)
    {
        return await _contexto.Asignaturas
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.AsignaturaId == id);
    }

    public async Task<List<Asignatura>> Listar(Func<Asignatura, bool> criterio)
    {
        return _contexto.Asignaturas
            .AsNoTracking()
            .Where(criterio)
            .ToList();
    }
}