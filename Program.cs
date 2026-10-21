Console.WriteLine("Plan Your Heist!");

Console.WriteLine("Enter name of new Team Member:");
string name = Console.ReadLine();
Console.WriteLine("Enter Team Member skill level:");
int skillLevel = 0;
decimal courageFactor = 0.0M;

while (!int.TryParse(Console.ReadLine(), out skillLevel))
{
    Console.WriteLine("Enter a valid figure");
}

Console.WriteLine("Enter Team Member courage factor (0.0 to 2.0):");
while (!decimal.TryParse(Console.ReadLine(), out courageFactor) ||  (courageFactor < 0  || courageFactor > 2))
{
    Console.WriteLine("Enter a valid figure");
}

TeamMember member1 = new TeamMember()
{
    Name = name,
    SkillLevel = skillLevel,
    CourageFactor = courageFactor
};

Console.WriteLine(@$"Your team members include:
Name: {member1.Name}; Skill Level {member1.SkillLevel}; Courage Factor: {member1.CourageFactor }");