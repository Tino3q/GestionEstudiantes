using System.ComponentModel.DataAnnotations;

namespace GestionEstudiantes.Models;

public class Estudiante
{
    [Key]
    public int EstudianteId { get; set; }

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public string Nombres { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo Es Requerido")]
    public int Edad { get; set; }

}
