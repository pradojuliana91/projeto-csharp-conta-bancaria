using ContaBancaria.Controllers;
using ContaBancaria.Models;
using ContaBancaria.Repositories;
using ContaBancaria.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Tests.Controller;
public class ContaControllerTests
{
    private readonly Mock<IContaRepository> _repositoryMock;
    private readonly ContaController _controller;

    public ContaControllerTests()
    {
        _repositoryMock = new Mock<IContaRepository>();
        _controller = new ContaController(_repositoryMock.Object);
    }

    [Fact]
    public void ProcurarPorAgenciaENumero_DeveRetornarConta()
    {
        // Arrange
        Conta conta = new ContaCorrente(null, 1, 100, "João Pererira", -50, 500);

        _repositoryMock
            .Setup(x => x.ProcurarPorAgenciaENumero(1, 100))
            .Returns(conta);

        // Act
        Conta resultado = _controller.ProcurarPorAgenciaENumero(1, 100);

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(100, resultado.Numero);
    }

    [Fact]
    public void ProcurarPorAgenciaENumero_DeveLancarException_QuandoContaNaoExistir()
    {
        // Arrange
        _repositoryMock
            .Setup(x => x.ProcurarPorAgenciaENumero(1, 100))
            .Returns((Conta?)null);

        // Act & Assert
        Assert.Throws<ValidationException>(() =>
            _controller.ProcurarPorAgenciaENumero(1, 100));
    }

    [Fact]
    public void ListarTodas_DeveRetornarLista()
    {
        // Arrange
        List<Conta> contas = new()
            {
                new ContaCorrente(null, 15, 1400, "Maria Firmina", -50, 500),
                new ContaPoupanca(null, 2, 101, "João Pererira", 10, 25)
            };

        _repositoryMock
            .Setup(x => x.ListarTodas())
            .Returns(contas);

        // Act
        List<Conta> resultado = _controller.ListarTodas();

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(2, resultado.Count);
    }

    [Fact]
    public void ListarTodas_DeveLancarException_QuandoListaVazia()
    {
        // Arrange
        _repositoryMock
            .Setup(x => x.ListarTodas())
            .Returns(new List<Conta>());

        // Act & Assert
        Assert.Throws<ValidationException>(() =>
            _controller.ListarTodas());
    }

    [Fact]
    public void GerarNumero_DeveRetornarNumero()
    {
        // Arrange
        _repositoryMock
            .Setup(x => x.MaiorNumerContaPorAgencia(1))
            .Returns(10);

        // Act
        int numero = _controller.GerarNumero(1);

        // Assert
        Assert.Equal(10, numero);
    }

    [Fact]
    public void Cadastrar_DeveCadastrarConta()
    {
        // Arrange
        Conta conta = new ContaCorrente(null, 1, 100, "João Pererira", -50, 500);

        // Act
        _controller.Cadastrar(conta);

        // Assert
        _repositoryMock.Verify(
            x => x.Cadastrar(conta),
            Times.Once);
    }

    [Fact]
    public void Cadastrar_DeveLancarException_QuandoContaForNull()
    {
        // Act & Assert
        Assert.Throws<ValidationException>(() =>
            _controller.Cadastrar(null));
    }

    [Fact]
    public void Atualizar_DeveAtualizarConta()
    {
        // Arrange
        Conta conta = new ContaCorrente(null, 1, 100, "João Pererira", -50, 500);

        _repositoryMock
            .Setup(x => x.ProcurarPorAgenciaENumero(1, 100))
            .Returns(conta);

        // Act
        _controller.Atualizar(conta);

        // Assert
        _repositoryMock.Verify(
            x => x.Atualizar(conta),
            Times.Once);
    }

    [Fact]
    public void Atualizar_DeveLancarException_QuandoContaForNull()
    {
        // Act & Assert
        Assert.Throws<ValidationException>(() =>
            _controller.Atualizar(null));
    }

    [Fact]
    public void Deletar_DeveDeletarConta()
    {
        // Arrange
        Conta conta = new ContaCorrente(null, 1, 100, "João Pererira", -50, 500);

        _repositoryMock
            .Setup(x => x.ProcurarPorAgenciaENumero(1, 100))
            .Returns(conta);

        // Act
        _controller.Deletar(1, 100);

        // Assert
        _repositoryMock.Verify(
            x => x.Deletar(1, 100),
            Times.Once);
    }

    [Fact]
    public void Sacar_DeveRealizarSaque()
    {
        // Arrange
        Conta conta = new ContaCorrente(null, 1, 100, "João Pererira", -50, 500);

        _repositoryMock
            .Setup(x => x.ProcurarPorAgenciaENumero(1, 100))
            .Returns(conta);

        // Act
        _controller.Sacar(1, 100, 200);

        // Assert
        _repositoryMock.Verify(
            x => x.Sacar(1, 100, conta.Saldo),
            Times.Once);
    }

    [Fact]
    public void Sacar_DeveLancarException_QuandoSaldoInsuficiente()
    {
        // Arrange
        Conta conta = new ContaCorrente(null, 1, 100, "João Pererira", -50, 500);

        _repositoryMock
            .Setup(x => x.ProcurarPorAgenciaENumero(1, 100))
            .Returns(conta);

        // Act & Assert
        Assert.Throws<ValidationException>(() =>
            _controller.Sacar(1, 100, 500));
    }

    [Fact]
    public void Depositar_DeveDepositarValor()
    {
        // Arrange
        Conta conta = new ContaCorrente(null, 1, 100, "João Pererira", -50, 500);

        _repositoryMock
            .Setup(x => x.ProcurarPorAgenciaENumero(1, 100))
            .Returns(conta);

        // Act
        _controller.Depositar(1, 100, 500);

        // Assert
        _repositoryMock.Verify(
            x => x.Depositar(1, 100, 500),
            Times.Once);
    }

    [Fact]
    public void Transferir_DeveTransferirValor()
    {
        // Arrange
        Conta contaOrigem = new ContaCorrente(null, 1, 100, "João Pererira", -50, 500);

        Conta contaDestino = new ContaPoupanca(null, 2, 101, "Maria Firmina", 10, 25);

        _repositoryMock
            .Setup(x => x.ProcurarPorAgenciaENumero(1, 100))
            .Returns(contaOrigem);

        _repositoryMock
            .Setup(x => x.ProcurarPorAgenciaENumero(1, 200))
            .Returns(contaDestino);

        // Act
        _controller.Transferir(1, 100, 1, 200, 200);

        // Assert
        _repositoryMock.Verify(
            x => x.Transferir(1, 100, 1, 200, 200),
            Times.Once);
    }

    [Fact]
    public void Transferir_DeveLancarException_QuandoSaldoInsuficiente()
    {
        // Arrange
        Conta contaOrigem = new ContaCorrente(null, 1, 100, "João Pererira", 0, 500);
 
        _repositoryMock
            .Setup(x => x.ProcurarPorAgenciaENumero(1, 100))
            .Returns(contaOrigem);

        // Act & Assert
        Assert.Throws<ValidationException>(() =>
            _controller.Transferir(1, 100, 1, 200, 500));
    }

}
