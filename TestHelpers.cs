using System;
using System.Linq;
using NUnit.Framework;

namespace PA.OpinionApplicator.RuleEvaluator.Tests.Unit.Application
{
    public static class TestHelpers
    {
        public static void CtorWithNullArgumentsThrows<T>()
        {
            foreach (var ci in typeof(T).GetConstructors().Where(x => x.IsPublic))
            {
                var ctorParams = ci.GetParameters().Select(pi => FakeItEasy.Sdk.Create.Dummy(pi.ParameterType)).ToArray();

                for (var idx = 0; idx < ctorParams.Length; idx++)
                {
                    var tstParams = (object[])ctorParams.Clone();
                    tstParams[idx] = null;

                    Assert.That(() => ci.Invoke(tstParams), Throws.TargetInvocationException.With.InnerException.TypeOf<ArgumentNullException>());
                }
            }
        }
    }
}
