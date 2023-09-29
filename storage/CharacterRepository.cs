using Characters.Catalog.Domain;

namespace Storage;

public class CharacterRepository : ICharacterRepository
{
    private static readonly Dictionary<string, Character> _characters = new();
    public void CreateCharacter(Character character)
    {
        _characters.Add(character.Name, character);
    }

    public IEnumerable<Character> FetchCharacters()
    {
       return _characters.Values;
    }

    public Character Find(string name)
    {
        return _characters[name];
    }

    public void Update(Character character)
    {
        _characters[character.Name] = character;
    }
}