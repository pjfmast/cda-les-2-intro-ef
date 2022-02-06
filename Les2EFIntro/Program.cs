// See https://aka.ms/new-console-template for more information
using Les2EFIntro.Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Team management");

using TeamManagmentDBContext teamsManagementContext = new TeamManagmentDBContext();

var team1 = teamsManagementContext.Teams
    .Include(team => team.Enrolled)
    .FirstOrDefault(team => team.Group == "Groep-1");

Console.WriteLine($"Team {team1.Title} has the following members:");
foreach (var member in team1.Enrolled) {
    Console.WriteLine($"\t{member.Name}");
}