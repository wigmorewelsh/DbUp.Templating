using DbUp.Engine;

namespace DbUp.Templating.Handlebars;

public class HandlebarsScriptPreprocessor : IScriptPreprocessor
{
    private readonly IDictionary<string, string> _variableSetVariables;

    public HandlebarsScriptPreprocessor(IDictionary<string, string> variableSetVariables)
    {
        _variableSetVariables = variableSetVariables;
    }

    public string Process(string contents)
    {
        var template = HandlebarsDotNet.Handlebars.Compile(contents);
        var result = template(_variableSetVariables);
        return result;
    }
}