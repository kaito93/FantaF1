using SimpleInjector;

namespace FantaF1.Extentions.SimpleInjector
{
    public static class ContainerOptionsExtentionMethods
    {
        public static void RegisterParameterConvention(this ContainerOptions options, IParameterConvention convention)
        {
            options.DependencyInjectionBehavior = new ConventionDependencyInjectionBehavior(options.DependencyInjectionBehavior, convention);
        }
    }
}