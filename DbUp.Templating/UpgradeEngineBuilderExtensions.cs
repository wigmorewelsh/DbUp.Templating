using System.Reflection;
using DbUp.Builder;
using DbUp.Engine;
using DbUp.ScriptProviders;

namespace DbUp.Templating;

public static class UpgradeEngineBuilderExtensions
{
    public static UpgradeEngineBuilder WithVariableSets(this UpgradeEngineBuilder builder,
        IScriptProvider scriptProvider, IVariableSetProvider variableSetProvider, IScriptPreprocessorProvider scriptPreprocessor)
    {
        return builder.WithScripts(new VariableSetScriptProvider(scriptProvider, variableSetProvider, scriptPreprocessor));
    } 
}