// See https://aka.ms/new-console-template for more information
using Les2EFIntro.Data;
using Les2EFIntro.Models;
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

#region demo creating and adding new entities:
teamsManagementContext.Members.Add(new Member { Name = "Jeroen", Email = "jeroen@breda.nl" });

var memberList = new List<Member> {
    new Member { Name="Henk", Email = "Henk@breda.nl"},
    new Member { Name="Loes", Email = "Loes@avans.nl"},
};

teamsManagementContext.Members.AddRange(memberList);
teamsManagementContext.SaveChanges();

var selectedStudents = teamsManagementContext
    .Members
    .Where(member => member.Name.Contains("oe"))
    .OrderBy(member => member.Name)
    .ToList();

foreach (var member in selectedStudents) {
    Console.WriteLine(member.Name);
}

Console.WriteLine("before update");
Member before = teamsManagementContext.Members.FirstOrDefault(Member => Member.Name == "Henk");
Console.WriteLine(before.Email);

before.Email = "henk@gmail.nl";
teamsManagementContext.SaveChanges();

Console.WriteLine("after update");
Member after = teamsManagementContext.Members.FirstOrDefault(Member => Member.Name == "Henk");
Console.WriteLine(after.Email);
#endregion