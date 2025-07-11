using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

//Menu implementado!!!

Console.WriteLine("Bem-vindo ao sistema de reservas do hotel!\n");

Suite suite1 = new Suite("Suíte Standard", 3, 120.00m);
Suite suite2 = new Suite("Suíte Master", 5, 200.00m);

Console.WriteLine("Escolha uma das suítes disponíveis:");
Console.WriteLine("1 - Suíte Standard (Capacidade: 3 pessoas, Diária: R$ 120,00)");
Console.WriteLine("2 - Suíte Master (Capacidade: 5 pessoas, Diária: R$ 200,00)");

Suite suiteSelecionada;

while (true)
{
    Console.Write("Digite a opção (1 ou 2): ");
    string opcao = Console.ReadLine();

    if (opcao == "1")
    {
        suiteSelecionada = suite1;
        break;
    }
    else if (opcao == "2")
    {
        suiteSelecionada = suite2;
        break;
    }
    else
    {
        Console.WriteLine("Opção inválida. Tente novamente.");
    }
}

List<Pessoa> hospedes = new List<Pessoa>();

while (true)
{
    Console.Write("Digite o nome do hóspede (ou pressione ENTER para encerrar): ");
    string nome = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(nome))
        break;

    Console.Write("Digite o sobrenome do hóspede (opcional): ");
    string sobrenome = Console.ReadLine();

    Pessoa pessoa = string.IsNullOrWhiteSpace(sobrenome)
        ? new Pessoa(nome)
        : new Pessoa(nome, sobrenome);

    hospedes.Add(pessoa);
    Console.WriteLine($"Hóspede {pessoa.NomeCompleto} adicionado!");
}


Console.Write("Informe a quantidade de dias reservados: ");
int diasReservados = int.Parse(Console.ReadLine());


Reserva reserva = new Reserva(diasReservados);
reserva.CadastrarSuite(suiteSelecionada);
reserva.CadastrarHospedes(hospedes);


Console.WriteLine("Resumo da reserva:");
Console.WriteLine($"Suíte escolhida: {suiteSelecionada.TipoSuite}");
Console.WriteLine($"Capacidade da suíte: {suiteSelecionada.Capacidade}");
Console.WriteLine($"Valor da diária: R$ {suiteSelecionada.ValorDiaria}");
Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor total da estadia: R$ {reserva.CalcularValorDiaria()}");
