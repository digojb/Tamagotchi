using Tamagotchi.Model;
using System.Text;
using Tamagotchie.TamagotchiCli.View.AscArt;

namespace Tamagotchi.View
{
    public class TamagotchiView
    {
        public void Presentation()
        {
            System.Console.Clear();

            TextAnimationUtils.Blink(MainLogo.logo, 3, 500, 250);

            System.Console.WriteLine(" ");
            System.Console.WriteLine(" ");
        }

        public void Login()
        {
            System.Console.WriteLine("    ---------------- START ---------------");
            System.Console.WriteLine(" ");

            TextAnimationUtils.AnimatingTyping("        Qual é o seu nome?");

            System.Console.WriteLine(" ");
        }
        public void MostrarMenuPrincipal(string userName)
        {
            userName = userName.ToUpper();

            string textTittle = $"        Olá {userName}, você deseja: ";
            string textOptions = @"
        1. Adotar um Mascote
        2. Interagir com seu Mascote
        3. Ver Mascotes Adotados
        4. Sair do Jogo
        ";

            System.Console.WriteLine("    ---------------- MENU ---------------");
            System.Console.WriteLine(" ");

            TextAnimationUtils.AnimatingTyping(textTittle, 25);

            System.Console.WriteLine(" ");

            TextAnimationUtils.AnimatingTyping(textOptions, 15);

            System.Console.WriteLine(" ");
        }

        public void MostrarMenuInteracao()
        {
            string textIntera = @"
        1. Alimentar o mascote
        2. Brincar com o mascote
        3. Colocar mascote para dormir
        4. Fazer carinho no mascote
        5. Voltar
        ";

            TextAnimationUtils.AnimatingTyping(textIntera, 15);
            Console.WriteLine(" ");

            // string TittleEsco = @"
            // Escolha uma opção:
            //";
            // TextAnimationUtils.AnimatingTyping(TittleEsco, 15);
        }

        public int ObterEscolhaDoJogador(int maxOpcao)
        {
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > maxOpcao)
            {
                string TittleObter = $"        Escolha inválida. Por favor, escolha uma opção entre 1 e {maxOpcao}: ";

                TextAnimationUtils.AnimatingTyping(TittleObter, 15);
            }
            return escolha;
        }

        public void MostrarMenuDeAdocao()
        {
            Console.WriteLine(" ");
            System.Console.WriteLine("    ---------------- MENU ---------------");
            string TittleAdo = @"
        1. Ver Espécies Disponíveis
        2. Ver Detalhes de uma Espécie
        3. Adotar um Mascote
        4. Voltar ao Menu Principal
        ";

            TextAnimationUtils.AnimatingTyping(TittleAdo, 15);

            // string TittleEsco = @"
            // Escolha uma opção:
            // ";
            // TextAnimationUtils.AnimatingTyping(TittleEsco, 15);

            System.Console.WriteLine(" ");
        }

        public void MostrarEspeciesDisponiveis(List<PokemonResult> especies)
        {
            Console.WriteLine(" ");
            System.Console.WriteLine("    ---------------- MENU ---------------");
            string TittleEspDis = @"
        Espécies Disponíveis para Adoção:
        ";
            TextAnimationUtils.AnimatingTyping(TittleEspDis, 15);

            for (int i = 0; i < 6; i++)
            {
                string TittleNome = @$"
            {i + 1}.  {especies[i].Name}";

                TextAnimationUtils.AnimatingTyping(TittleNome, 1);
                //Console.WriteLine(i + 1 + ". " + especies[i].Name);
            }
            Console.WriteLine(" ");
            //Console.WriteLine(" ");
        }
        public void MostrarDetalhesDaEspecie(PokemonDetailsResult detalhes)
        {
            Console.WriteLine(" ");
            System.Console.WriteLine("    --------------- DETALHES --------------");
            string TittleDetail = @$"
        Nome: {detalhes.Name.ToUpper()}
        Altura: {detalhes.Height}
        Peso: {detalhes.Weight}
        Habilidades:";
            TextAnimationUtils.AnimatingTyping(TittleDetail, 15);

            foreach (var habilidade in detalhes.Abilities)
            {
                string TittleHabi = @$" 
            -{habilidade.Ability.Name}";
                TextAnimationUtils.AnimatingTyping(TittleHabi, 15);
                //Console.WriteLine(", ");
            }
            Console.WriteLine(" ");
        }
        public bool ConfirmarAdocao()
        {
            Console.WriteLine(" ");
            System.Console.WriteLine("    ---------------- MENU ---------------");
            string TittleConfirm = @"
        Você gostaria de adotar este mascote? (s/n): 
        ";
            TextAnimationUtils.AnimatingTyping(TittleConfirm, 15);
            string resposta = Console.ReadLine();
            return resposta.ToLower() == "s";
        }

        public void MostrarMascotesAdotados(List<TamagotchiDto> mascotesAdotados)
        {

            //string TittleMostrar = @"
        //Mascotes Adotados: 
        //";
            //TextAnimationUtils.AnimatingTyping(TittleMostrar, 15);
            Console.WriteLine(" ");
            System.Console.WriteLine("    -------------- MASCOTES -------------");
            Console.WriteLine(" ");

            if (mascotesAdotados.Count == 0)
            {
                string TittleVazio = "        Você não adotou nenhum mascote.";
                TextAnimationUtils.AnimatingTyping(TittleVazio, 15);
                Console.WriteLine(" ");
            }
            else
            {
                for (int i = 0; i < mascotesAdotados.Count; i++)
                {
                    //Console.WriteLine(i + 1 + ". " + mascotesAdotados[i].Nome.ToUpper() + "\tSaúde: " + TamagotchiView.ProgressBar(mascotesAdotados[i].Saude));
                    Console.WriteLine($"        {i+1}. {mascotesAdotados[i].Nome.ToUpper()}    Saúde: {ProgressBar(mascotesAdotados[i].Saude)}");
                }
            }
            Console.WriteLine(" ");
        }
        public int ObterEspecieEscolhida(List<PokemonResult> especies)
        {
            Console.WriteLine(" ");
            System.Console.WriteLine("    ---------------- MENU ---------------");
            System.Console.WriteLine(" ");
            int escolha;

            while (true)
            {
                string TittleObter = @$"        Escolha uma espécie pelo número (1 - {6}): ";
                TextAnimationUtils.AnimatingTyping(TittleObter, 15);
                Console.WriteLine(" ");

                if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= 6)
                {
                    break;
                }

                string TittleInv = @"
            Escolha inválida.
            ";
                TextAnimationUtils.AnimatingTyping(TittleInv, 15);
            }
            return escolha - 1;
            // Ajuste para índice baseado em 0
        }

        internal static string ProgressBar(int value, int total = 10)
        {
            if (value > total)
                value = total;
            var sb = new StringBuilder(32);
            sb.Append('|');
            Enumerable.Range(0, value).ToList().ForEach(i => sb.Append('='));
            Enumerable.Range(0, total - value).ToList().ForEach(i => sb.Append('-'));
            sb.Append('|');

            return sb.ToString();
        }
    }
}