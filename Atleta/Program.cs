using System.Globalization;

namespace Atleta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Qual a quantidade de atletas? ");
            int athleteQuantity = int.Parse(Console.ReadLine());

            int menQuantity = 0;
            int womenQuantity = 0;
            double menPercent = 0.0;
            double sumWomenHeight = 0.0;
            double womenAverageHight = 0.0;
            double sumWeight = 0.0;
            double weightAverage = 0.0;
            string nameHighestAthlete = "";
            double highestAthlete = 0.0;

            for (int i = 1; i <= athleteQuantity; i++)
            {
                Console.WriteLine($"Digite dados do atleta número {i}");

                // Nome
                Console.Write("Nome: ");
                string name = Console.ReadLine();

                // Sexo
                Console.Write("Sexo: ");
                char gender = char.Parse(Console.ReadLine().ToUpper());

                while (gender != 'M' && gender != 'F')
                {
                    Console.Write("Sexo inválido! Digite o sexo novamente: ");
                    gender = char.Parse(Console.ReadLine().ToUpper());
                }

                

                // Altura
                Console.Write("Altura: ");
                double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                while (height <= 0.0)
                {
                    Console.Write("Valor inválido! Favor digitar um valor positivo: ");
                    height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                }

                if (gender == 'M')
                {
                    menQuantity++;
                }
                else
                {
                    womenQuantity++;
                    sumWomenHeight += height;
                }

                // Atleta mais alto
                if (height > highestAthlete)
                {
                    nameHighestAthlete = name;
                    highestAthlete = height;
                }

                // Peso
                Console.Write("Peso: ");
                double weight = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                while (weight <= 0.0)
                {
                    Console.Write("Valor inválido! Favor digitar um valor positivo: ");
                    weight = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                }

                sumWeight += weight;
            }

            weightAverage = sumWeight / (menQuantity + womenQuantity);

            menPercent = menQuantity * 100.0 / (menQuantity + womenQuantity);

            Console.WriteLine();
            Console.WriteLine("RELATÓRIO");
            Console.WriteLine($"Peso médio dos atletas: {weightAverage.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Atleta mais alto: {nameHighestAthlete}");
            Console.WriteLine($"Porcentagem de homens: {menPercent.ToString("F1", CultureInfo.InvariantCulture)} %");
            if (womenQuantity > 0)
            {
                womenAverageHight = sumWomenHeight / womenQuantity;
                Console.WriteLine($"Altura média das mulheres: {womenAverageHight.ToString("F2", CultureInfo.InvariantCulture)}");
            }
            else
            {
                Console.WriteLine("Não há mulheres cadastradas");
            }

        }
    }
}
