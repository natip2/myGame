using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Program
    {
        private const int NUM_PLAYER = 2;
        static Dictionary<string, Type> _uioptions;
        static IPlayer[] players;
        static GameFactory f;
        static void Main(string[] args)
        {
            gameDemo(); 
        }
        
        static void gameDemo()
        {
            init_uioptions();
            Console.WriteLine("1-random   2-scanner    3-human   4-scanner and random");
            players = new IPlayer[NUM_PLAYER];
            GameFactory factory = new GameFactory();
            for (int i = 0; i < NUM_PLAYER;)
            {
                players[i] = GetPlayer(factory,i);
                if (players[i] != null)
                {
                    players[i] = decoratorSuggestion(factory, players[i]);
                    i++;

                }
            }

            Game game = new Game(new TicTacToe(), players);
            game.RunGame();
            

            
        }

        static private IPlayer decoratorSuggestion(GameFactory factory, IPlayer player)
        {
            Type classType;
            do
            {
                Console.WriteLine("5-row decorator    6-col decorator   7-none");//todo is not safe
                string playerType = Console.ReadLine();
                if (_uioptions.ContainsKey(playerType))
                {
                    classType = _uioptions[playerType];
                }
                else
                {
                    classType = null;
                }
                
                if (classType != null)
                {
                    player = factory.CreateDecorator(classType, player);
                }
            } while (classType != null);
            return player;
        }

        static void init_uioptions()
        {
            _uioptions = new Dictionary<string, Type>();
            _uioptions.Add("1", typeof(IRandom));
            _uioptions.Add("2", typeof(IScanner));
            _uioptions.Add("3", typeof(IHuman));
            _uioptions.Add("4", typeof(IScanerAndRandomPlayer));
            _uioptions.Add("5", typeof(IRowBlokerDecorator));
            _uioptions.Add("6", typeof(IColBlokerDecorator));
        }

        static IPlayer GetPlayer(GameFactory factory,int id)
        {
            IPlayer retVal = null;

            Console.WriteLine("Enter Player Type");
            string playerType = Console.ReadLine();
            Type classType = _uioptions[playerType];
            retVal = factory.CreatePlayer(classType, id);
            return retVal; 
            
            
        }


        

        
    }
}
