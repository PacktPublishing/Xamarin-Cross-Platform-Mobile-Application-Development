using Plugin.XamFormsCrossPlugin.Abstractions;

namespace Plugin.XamFormsCrossPlugin
{
    /// <summary>
    /// Implementation for XamFormsCrossPlugin
    /// </summary>
    public class XamFormsCrossPluginImplementation : IXamFormsCrossPlugin
    {
        public string PlatformHelloWorld()
        {
            return "Hello from iOS";
        }
    }
}