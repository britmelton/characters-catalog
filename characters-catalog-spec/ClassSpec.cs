using Characters.Catalog.Domain;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Characters.Catalog.Spec;

public class ClassSpec
{
    [Theory]
    [InlineData("name", "subclass", 3)]
    [InlineData("othername", "othersubclass", 1)]
    [InlineData("finalname", "finalsubclass", 0)]
    public void WhenCreatingAClass_ThenAllPropertiesAreSet(string classname, string subclass, uint level)
    {
        var @class = new Class(classname, level, subclass);

        var scope = new AssertionScope();
        @class.ClassName.Should().Be(@classname);
        @class.Subclass.Should().Be(subclass);
        @class.Level.Should().Be(@level);
    }
}