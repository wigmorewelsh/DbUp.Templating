namespace DbUp.Templating;

public interface IVariableSet
{
    string Name { get; }
    IDictionary<string, string> Variables { get; }
}