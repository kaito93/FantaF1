using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq.Expressions;
using SimpleInjector;

namespace FantaF1.Extentions.SimpleInjector
{
    public class ConnectionStringsConvention : IParameterConvention
    {
        private const string ConnectionStringPostFix = "ConnectionString";

        [DebuggerStepThrough]
        public bool CanResolve(InjectionTargetInfo target)
        {
            var resolvable =
                target.TargetType == typeof(string) &&
                target.Name.EndsWith(ConnectionStringPostFix) &&
                target.Name.LastIndexOf(ConnectionStringPostFix, StringComparison.Ordinal) > 0;

            if (resolvable)
            {
                VerifyConfigurationFile(target);
            }

            return resolvable;
        }

        [DebuggerStepThrough]
        public Expression BuildExpression(InjectionConsumerInfo consumer)
        {
            var connectionString = GetConnectionString(consumer.Target);

            return Expression.Constant(connectionString, typeof(string));
        }

        [DebuggerStepThrough]
        private void VerifyConfigurationFile(InjectionTargetInfo target)
        {
            GetConnectionString(target);
        }

        [DebuggerStepThrough]
        private static string GetConnectionString(InjectionTargetInfo target)
        {
            var name = target.Name.Substring(0, target.Name.LastIndexOf(ConnectionStringPostFix, StringComparison.Ordinal));

            var settings = ConfigurationManager.ConnectionStrings[name];

            if (settings == null)
            {
                throw new ActivationException(string.Format("Non è stata trovata nessuna stringa di connessione con nome '{0}' nel file di configurazione.", name));
            }

            return settings.ConnectionString;
        }
    }
}