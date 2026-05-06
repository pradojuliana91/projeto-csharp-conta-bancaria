using ContaBancaria.Models.Enums;

namespace ContaBancaria.Utils;
sealed class InputUtil
{
    public static int InputAgencia()
    {
        string? inputAgencia;
        while (true)
        {
            Cores.Input("\nDigite o número da agência (max 4 digitos): ");
            inputAgencia = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputAgencia))
            {
                Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                continue;
            }

            if (inputAgencia.Length > 4)
            {
                Cores.Erro("Número da agência inválido! Deve conter no máximo 4 dígitos. Tente novamente.\n");
                continue;
            }

            if (!inputAgencia.All(char.IsDigit))
            {
                Cores.Erro("Digite apenas números!\n");
                continue;
            }
            break;
        }
        return int.Parse(inputAgencia);
    }

    public static int InputNumeroConta()
    {
        string? inputNumeroConta;
        while (true)
        {
            Cores.Input("\nDigite o número da conta (max 6 digitos): ");
            inputNumeroConta = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputNumeroConta))
            {
                Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                continue;
            }
            if (inputNumeroConta.Length > 6)
            {
                Cores.Erro("Número da conta inválido! Deve conter no máximo 6 dígitos. Tente novamente.\n");
                continue;
            }
            if (!inputNumeroConta.All(char.IsDigit))
            {
                Cores.Erro("Digite apenas números!\n");
                continue;
            }
            break;
        }
        return int.Parse(inputNumeroConta);
    }

    public static TipoConta InputTipoConta()
    {
        string? inputTipoConta;
        while (true)
        {
            Cores.Opcao("\nEscolha o tipo de conta\n");
            Cores.Menu("\n1 - Conta Corrente");
            Cores.Menu("2 - Conta Poupança");
            Cores.Opcao("\nDigite a opção desejada: ");
            inputTipoConta = Console.ReadLine();

            if (inputTipoConta == null || !int.TryParse(inputTipoConta, out int tipo) || (tipo != 1 && tipo != 2))
            {
                Cores.Erro("\nOpção inválida! Tente novamente.");
                continue;
            }
            break;
        }
        return (TipoConta)int.Parse(inputTipoConta);
    }

    public static string InputTitular()
    {
        string? inputTitular;
        while (true)
        {
            Cores.Input("\nDigite titular da conta (max 100 digitos): ");
            inputTitular = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputTitular))
            {
                Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                continue;
            }

            if (inputTitular.Length > 100)
            {
                Cores.Erro("Titular inválido! Deve conter no máximo 100 dígitos. Tente novamente.\n");
                continue;
            }

            break;
        }
        return inputTitular;
    }

    public static float InputLimite()
    {
        string? limiteInput;
        while (true)
        {
            Cores.Input("Limite da Conta Corrente: ");
            limiteInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(limiteInput))
            {
                Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                continue;
            }
            if (!float.TryParse(limiteInput, out float limite) || limite < 0)
            {
                Cores.Erro("Valor de limite inválido! Deve ser um número maior que zero. Tente novamente.\n");
                continue;
            }
            break;
        }
        return float.Parse(limiteInput);
    }

    public static int InputAniversario()
    {
        string? aniversarioInput;
        while (true)
        {
            Cores.Input("Dia de aniversário da conta (1-31): ");
            aniversarioInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(aniversarioInput))
            {
                Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                continue;
            }
            if (!int.TryParse(aniversarioInput, out int aniversario) || aniversario < 1 || aniversario > 31)
            {
                Cores.Erro("Valor de aniversário inválido! Deve ser um número entre 1 e 31. Tente novamente.\n");
                continue;
            }
            break;
        }
        return int.Parse(aniversarioInput);
    }

    public static float InputValorSacar()
    {
        string? valorSacarInput;
        while (true)
        {
            Cores.Input("Valor a ser Sacado: ");
            valorSacarInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(valorSacarInput))
            {
                Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                continue;
            }
            if (!float.TryParse(valorSacarInput, out float valor) || valor <= 0)
            {
                Cores.Erro("Valor de saque inválido! Deve ser um número maior que zero. Tente novamente.\n");
                continue;
            }
            break;
        }
        return float.Parse(valorSacarInput);
    }

    public static float InputValorDepositar()
    {
        string? valorDepositarInput;
        while (true)
        {
            Cores.Input("Valor a ser Depositado: ");
            valorDepositarInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(valorDepositarInput))
            {
                Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                continue;
            }
            if (!float.TryParse(valorDepositarInput, out float valor) || valor <= 0)
            {
                Cores.Erro("Valor de deposito inválido! Deve ser um número maior que zero. Tente novamente.\n");
                continue;
            }
            break;
        }
        return float.Parse(valorDepositarInput);
    }

    public static int InputAgenciaOriem()
    {
        string? inputAgencia;
        while (true)
        {
            Cores.Input("\nDigite o número da agência de origem (max 4 digitos): ");
            inputAgencia = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputAgencia))
            {
                Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                continue;
            }

            if (inputAgencia.Length > 4)
            {
                Cores.Erro("Número da agência inválido! Deve conter no máximo 4 dígitos. Tente novamente.\n");
                continue;
            }

            if (!inputAgencia.All(char.IsDigit))
            {
                Cores.Erro("Digite apenas números!\n");
                continue;
            }
            break;
        }
        return int.Parse(inputAgencia);
    }

    public static int InputNumeroContaOrigem()
    {
        string? inputNumeroConta;
        while (true)
        {
            Cores.Input("\nDigite o número da conta de origem (max 6 digitos): ");
            inputNumeroConta = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputNumeroConta))
            {
                Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                continue;
            }
            if (inputNumeroConta.Length > 6)
            {
                Cores.Erro("Número da conta inválido! Deve conter no máximo 6 dígitos. Tente novamente.\n");
                continue;
            }
            if (!inputNumeroConta.All(char.IsDigit))
            {
                Cores.Erro("Digite apenas números!\n");
                continue;
            }
            break;
        }
        return int.Parse(inputNumeroConta);
    }

    public static int InputAgenciaDestino()
    {
        string? inputAgencia;
        while (true)
        {
            Cores.Input("\nDigite o número da agência de destino (max 4 digitos): ");
            inputAgencia = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputAgencia))
            {
                Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                continue;
            }

            if (inputAgencia.Length > 4)
            {
                Cores.Erro("Número da agência inválido! Deve conter no máximo 4 dígitos. Tente novamente.\n");
                continue;
            }

            if (!inputAgencia.All(char.IsDigit))
            {
                Cores.Erro("Digite apenas números!\n");
                continue;
            }
            break;
        }
        return int.Parse(inputAgencia);
    }

    public static int InputNumeroContaDestino()
    {
        string? inputNumeroConta;
        while (true)
        {
            Cores.Input("\nDigite o número da conta de destino (max 6 digitos): ");
            inputNumeroConta = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputNumeroConta))
            {
                Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                continue;
            }
            if (inputNumeroConta.Length > 6)
            {
                Cores.Erro("Número da conta inválido! Deve conter no máximo 6 dígitos. Tente novamente.\n");
                continue;
            }
            if (!inputNumeroConta.All(char.IsDigit))
            {
                Cores.Erro("Digite apenas números!\n");
                continue;
            }
            break;
        }
        return int.Parse(inputNumeroConta);
    }

    public static float InputValorTransferir()
    {
        string? valorTransferenciaInput;
        while (true)
        {
            Cores.Input("Valor a ser Transferido: ");
            valorTransferenciaInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(valorTransferenciaInput))
            {
                Cores.Erro("O campo não pode ser vazio. Tente novamente.\n");
                continue;
            }
            if (!float.TryParse(valorTransferenciaInput, out float valor) || valor <= 0)
            {
                Cores.Erro("Valor de transferência inválido! Deve ser um número maior que zero. Tente novamente.\n");
                continue;
            }
            break;
        }
        return float.Parse(valorTransferenciaInput);
    }
}
