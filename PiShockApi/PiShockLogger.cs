using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace PiShockApi {
    public static class PiShockLogger {
        private static ILoggerFactory? _loggerFactory;

        private static readonly ConcurrentDictionary<Type, ILogger> _loggerByType = new();

        public static void Initialize( ILoggerFactory loggerFactory ) {
            if( _loggerFactory is not null ) {
                throw new InvalidOperationException( "StaticLogger already initialized!" );
            }

            _loggerFactory = loggerFactory ?? throw new ArgumentNullException( nameof( loggerFactory ) );
        }

        public static ILogger GetStaticLogger<T>() {
            return _loggerByType
                .GetOrAdd( typeof( T ), _loggerFactory?.CreateLogger<T>()! );
        }
    }
}