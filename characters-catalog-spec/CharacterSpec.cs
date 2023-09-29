using Characters.Catalog.Domain;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Characters.Catalog.Spec.DomainSpec;

public class CharacterSpec
{
    [Theory]
    [InlineData("name", "race", 345)]
    [InlineData("othername", "otherrace", 34)]
    [InlineData("finalname", "thisrace", 3097)]
    public void WhenCreatingACharacter_ThenAllPropertiesAreSet(string name, string race, uint age)
    {
        var character = new Character(name, race, age);

        var scope = new AssertionScope();
        character.Name.Should().Be(name);
        character.Race.Should().Be(race);
        character.Age.Should().Be(age);
    }

    [Fact]
    public void WhenAddingSingleClassToCharacter_ThenClassExistsInCharacter()
    {
        var character = new Character("name", "race", 9087);
        var @class = new Class("classname", 3, "subclass");

        character.AddClass(@class);

        character.Classes.Count.Should().Be(1);
        character.Classes[0].ClassName.Should().Be("classname");
    }

    [Fact]
    public void WhenAddingMultipleClassesToCharacter_ThenCharacterContainsAll()
    {
        var character = new Character("name", "race", 9087);
        var class1 = new Class("classname", 3, "subclass");
        var class2 = new Class("othername", 1, "othersubclass");
        var class3 = new Class("finalname", 0, "finalsubclass");

        character.AddClass(class1);
        character.AddClass(class2);
        character.AddClass(class3);


        var scope = new AssertionScope();
        character.Classes.Count.Should().Be(3);
        character.Classes[0].ClassName.Should().Be("classname");
        character.Classes[1].ClassName.Should().Be("secondclass");
        character.Classes[2].ClassName.Should().Be("finalclass");
    }
}