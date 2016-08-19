using Plugin.XamFormsCrossPlugin.Abstractions;
using System;

namespace Plugin.XamFormsCrossPlugin
{
  /// <summary>
  /// Cross platform XamFormsCrossPlugin implemenations
  /// </summary>
  public class CrossXamFormsCrossPlugin
  {
    static Lazy<IXamFormsCrossPlugin> Implementation = new Lazy<IXamFormsCrossPlugin>(() => CreateXamFormsCrossPlugin(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static IXamFormsCrossPlugin Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static IXamFormsCrossPlugin CreateXamFormsCrossPlugin()
    {
#if PORTABLE
        return null;
#else
        return new XamFormsCrossPluginImplementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
