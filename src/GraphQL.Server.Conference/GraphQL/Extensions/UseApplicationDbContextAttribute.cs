using System.Reflection;
using GraphQL.Server.Conference.Data.Contexts;
using GraphQL.Server.Conference.Data;
using HotChocolate.Types.Descriptors;

namespace GraphQL.Server.Conference.GraphQL.Extensions;

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