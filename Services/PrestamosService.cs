using EnmanuelGomez_Ap1_P1.DAL;
using EnmanuelGomez_Ap1_P1.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EnmanuelGomez_Ap1_P1.Services;

public class PrestamosService
{
    private readonly Contexto _context;

    public PrestamosService(Contexto context) => _context = context;

    public async Task<bool> Guardar(Prestamos pretamos)
    {
        if (!await Existe(pretamos.Id))
            return await Insertar(pretamos);
        else
            return await Modificar(pretamos);
    }

    public async Task<bool> Insertar(Prestamos pretamos)
    {
        _context.Prestamos.Add(pretamos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Prestamos pretamos)
    {
        _context.Prestamos.Update(pretamos);
        return await _context.SaveChangesAsync() > 0;
    }


    public async Task<bool> Existe(int id)
    {
        return await _context.Prestamos
            .AnyAsync(p => p.Id == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var pretamo = await _context.Prestamos
                .Where(t => t.Id == id)
                .ExecuteDeleteAsync();
        return pretamo > 0;
    }

    public async Task<Prestamos> Buscar(int id)
    {
        return await _context.Prestamos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Prestamos?> BuscarNombre(string Deudor)
    {
        return await _context.Prestamos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Deudor == Deudor);
    }

    public async Task<List<Prestamos>> Listar(Expression<Func<Prestamos, bool>> criterio) => await _context.Prestamos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
}