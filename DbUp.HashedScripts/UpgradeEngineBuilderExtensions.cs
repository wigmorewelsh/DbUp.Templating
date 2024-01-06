using System.Reflection;
using DbUp.Builder;
using DbUp.Engine;
using DbUp.ScriptProviders;

namespace DbUp.Templating;

public static class UpgradeEngineBuilderExtensions
{
    public static UpgradeEngineBuilder WithHashedScriptsEmbeddedInAssembly(this UpgradeEngineBuilder builder,
        Assembly assembly)
    {
        var embeddedScriptProvider = new EmbeddedScriptProvider(
            assembly,
            s => s.EndsWith(".sql", StringComparison.OrdinalIgnoreCase)
        );
        return builder.WithScripts(new HashedScriptProvider(embeddedScriptProvider));
    }
}