using System.ComponentModel.DataAnnotations;

namespace GestionEstudiantes.Models;

public class Asignatura
{
    [Key]
    public int AsignaturaId { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public string? Codigo { get; set; } 

    [Required(ErrorMessage = "Este Campo es Requerido.")]
    public string? Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public string? Aula { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    [Range(1, 10, ErrorMessage = "Los creditos deben estar entre 1 y 10.")]
    public int Creditos { get; set; }
}