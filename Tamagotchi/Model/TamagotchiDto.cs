
using Tamagotchi.View;

namespace Tamagotchi.Model
{
    public class TamagotchiDto
    {
        public int Alimentacao { get; private set; }
        public int Humor { get; private set; }
        public int Energia { get; private set; }
        public int Saude { get; private set; }
        public int Altura { get; set; }
        public int Peso { get; set; }
        public string Nome { get; set; }
        public List<Habilidade> Habilidades { get; set; }

        public TamagotchiDto()
        {
            var rand = new Random();
            Alimentacao = rand.Next(11);
            Humor = rand.Next(11);
            Energia = rand.Next(11);
            Saude = rand.Next(11);
        }
        //Agora utilizamos AutoMapper
        //public void AtualizarPropriedades(PokemonDetailsResult pokemonDetails)
        //{
        //    Nome = pokemonDetails.Name;
        //    Altura = pokemonDetails.Height;
        //    Peso = pokemonDetails.Weight;
        //    Habilidades = pokemonDetails.Abilities.Select(a => new Habilidade { Nome = a.Ability.Name }).ToList();
        //}
        public void Alimentar()
        {
            Alimentacao = Math.Min(Alimentacao + 2, 10);
            Energia = Math.Max(Energia - 1, 0);

            Console.WriteLine(" ");
            Console.WriteLine("        Mascote Alimentado!");
            Console.WriteLine(" ");
        }
        public void Brincar()
        {
            Humor = Math.Min(Humor + 3, 10);
            Energia = Math.Max(Energia - 2, 0);
            Alimentacao = Math.Max(Alimentacao - 1, 0);

            Console.WriteLine(" ");
            Console.WriteLine("        Mascote Feliz!");
            Console.WriteLine(" ");
        }
        public void Descansar()
        {
            Energia = Math.Min(Energia + 4, 10);
            Humor = Math.Max(Humor - 1, 0);

            Console.WriteLine(" ");
            Console.WriteLine("        Mascote a Mimir!");
            Console.WriteLine(" ");
        }
        public void DarCarinho()
        {
            Humor = Math.Min(Humor + 2, 10);
            Saude = Math.Min(Saude + 1, 10);

            Console.WriteLine(" ");
            Console.WriteLine("        Mascote Amado!");
            Console.WriteLine(" ");
        }
        public void MostrarStatus()
        {
            //Console.WriteLine("\nStatus do Mascote:\n");
            System.Console.WriteLine("    ----------------- STATUS ---------------");
            Console.WriteLine(" ");
            Console.WriteLine($"Alimentação:\t{TamagotchiView.ProgressBar(Alimentacao)}\t {RetornarFome()}");
            Console.WriteLine($"Humor:\t\t{TamagotchiView.ProgressBar(Humor)}\t {RetornarHumor()}");
            Console.WriteLine($"Energia:\t{TamagotchiView.ProgressBar(Energia)}\t {RetornarSono()}");
            Console.WriteLine($"Saúde:\t\t{TamagotchiView.ProgressBar(Saude)}\t {RetornarSaude()}");
        }
        public string RetornarFome()
        {
            if (Alimentacao <= 5)
            {
                return "Muita fome!";
            }
            else if (Alimentacao >= 6 && Alimentacao <= 8)
            {
                return "Está com fome!";
            }
            return "Não está com fome!";
        }
        public string RetornarSono()
        {
            if (Energia <= 5)
            {
                return "Muito sono!";
            }
            else if (Energia >= 6 && Energia <= 8)
            {
                return "Está com sono!";
            }
            return "Não está com sono!";
        }
        public string RetornarHumor()
        {
            if (Humor <= 5)
            {
                return "Muito bravo!";
            }
            else if (Humor >= 6 && Humor <= 8)
            {
                return "Está bravo!";
            }
            return "Não está bravo!";
        }
        public string RetornarSaude()
        {
            if (Saude <= 5)
            {
                return "Muito doente!";
            }
            else if (Saude >= 6 && Saude <= 8)
            {
                return "Está doente!";
            }
            return "Não está doente!";
        }
    }
    public class Habilidade
    {
        public string Nome { get; set; }
    }
}