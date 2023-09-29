namespace Characters.Catalog.Domain;

public class Class
{
    public Class(string className, uint level, string subclass)
    {
        Level = level;
        ClassName = className;
        Subclass = subclass;
    }

    public uint Level { get; set; }
    public string ClassName { get; set; }
    public string Subclass { get; set; }
}