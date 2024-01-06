using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using DbUp.Engine;
using DbUp.Engine.Transactions;
using DbUp.ScriptProviders;

namespace DbUp.Templating;

public class HashedScriptProvider : IScriptProvider 
{
    private IScriptProvider _scriptProvider;
    
    public HashedScriptProvider(IScriptProvider scriptProvider)
    {
        _scriptProvider = scriptProvider;
    }
    
    public IEnumerable<SqlScript> GetScripts(IConnectionManager connectionManager)
    {
        var scripts =  _scriptProvider.GetScripts(connectionManager);
        foreach (var script in scripts)
        {
            var hash = ComputeHash(script.Contents);
            var name = $"{script.Name}_{hash}";
            var newScript = new SqlScript(name, script.Contents);
            yield return newScript;
        }
    }

    private string ComputeHash(string scriptContents)
    {
        var md5 = MD5.Create();
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(scriptContents));
        var hashString = BitConverter.ToString(hash);
        return hashString;
    }
}