using System.ComponentModel.DataAnnotations;

namespace GestionEstudiantes.Models;

public class Asignatura
{
    [Key]
    public int AsignaturaId { get; set; }

    [Required(ErrorMessage = "El codigo es obligatorio.")]
    public string? Codigo { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El aula es obligatoria.")]
    public string? Aula { get; set; }

    [Required(ErrorMessage = "Los creditos son obligatorios.")]
    [Range(1, 10, ErrorMessage = "Los creditos deben estar entre 1 y 10.")]
    public int Creditos { get; set; }
}