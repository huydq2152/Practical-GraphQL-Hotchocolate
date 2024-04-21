using System.Reflection;
using GraphQL.Data;
using HotChocolate.Types.Descriptors;

namespace GraphQL.GraphQL.Extensions;

public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
{
    protected override void OnConfigure(
        IDescriptorContext context,
        IObjectFieldDescriptor descriptor,
        MemberInfo member)
    {
        descriptor.UseDbContext<ApplicationDbContext>();
    }
}