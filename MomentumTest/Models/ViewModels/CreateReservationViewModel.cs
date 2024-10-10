using MomentumTest.Models;
using MomentumTest.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MomentumTest.Models.ViewModels
{
    public class CreateReservationViewModel
    {
        public int? ReservationId { get; set; }
        [Required(ErrorMessage = "CPF/CNPJ é obrigatório.")]
        [CpfCnpj(ErrorMessage = "CPF/CNPJ inválido.")]
        public string? CpfCnpj { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? ZipCode { get; set; }
        public string? Address { get; set; }
        public string? AddressNumber { get; set; }
        public string? Complement { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public List<string>? AdditionalGuests { get; set; } = [];
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Observations { get; set; }
        public Status? Status { get; set; }
        public List<Status> Statuses { get; set; } = [];
        public CreateReservationViewModel(Reservation reservation, List<Status> statuses)
        {
            ReservationId = reservation.Id;
            CpfCnpj = reservation.MainGuest.CpfCnpj;
            Email = reservation.MainGuest.Email;
            Name = reservation.MainGuest.Name;
            Phone = reservation.MainGuest.Telefone;
            ZipCode = reservation.MainGuest.Cep;
            Address = reservation.MainGuest.Endereco;
            AddressNumber = reservation.MainGuest.Numero;
            Complement = reservation.MainGuest.Complemento;
            Neighborhood = reservation.MainGuest.Bairro;
            City = reservation.MainGuest.Cidade;
            State = reservation.MainGuest.Estado;
            AdditionalGuests = reservation.AdditionalGuests;
            StartDate = reservation.StartDate;
            EndDate = reservation.EndDate;
            Observations = reservation.Observations;
            Status = reservation.Status;
            Statuses = statuses;
        }
    }
}
