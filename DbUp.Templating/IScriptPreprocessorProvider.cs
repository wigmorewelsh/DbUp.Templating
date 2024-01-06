using DbUp.Engine;

namespace DbUp.Templating;

public interface IScriptPreprocessorProvider
{
    IScriptPreprocessor GetScriptPreprocessor(IVariableSet variableSet);
}