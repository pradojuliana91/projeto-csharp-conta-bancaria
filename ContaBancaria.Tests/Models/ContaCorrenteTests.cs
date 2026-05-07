using ContaBancaria.Models;
using FluentAssertions;

namespace ContaBancaria.Tests.Models
{
    public class ContaCorrenteTests
    {
        [Fact]
        public void Sacar_ValorValido_DeveDiminuirSaldo()
        {
            // Arrange
            var conta = new ContaCorrente(
                1,
                1,
                123,
                "Juliana",
                1000,
                500
            );

            // Act
            var resultado = conta.Sacar(200);

            // Assert
            resultado.Should().BeTrue();
            conta.Saldo.Should().Be(800);
        }

        [Fact]
        public void Sacar_ValorNegativo_DeveRetornarFalse()
        {
            // Arrange
            var conta = new ContaCorrente(
                1,
                1,
                123,
                "Juliana",
                1000,
                500
            );

            // Act
            var resultado = conta.Sacar(-100);

            // Assert
            resultado.Should().BeFalse();
            conta.Saldo.Should().Be(1000);
        }

        [Fact]
        public void Sacar_ValorZero_DeveRetornarFalse()
        {
            // Arrange
            var conta = new ContaCorrente(
                1,
                1,
                123,
                "Juliana",
                1000,
                500
            );

            // Act
            var resultado = conta.Sacar(0);

            // Assert
            resultado.Should().BeFalse();
            conta.Saldo.Should().Be(1000);
        }

        [Fact]
        public void Sacar_UsandoLimite_DevePermitirSaque()
        {
            // Arrange
            var conta = new ContaCorrente(
                1,
                1,
                123,
                "Juliana",
                100,
                500
            );

            // Act
            var resultado = conta.Sacar(300);

            // Assert
            resultado.Should().BeTrue();
            conta.Saldo.Should().Be(-200);
        }

        [Fact]
        public void Sacar_SaldoInsuficiente_DeveRetornarFalse()
        {
            // Arrange
            var conta = new ContaCorrente(
                1,
                1,
                123,
                "Juliana",
                1000,
                500
            );
            // Act
            var resultado = conta.Sacar(1600);
            // Assert
            resultado.Should().BeFalse();
            conta.Saldo.Should().Be(1000);
        }

        [Fact]
        public void ExibirDadosConta_DeveRetornarDadosFormatados()
        {
            // Arrange
            var conta = new ContaCorrente(
                1,
                1,
                123,
                "Juliana",
                1000,
                500
            );
            // Act
            var resultado = conta.ExibirDadosConta();
            // Assert
            resultado.Should().Be("Tipo: Corrente, Agência: 1, Número: 123, Titular: Juliana, Saldo: 1000, Limite: 500");
        }
    }
}
