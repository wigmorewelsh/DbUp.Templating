using DbUp.Engine;
using DbUp.Engine.Transactions;

namespace DbUp.Templating;

public class VariableSetScriptProvider : IScriptProvider
{
    private readonly IScriptProvider _scriptProvider;
    private readonly IVariableSetProvider _variableSetProvider;
    private readonly IScriptPreprocessorProvider _scriptPreprocessor;

    public VariableSetScriptProvider(IScriptProvider scriptProvider, IVariableSetProvider variableSetProvider, IScriptPreprocessorProvider scriptPreprocessor)
    {
        _scriptProvider = scriptProvider;
        _variableSetProvider = variableSetProvider;
        _scriptPreprocessor = scriptPreprocessor;
    }

    public IEnumerable<SqlScript> GetScripts(IConnectionManager connectionManager)
    {
        var variableSets = _variableSetProvider.GetVariableSets();
        // check all variable sets have unique names, throw if not
        
        var scripts = _scriptProvider.GetScripts(connectionManager);
        foreach (var script in scripts)
        {
            foreach (var variableSet in variableSets)
            {
                var name = $"{variableSet.Name}_{script.Name}";
                var scriptPreprocessor = _scriptPreprocessor.GetScriptPreprocessor(variableSet);
                var contents = scriptPreprocessor.Process(script.Contents);
                var newScript = new SqlScript(name, contents);
                yield return newScript;
            }
        }
    }
}