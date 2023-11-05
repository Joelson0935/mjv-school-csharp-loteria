using System.Collections.Specialized;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace Objetos
{
    class Apostador
    {
        public string? nome;
        public int quantidadeApostas;
        public double totalPago;
        List<string> bilheteria = new List<string>();

        public Apostador() { }

        public Apostador(string nome, int quantidadeApostas)
        {
            this.nome = nome;
            this.quantidadeApostas = quantidadeApostas;
        }

        public List<string> bilhetesDeApostas()
        {
            string bilhete = "";

            for (int i = 0; i < quantidadeApostas; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    int numero = new Random().Next(1, 60);
                    bilhete += numero + " ";
                }
                bilheteria.Add(bilhete);
                bilhete = "";
            }
            return bilheteria;
        }
    }

    class Loteria
    {
        public Loteria() { }

        private string verificaString(string param)
        {
            string padrao = "^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$";
            Regex regex = new Regex(padrao);
            return regex.IsMatch(param) ? param : throw new ArgumentException("Nome Inválido!");
        }

        public Apostador receberAposta(Apostador apostador, double valorAposta)
        {
            try
            {
                Console.WriteLine(
                    "Olá, por favor insira seu nome e confirme apertando o botão ENTER."
                );
                apostador.nome = Console.ReadLine()!;
                verificaString(apostador.nome);
                Console.WriteLine(
                    $"Então {apostador.nome}, cada bilhete custa R$ {valorAposta} Reais, possui 6 números e equivale a uma aposta, dito isso, escolha quantos bilhetes deseja comprar."
                );
                apostador.quantidadeApostas = Convert.ToInt32(Console.ReadLine());
                apostador.totalPago = valorAposta * apostador.quantidadeApostas;
            }
            catch (FormatException)
            {
                throw new FormatException(
                    "Por favor insira a quantidade de bilhetes corretamente."
                );
            }
            return apostador;
        }

        public static string sortearNumeros()
        {
            int[] sorteio = new int[6];
            string resultado = "";

            for (int i = 0; i < 6; i++)
            {
                sorteio[i] = new Random().Next(1, 60);
                resultado += sorteio[i] + " ";
            }
            return resultado;
        }
    }
}
