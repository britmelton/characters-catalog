namespace Characters.Catalog.Domain;

public interface ICharacterRepository
{
    public void CreateCharacter(Character character);
    public Character Find(string Name);

    public void Update(Character character);

    IEnumerable<Character> FetchCharacters();
}