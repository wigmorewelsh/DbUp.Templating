namespace DbUp.Templating;

public interface IVariableSetProvider
{
    IEnumerable<IVariableSet> GetVariableSets();
}