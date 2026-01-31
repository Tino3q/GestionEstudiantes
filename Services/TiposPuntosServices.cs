using GestionEstudiantes.DAL;
using GestionEstudiantes.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEstudiantes.Services;

public class TiposPuntosServices
{
    private readonly Contexto _context;

    public TiposPuntosServices(Contexto context)
    {
        _context = context;
    }

    public async Task<bool> Guardar(TiposPuntos tipo)
    {
        if (!await Existe(tipo.Nombre))
            return await Insertar(tipo);
        else
            return false;
    }

    private async Task<bool> Existe(string nombre)
    {
        return await _context.TiposPuntos.AnyAsync(t => t.Nombre.ToLower() == nombre.ToLower());
    }

    private async Task<bool> Insertar(TiposPuntos tipo)
    {
        _context.TiposPuntos.Add(tipo);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<TiposPuntos>> Listar()
    {
        return await _context.TiposPuntos.ToListAsync();
    }
    public async Task<TiposPuntos?> Buscar(int id)
    {
        return await _context.TiposPuntos.FirstOrDefaultAsync(t => t.TipoId == id);
    }
}
