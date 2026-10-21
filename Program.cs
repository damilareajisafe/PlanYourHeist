using System.Xml.Linq;

List<TeamMember> teamMembers = new List<TeamMember>();

Console.WriteLine("Plan Your Heist!");
bool done = false;

while (!done)
{
    Console.WriteLine("Enter name of new Team Member:");
    string name = Console.ReadLine();
    if (name == "")
    {
        done = true;
        break;
    }
    Console.WriteLine("Enter Team Member skill level:");
    int skillLevel = 0;
    decimal courageFactor = 0.0M;

    while (!int.TryParse(Console.ReadLine(), out skillLevel))
    {
        Console.WriteLine("Enter a valid figure");
    }

    Console.WriteLine("Enter Team Member courage factor (0.0 to 2.0):");
    while (!decimal.TryParse(Console.ReadLine(), out courageFactor) || (courageFactor < 0 || courageFactor > 2))
    {
        Console.WriteLine("Enter a valid figure");
    }

    teamMembers.Add(new TeamMember()
    {
        Name = name,
        SkillLevel = skillLevel,
        CourageFactor = courageFactor
    });
}

DisplayTeamMembers();

void DisplayTeamMembers()
{
    Console.WriteLine($"You have {teamMembers.Count} team members");
    if (teamMembers.Count != 0)
    {
        Console.WriteLine(@$"Your team members include:");
        foreach (TeamMember teamMember in teamMembers)
        {
            Console.WriteLine($"Name: {teamMember.Name}; Skill Level: {teamMember.SkillLevel}; Courage Factor: {teamMember.CourageFactor}");
        }
    }
    else
    {
        Console.WriteLine("You need to recruit some.");
    }

}