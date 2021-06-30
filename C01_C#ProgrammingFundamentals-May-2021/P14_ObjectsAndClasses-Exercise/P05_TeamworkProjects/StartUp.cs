namespace P05_TeamworkProjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using P05_TeamworkProjects.Models;

    public class StartUp
    {
        const string TEAM_CREATED_MESSAGE = "Team {0} has been created by {1}!";
        const string COMMAND_TO_STOP = "end of assignment";
        const string TEAM_ALREADY_CREATED_ERROR_MESSAGE = "Team {0} was already created!";
        const string CANNOT_CREATE_ANOTHER_TEAM_ERROR_MESSAGE = "{0} cannot create another team!";
        const string NOT_EXISTENT_TEAM_ERROR_MESSAGE = "Team {0} does not exist!";
        const string CANNOT_JOIN_A_TEAM_ERROR_MESSAGE = "Member {0} cannot join team {1}!";

        public static void Main()
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> allTeams = new List<Team>();


            for (int i = 0; i < teamsCount; i++)
            {
                string[] teamArguments = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);

                CreateNewTeam(allTeams, teamArguments);
            }

            while (true)
            {
                string[] joinATeamArguments = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommand = joinATeamArguments[0] == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    break;
                }

                JoinATeam(allTeams, joinATeamArguments);
            }

            PrintResult(allTeams);
        }

        private static void CreateNewTeam(List<Team> allTeams, string[] teamArguments)
        {
            string teamLeaderName = teamArguments[0];
            string teamName = teamArguments[1];
            bool checkIfTeamAlreadyExist = CheckIfTeamAlreadyExist(allTeams, teamName);
            bool checkIfUserAlreadyCreateATeam = CheckIfUserAlreadyCreateATeam(allTeams, teamLeaderName);

            bool canCreateATeam = checkIfTeamAlreadyExist == false && checkIfUserAlreadyCreateATeam == false;
            if (canCreateATeam)
            {
                Team team = new Team(teamName, teamLeaderName);
                allTeams.Add(team);

                string message = string.Format(TEAM_CREATED_MESSAGE, teamName, teamLeaderName);
                Console.WriteLine(message);
            }
        }

        private static bool CheckIfTeamAlreadyExist(List<Team> allTeams, string teamName)
        {
            bool checkIfTeamAlreadyExist = allTeams
                            .Select(x => x.TeamName)
                            .Contains(teamName);

            if (checkIfTeamAlreadyExist)
            {
                string message = string.Format(TEAM_ALREADY_CREATED_ERROR_MESSAGE, teamName);
                Console.WriteLine(message);
            }

            return checkIfTeamAlreadyExist;
        }

        private static bool CheckIfUserAlreadyCreateATeam(List<Team> allTeams, string teamLeaderName)
        {
            bool checkIfAlreadyCreateATeam = allTeams
                .Select(x => x.TeamLeaderName)
                .Contains(teamLeaderName);

            if (checkIfAlreadyCreateATeam)
            {
                string message = string.Format(CANNOT_CREATE_ANOTHER_TEAM_ERROR_MESSAGE, teamLeaderName);
                Console.WriteLine(message);
            }

            return checkIfAlreadyCreateATeam;
        }

        private static void JoinATeam(List<Team> allTeams, string[] joinATeamArguments)
        {
            string personName = joinATeamArguments[0];
            string theNameOfTheTeamToJoin = joinATeamArguments[1];

            bool isThereSuchATeam = IsThereSuchATeam(allTeams, theNameOfTheTeamToJoin);

            bool isThePersonAlreadyInThisTeam = false;
            if (isThereSuchATeam)
            {
                isThePersonAlreadyInThisTeam = IsThePersonAlreadyInTheTeam(allTeams, personName, theNameOfTheTeamToJoin);
            }

            bool canPersonJoinATeam = isThereSuchATeam == true && isThePersonAlreadyInThisTeam == false;
            if (canPersonJoinATeam)
            {
                allTeams = allTeams
                    .Where(x => x.TeamName == theNameOfTheTeamToJoin)
                    .ToList();

                foreach (var team in allTeams)
                {
                    team.Members.Add(personName);
                }
            }
        }

        private static bool IsThereSuchATeam(List<Team> allTeams, string theNameOfTheTeamToJoin)
        {
            bool isExist = allTeams
                .Select(x => x.TeamName)
                .Contains(theNameOfTheTeamToJoin);

            if (!isExist)
            {
                string message = string.Format(NOT_EXISTENT_TEAM_ERROR_MESSAGE, theNameOfTheTeamToJoin);
                Console.WriteLine(message);
            }

            return isExist;
        }

        private static bool IsThePersonAlreadyInTheTeam(List<Team> allTeams, string personName, string theNameOfTheTeamToJoin)
        {
            bool isLeader = allTeams
                .Select(x => x.TeamLeaderName)
                .Contains(personName);

            bool isMember = allTeams
                .Select(x => x.Members)
                .Any(x => x.Contains(personName));

            bool isAlreadyInTheTeam = isLeader == true || isMember == true;

            if (isAlreadyInTheTeam)
            {
                string message = string.Format(CANNOT_JOIN_A_TEAM_ERROR_MESSAGE, personName, theNameOfTheTeamToJoin);
                Console.WriteLine(message);
            }

            return isAlreadyInTheTeam;
        }

        private static void PrintResult(List<Team> allTeams)
        {
            var orderTeams = allTeams
                 .OrderByDescending(x => x.Members.Count)
                 .ThenBy(x => x.TeamName)
                 .Where(x => x.Members.Count > 0)
                 .ToList();

            foreach (var team in orderTeams)
            {
                Console.Write(team);
            }

            Console.WriteLine("Teams to disband:");

            var teamsToDisband = allTeams
                .Where(x => x.Members.Count == 0)
                .OrderBy(x => x.TeamName)
                .ToList();

            foreach (var team in teamsToDisband)
            {
                Console.WriteLine(team.TeamName.ToString());
            }
        }
    }
}
