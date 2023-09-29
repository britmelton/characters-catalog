namespace Characters.Catalog.Domain;

public class Character
{
    public Character(string name, string race, uint age)
    {
        Age = age;
        Name = name;
        Race = race;
    }

    public uint Age { get; set; }
    public uint Charisma { get; set; }
    public List<Class> Classes = new();
    public uint Constitution { get; set; }
    public uint Dexterity { get; set; }
    public string EyeColor { get; set; }
    public string Gender { get; set; }
    public string HairColor { get; set; }
    public string Height { get; set; }
    public uint Intelligence { get; set; }
    public string Name { get; set; }
    public string Race { get; set; }
    public string Species { get; set; }
    public uint Strength { get; set; }
    public uint Weight { get; set; }
    public uint Wisdom { get; set; }

    public void AddClass(string classname, uint level, string subclass)
    {
        var @class = new Class(classname, level, subclass);
        Classes.Add(@class);
    }

    public void AddClass(params Class[] classes)
    {
        Classes.AddRange(classes);
    }
}