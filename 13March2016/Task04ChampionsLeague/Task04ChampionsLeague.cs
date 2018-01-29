using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Team
{

    public string Name { get; set; }

    public List<string> Oponents { get; set; }

    public int Wins { get; set; }

    public Team(string name)
    {
        this.Name = name;
        this.Oponents = new List<string>();
        this.Wins = 0;
    }
}

class Task04ChampionsLeague
{
    static void Main(string[] args)
    {

        var inputLine = Console.ReadLine()
           .Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries)
           .ToArray();

        var data = new Dictionary<string,Team>();

        while (inputLine[0] != "stop")
        {
            var firstTeam = inputLine[0];

            var secondTeam = inputLine[1];

            var firstResult = inputLine[2].Split(':').Select(int.Parse).ToArray();

            var secondResult = inputLine[3].Split(':').Select(int.Parse).ToArray();

            CreatIfNotExist(firstTeam, data);

            CreatIfNotExist(secondTeam, data);


            if (firstTeamWin(firstResult, secondResult) == 1)
            {
                data[firstTeam].Wins += 1;
            }
            else if (firstTeamWin(firstResult, secondResult) == -1)
            {
                data[secondTeam].Wins += 1;
            }
            else
            {
                string drawWinner = whoIsTheDrawWinner(firstResult, secondResult,firstTeam,secondTeam);

                if (drawWinner == firstTeam)
                {
                    data[firstTeam].Wins+=1;
                }
                else
                {
                    data[secondTeam].Wins += 1;
                }
            }
            data[firstTeam].Oponents.Add(secondTeam);
            data[secondTeam].Oponents.Add(firstTeam);

            inputLine = Console.ReadLine()
           .Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries)
           .ToArray();
        }

        foreach (var team in data.OrderByDescending(n=>n.Value.Wins).ThenBy(n=>n.Key))
        {
            Console.WriteLine(team.Key);
            Console.WriteLine($"- Wins: {team.Value.Wins}");
            Console.WriteLine($"- Opponents: {string.Join(", ",team.Value.Oponents.OrderBy(n=>n))}");
        }

      
    }

    private static void CreatIfNotExist(string team, Dictionary<string, Team> data)
    {
        if (!data.ContainsKey(team))
        {
            data[team] = new Team(team);
        }    }

    private static string whoIsTheDrawWinner(int[] firstResult, int[] secondResult,string firstTeam,string secondTeam)
    {
      int  firstTeamGoals = firstResult[0] +  secondResult[1];

        int secondTeamGoals =  firstResult[1] + secondResult[0];

        string firstOrSecond = string.Empty;

        if (firstTeamGoals==secondTeamGoals)
        {
            firstOrSecond = (firstResult[1] > secondResult[0]) ? secondTeam : firstTeam;
        }

        return firstTeamGoals>secondTeamGoals?firstTeam:(firstTeamGoals<secondTeamGoals)?secondTeam:firstOrSecond;
    }

    private static int firstTeamWin(int[] firstResult, int[] secondResult)
    {
        bool firstWin = (firstResult[0] > firstResult[1] && secondResult[0] < secondResult[1])
            || (firstResult[0] > firstResult[1] && secondResult[0] == secondResult[1])
            || (firstResult[0] == firstResult[1] && secondResult[0] < secondResult[1]);
        bool secondWin =
         (firstResult[0] < firstResult[1] && secondResult[0] > secondResult[1])
            || (firstResult[0] < firstResult[1] && secondResult[0] == secondResult[1])
            || (firstResult[0] == firstResult[1] && secondResult[0] > secondResult[1]);

        return firstWin ? 1 : secondWin ? (-1) : 0;
    }
}

