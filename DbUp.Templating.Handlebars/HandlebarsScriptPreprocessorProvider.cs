using DbUp.Engine;

namespace DbUp.Templating.Handlebars;

public class HandlebarsScriptPreprocessorProvider : IScriptPreprocessorProvider
{
    public IScriptPreprocessor GetScriptPreprocessor(IVariableSet variableSet)
    {
        return new HandlebarsScriptPreprocessor(variableSet.Variables);
    }
}