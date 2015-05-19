using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityExtensions
{
    public sealed class ServiceDependencyAttribute : DependencyResolutionAttribute
    {
        public override IDependencyResolverPolicy CreateResolver(Type typeToResolve)
        {
            return new ServiceDependencyResolverPolicy(typeToResolve);
        }
    }
}
