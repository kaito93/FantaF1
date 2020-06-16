﻿using System.Diagnostics;
using System.Linq.Expressions;
using SimpleInjector;
using SimpleInjector.Advanced;

namespace FantaF1.Extentions.SimpleInjector
{
    internal class ConventionDependencyInjectionBehavior : IDependencyInjectionBehavior
    {
        private readonly IDependencyInjectionBehavior _decoratee;
        private readonly IParameterConvention _convention;

        public ConventionDependencyInjectionBehavior(
            IDependencyInjectionBehavior decoratee, IParameterConvention convention)
        {
            this._decoratee = decoratee;
            this._convention = convention;
        }

        [DebuggerStepThrough]
        public Expression BuildExpression(InjectionConsumerInfo consumer)
        {
            return _convention.CanResolve(consumer.Target)
                ? _convention.BuildExpression(consumer)
                : _decoratee.BuildExpression(consumer);
        }

        [DebuggerStepThrough]
        public void Verify(InjectionConsumerInfo consumer)
        {
            if (!_convention.CanResolve(consumer.Target))
            {
                _decoratee.Verify(consumer);
            }
        }
    }
}