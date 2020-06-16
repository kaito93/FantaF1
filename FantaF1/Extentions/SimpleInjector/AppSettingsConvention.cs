using System;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq.Expressions;
using SimpleInjector;

namespace FantaF1.Extentions.SimpleInjector
{
    public class AppSettingsConvention : IParameterConvention
    {
        private const string AppSettingsPostFix = "AppSetting";

        //[DebuggerStepThrough]
        public bool CanResolve(InjectionTargetInfo target)
        {
            var type = target.TargetType;

            var resolvable =
                (type.IsValueType || type == typeof(string)) &&
                target.Name.EndsWith(AppSettingsPostFix) &&
                target.Name.LastIndexOf(AppSettingsPostFix, StringComparison.Ordinal) > 0;

            if (resolvable)
            {
                VerifyConfigurationFile(target);
            }

            return resolvable;
        }

        //[DebuggerStepThrough]
        public Expression BuildExpression(InjectionConsumerInfo consumer)
        {
            var valueToInject = GetAppSettingValue(consumer.Target);

            return Expression.Constant(valueToInject, consumer.Target.TargetType);
        }

        //[DebuggerStepThrough]
        private void VerifyConfigurationFile(InjectionTargetInfo target)
        {
            GetAppSettingValue(target);
        }

        //[DebuggerStepThrough]
        private static object GetAppSettingValue(InjectionTargetInfo target)
        {
            var key = target.Name.Substring(0, target.Name.LastIndexOf(AppSettingsPostFix, StringComparison.Ordinal));

            var configurationValue = ConfigurationManager.AppSettings[key];

            if (configurationValue == null)
                throw new ActivationException(string.Format(
                    "Non è stata trovata nessuna chiave di configurazione con mone '{0}' nel file di configurazione",
                    key));

            var converter = TypeDescriptor.GetConverter(target.TargetType);
            return converter.ConvertFromString(null, CultureInfo.InvariantCulture, configurationValue);

        }
    }
}