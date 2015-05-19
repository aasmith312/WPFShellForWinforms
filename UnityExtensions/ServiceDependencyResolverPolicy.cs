using Microsoft.Practices.ObjectBuilder2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityExtensions
{
    public class ServiceDependencyResolverPolicy : IDependencyResolverPolicy
    {
        private readonly Type _type;

        public ServiceDependencyResolverPolicy(Type type)
        {
            _type = type;
        }

        public object Resolve(IBuilderContext context)
        {
            return context.NewBuildUp(new NamedTypeBuildKey(_type));
        }
    }
}
