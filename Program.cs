using System.Xml.Linq;

List<TeamMember> teamMembers = new List<TeamMember>();

Console.WriteLine("Plan Your Heist!");
bool done = false;

int heistDifficulty = 100;
Console.WriteLine("Enter Bank difficulty:");
while (!int.TryParse(Console.ReadLine(), out heistDifficulty))
{
    Console.WriteLine("Enter a valid figure");
}

Random random = new Random();
int luckValue = random.Next(-10, 11);

int successfulRuns = 0;
int failedRuns = 0;

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

Console.WriteLine($"You have {teamMembers.Count} team members");

runScenarios();
Console.WriteLine(@$"Successful runs: {successfulRuns}
Failed runs: {failedRuns}");

//DetermineSuccess();
//DisplayTeamMembers();
void DetermineSuccess()
{
    if (teamMembers.Count != 0)
    {
        int teamSkillLevel = teamMembers.Sum(p => p.SkillLevel);
        

        Console.WriteLine($"The team's combined skill level is {teamSkillLevel}");
        Console.WriteLine($"The bank's difficulty level is {heistDifficulty + luckValue}");

        if (teamSkillLevel >= (heistDifficulty + luckValue))
        {
            Console.WriteLine("Heist Successful");
            successfulRuns += 1;
        }
        else
        {
            Console.WriteLine("Heist Failed");
            failedRuns += 1;
        }
    }
    else
    {
        Console.WriteLine("You need to recruit some.");
    }
}

void DisplayTeamMembers()
{
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

void runScenarios()
{
    Console.WriteLine("Enter the number of trial runs:");
    int trialRuns = 0;

    while (!int.TryParse(Console.ReadLine(), out trialRuns))
    {
        Console.WriteLine("Enter a valid figure");
    }

    for (int i = 0; i < trialRuns; i++)
    {
        Console.WriteLine($"Trial {i + 1}");
        luckValue = random.Next(-10, 11);
        DetermineSuccess();
        Console.WriteLine("");
    }
}