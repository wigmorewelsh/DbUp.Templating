using DbUp.Engine;
using DbUp.Engine.Preprocessors;

namespace DbUp.Templating;

public class VariableSubstitutionPreprocessorProvider : IScriptPreprocessorProvider
{
    public IScriptPreprocessor GetScriptPreprocessor(IVariableSet variableSet)
    {
        return new VariableSubstitutionPreprocessor(variableSet.Variables);
    }
}