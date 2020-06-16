using System.Linq.Expressions;
using SimpleInjector;

namespace FantaF1.Extentions.SimpleInjector
{
    public interface IParameterConvention
    {
        bool CanResolve(InjectionTargetInfo target);
        Expression BuildExpression(InjectionConsumerInfo consumer);
    }
}