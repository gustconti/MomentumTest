using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MomentumTest.Data;
using System;
using System.Linq;

namespace MomentumTest.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new MomentumTestContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MomentumTestContext>>());
        // Look for any Guests.
        if (context.Guest.Any())
        {
            return;   // DB has been seeded
        }
        context.Guest.AddRange(
            new Guest
            {
                Id = 1,
                Name = "Roberto Silva",
                CpfCnpj = "448.002.870-65",
                Email = "roberto@gmail.com",
                Bairro = "Ponte Grande",
                Cep = "08780790",
                Cidade = "Mogi das Cruzes",
                Complemento = "Segundo andar.",
                Endereco = "R. Laranjeiras",
                Estado = "SP",
                Numero = "12",
                Telefone = "+55(11)912345678"
            },
            new Guest
            {
                Id = 2,
                Name = "Gustavo Conti",
                CpfCnpj = "999.483.370-77",
                Email = "gustavo@gmail.com",
                Bairro = "Rodeio",
                Cep = "08780790",
                Cidade = "São Paulo",
                Complemento = "Ao lado da padaria.",
                Endereco = "R. Augusta",
                Estado = "SP",
                Numero = "23",
                Telefone = "+55(11)912345678"
            },
            new Guest
            {
                Id = 3,
                Name = "Momentum - Empreendimentos Imobiliários",
                CpfCnpj = "84.279.672/0001-78",
                Email = "exemplo123@momentumexemplo.com",
                Bairro = "Cerqueira César",
                Cep = "01411902",
                Cidade = "São Paulo",
                Complemento = "6º andar",
                Endereco = "R. Padre João Manuel",
                Estado = "SP",
                Numero = "775",
                Telefone = "+55(11)30651313"
            });

        if (context.Status.Any())
        {
            return;   // DB has been seeded
        }
        context.Status.AddRange(
            new Status
            {
                Id = 1,
                Name = "Ativa",
                Color = "green"
            },
            new Status
            {
                Id = 2,
                Name = "Finalizada",
                Color = "gray"
            },
            new Status
            {
                Id = 3,
                Name = "Pendente",
                Color = "yellow"
            },
            new Status
            {
                Id = 4,
                Name = "Cancelada",
                Color = "red"
            });

        if (context.Reservation.Any())
        {
            return;   // DB has been seeded
        }
        context.Reservation.AddRange(
            new Reservation
            {
                Id = 1,
                StartDate = DateTime.Parse("2024-10-08"),
                EndDate = DateTime.Parse("2024-10-10"),
                StatusId = 1,
                MainGuestId = 1
            },
            new Reservation
            {
                Id = 2,
                StartDate = DateTime.Parse("2024-10-21"),
                EndDate = DateTime.Parse("2024-10-23"),
                StatusId = 2,
                MainGuestId = 2
            },
            new Reservation
            {
                Id = 3,
                StartDate = DateTime.Parse("2024-10-12"),
                EndDate = DateTime.Parse("2024-10-16"),
                StatusId = 3,
                MainGuestId = 3
            },
            new Reservation
            {
                Id = 4,
                StartDate = DateTime.Parse("2024-10-05"),
                EndDate = DateTime.Parse("2024-10-02"),
                StatusId = 3,
                MainGuestId = 3
            }
        );
        context.SaveChanges();
    }
}