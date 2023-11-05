using System.Globalization;
using System.Text;
using Objetos;

List<Apostador> apostasRecebidas = new List<Apostador>();
bool condicao = true;

while (condicao)
{
    Console.WriteLine("Vai fazer uma aposta ? se SIM responda 's' e aperte ENTER para confirmar");
    Console.WriteLine("caso contrário responda 'n' e confirme");
    string resposta = Console.ReadLine()!;
    if (resposta.ToLower().Equals("s"))
    {
        Apostador apostador = new Apostador();
        Loteria loteria = new Loteria();
        apostador = loteria.receberAposta(apostador, 5.00);
        apostasRecebidas.Add(apostador);
    }
    else if (resposta.ToLower().Equals("n"))
    {
        condicao = false;
    }
    else
    {
        continue;
    }
}
Console.WriteLine();

StringBuilder builder = new StringBuilder();

foreach (var item in apostasRecebidas)
{
    builder.AppendLine();
    builder.AppendLine("Nome: " + item.nome);
    builder.AppendLine("Quantidade de Bilhetes: " + item.quantidadeApostas);
    builder.AppendLine(
        "Valor total da aposta: "
            + item.totalPago.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))
    );
    builder.AppendLine("Bilhetes:");
    builder.AppendLine();
    foreach (var bilhete in item.bilhetesDeApostas())
    {
        builder.AppendLine(bilhete);
    }
    builder.AppendLine();
    builder.AppendLine("-------------------------------------");
}

Console.WriteLine();

if (apostasRecebidas.Count() > 0)
{
    File.WriteAllText("Apostas.txt", builder.ToString());

    StringBuilder sorteio = new StringBuilder();

    sorteio.AppendLine(
        "Resultado do sorteio do dia "
            + DateTime.Now.ToString("dd/MM/yyyy")
            + " às "
            + DateTime.Now.ToString("HH:mm")
    );
    sorteio.AppendLine();
    sorteio.AppendLine(Loteria.sortearNumeros());
    File.WriteAllText("Resultado-Do-Sorteio.txt", sorteio.ToString());
}
