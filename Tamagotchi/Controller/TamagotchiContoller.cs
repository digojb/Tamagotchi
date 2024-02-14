using AutoMapper;
using Tamagotchi.Model;
using Tamagotchi.Service;
using Tamagotchi.TamagotchiCli.View.AscArt;
using Tamagotchi.View;

namespace Tamagotchi.Controller
{
    public class TamagotchiContoller
    {
        private TamagotchiView tamagotchiView { get; set; }
        private PokemonApiService pokemonApiService { get; set; }
        private List<PokemonResult> especiesDisponiveis { get; set; }
        private List<TamagotchiDto> mascotesAdotados { get; set; }
        private string _userName = String.Empty;

        IMapper mapper { get; set; }

        public TamagotchiContoller()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            mapper = config.CreateMapper();

            tamagotchiView = new TamagotchiView();
            pokemonApiService = new PokemonApiService();
            especiesDisponiveis = pokemonApiService.ObterEspeciesDisponiveis();
            mascotesAdotados = new List<TamagotchiDto>();
        }

        public void Jogar()
        {

            tamagotchiView.Presentation();
            tamagotchiView.Login();
            var input = Console.ReadLine();
            Console.WriteLine(" ");
            _userName = input;

            while (true)
            {
                tamagotchiView.MostrarMenuPrincipal(_userName!);
                int escolha = tamagotchiView.ObterEscolhaDoJogador(4);

                switch (escolha)
                {
                    case 1:
                        while (true)
                        {
                            tamagotchiView.MostrarMenuDeAdocao();
                            escolha = tamagotchiView.ObterEscolhaDoJogador(4);
                            switch (escolha)
                            {
                                case 1:
                                    tamagotchiView.MostrarEspeciesDisponiveis(especiesDisponiveis);
                                    break;
                                case 2:
                                    tamagotchiView.MostrarEspeciesDisponiveis(especiesDisponiveis);
                                    int indiceEspecie = tamagotchiView.ObterEspecieEscolhida(especiesDisponiveis);
                                    PokemonDetailsResult detalhes = pokemonApiService.ObterDetalhesDaEspecie(especiesDisponiveis[indiceEspecie]);
                                    tamagotchiView.MostrarDetalhesDaEspecie(detalhes);
                                    break;
                                case 3:
                                    tamagotchiView.MostrarEspeciesDisponiveis(especiesDisponiveis);
                                    indiceEspecie = tamagotchiView.ObterEspecieEscolhida(especiesDisponiveis);
                                    detalhes = pokemonApiService.ObterDetalhesDaEspecie(especiesDisponiveis[indiceEspecie]);
                                    tamagotchiView.MostrarDetalhesDaEspecie(detalhes);
                                    if (tamagotchiView.ConfirmarAdocao())
                                    {
                                        TamagotchiDto tamagotchi = mapper.Map<TamagotchiDto>(detalhes);
                                        mascotesAdotados.Add(tamagotchi);
                                        Eggs.CrakingEgg();
                                    }
                                    break;
                                case 4:
                                    break;
                            }
                            if (escolha == 4)
                            {
                                break;
                            }
                        }
                        break;
                    case 2:
                        if (mascotesAdotados.Count == 0)
                        {
                            string TittleNaoTem = @"       Você não tem nenhum mascote adotado.";
                            TextAnimationUtils.AnimatingTyping(TittleNaoTem, 15);
                            Console.WriteLine(" ");
                            Console.WriteLine(" ");
                            break;
                        }

                        TextAnimationUtils.AnimatingTyping("        Escolha um mascote para interagir:", 15);
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        for (int i = 0; i < mascotesAdotados.Count; i++)
                        {
                            Console.WriteLine($"        {i + 1}. {mascotesAdotados[i].Nome}");
                        }

                        int indiceMascote = tamagotchiView.ObterEscolhaDoJogador(mascotesAdotados.Count) - 1;
                        TamagotchiDto mascoteEscolhido = mascotesAdotados[indiceMascote];

                        mascoteEscolhido.MostrarStatus();

                        int opcaoInteracao = 0;
                        while (opcaoInteracao != 5)
                        {
                            tamagotchiView.MostrarMenuInteracao();
                            opcaoInteracao = tamagotchiView.ObterEscolhaDoJogador(5);

                            switch (opcaoInteracao)
                            {
                                case 1:
                                    mascoteEscolhido.Alimentar();
                                    mascoteEscolhido.MostrarStatus();
                                    break;
                                case 2:
                                    mascoteEscolhido.Brincar();
                                    mascoteEscolhido.MostrarStatus();
                                    break;
                                case 3:
                                    mascoteEscolhido.Descansar();
                                    mascoteEscolhido.MostrarStatus();
                                    break;
                                case 4:
                                    mascoteEscolhido.DarCarinho();
                                    mascoteEscolhido.MostrarStatus();
                                    break;
                            }
                        }
                        break;
                    case 3:
                        tamagotchiView.MostrarMascotesAdotados(mascotesAdotados);
                        break;
                    case 4:
                        string TittleFim = "        Obrigado por jogar! Até a próxima! ";
                        TextAnimationUtils.AnimatingTyping(TittleFim, 15);
                        return;
                }
            }
        }
    }
}