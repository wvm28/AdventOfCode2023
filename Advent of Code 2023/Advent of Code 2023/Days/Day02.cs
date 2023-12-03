namespace Advent_of_Code_2023.Days
{
    public class Day02 : IDay
    {
        private List<Game> _games = new List<Game>();

        public Day02() 
        {
            var input = File.ReadAllLines(@"Days\Input\Day02.txt").ToList();

            foreach( var gameInput in input)
            {
                var game = new Game();
                var charLocation = gameInput.IndexOf(":");
                var gameName = gameInput.Substring(0, charLocation);
                var gameId = gameName[(gameName.LastIndexOf(' ') + 1)..];

                game.Id = int.Parse(gameId);

                var gameTurnsInput = gameInput[(gameInput.LastIndexOf(':') + 2)..];
                var gameTurns = gameTurnsInput.Split("; ").ToList();
                foreach ( var turnInput in gameTurns)
                {
                    var turnCollors = turnInput.Split(", ");
                    var turn = new Turn();
                    foreach( var turnCollor in turnCollors)
                    {
                        var collorParts = turnCollor.Split(" ");
                        switch(collorParts[1]) 
                        {
                            case "red":
                                turn.red = int.Parse(collorParts[0]);
                                break;
                            case "green":
                                turn.green = int.Parse(collorParts[0]);
                                break;
                            case "blue":
                                turn.blue = int.Parse(collorParts[0]);
                                break;
                        }
                    }
                    game.Turns.Add(turn);
                }
                _games.Add(game);
            }
        }

        public void partOne()
        {
            var maxRed = 12;
            var maxGreen = 13;
            var maxBlue = 14;

            var possibleGames = new List<Game>();
            var sumIds = 0;

            foreach( var game in _games)
            {
                var possible = true;

                foreach (var turn in game.Turns)
                {
                    if (possible)
                    {
                        if (turn.red > maxRed || turn.green > maxGreen || turn.blue > maxBlue)
                        {
                            possible = false;
                        }
                    }
                }

                if (possible)
                {
                    possibleGames.Add(game);
                    sumIds+=game.Id;
                }
            }
            Console.WriteLine($"This combination is possible in {possibleGames.Count} games. With a total sum of all Ids being: {sumIds}");
        }

        public void partTwo()
        {
            var sumPower = 0;
            foreach (var game in _games)
            {
                var red = 0;
                var green = 0;
                var blue = 0;

                foreach (var turn in game.Turns)
                {
                    if (turn.red > red) { red = turn.red; }
                    if (turn.green > green) {  green = turn.green; }
                    if (turn.blue > blue) {  blue = turn.blue; }
                }
                var sum = red * green * blue;
                sumPower += sum;
            }

            Console.WriteLine(sumPower);
        }
        
    }

    internal class Game
    {
        public int Id;
        public List<Turn> Turns = new List<Turn>();
    }

    internal class Turn
    {
        public int red;
        public int green;
        public int blue;
    }
}
