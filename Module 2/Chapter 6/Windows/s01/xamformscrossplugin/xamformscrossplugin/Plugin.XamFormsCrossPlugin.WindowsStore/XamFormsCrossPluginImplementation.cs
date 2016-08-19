using Plugin.XamFormsCrossPlugin.Abstractions;
using System;


namespace Plugin.XamFormsCrossPlugin
{
  /// <summary>
  /// Implementation for XamFormsCrossPlugin
  /// </summary>
  public class XamFormsCrossPluginImplementation : IXamFormsCrossPlugin
  {
        public string PlatformHelloWorld()
        {
            return "Hello from Windows Store 8.1";
        }
    }
}