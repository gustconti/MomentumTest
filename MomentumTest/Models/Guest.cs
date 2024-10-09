using System.ComponentModel.DataAnnotations;
using MomentumTest.Validations;

namespace MomentumTest.Models;

public class Guest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [CpfCnpj]
    public required string  CpfCnpj { get; set; }
    [EmailAddress(ErrorMessage = "Email inválido.")]
    public required string Email { get; set; }
    public string? Telefone { get; set; }
    public string? Cep { get; set; }
    public string? Endereco { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public ICollection<Reservation>? Reservations { get; set; }

}