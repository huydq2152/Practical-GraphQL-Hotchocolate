using GraphQL.Server.Conference.Data.Entities;
using HotChocolate.Data.Sorting;

namespace GraphQL.Server.Conference.GraphQL.Data.Sessions;

/// <summary>
/// Custom sort type to enable ordering on properties of <see cref="Session"/>
/// </summary>
public class SessionSortInputType : SortInputType<Session>
{
  protected override void Configure(ISortInputTypeDescriptor<Session> descriptor)
  {
    descriptor.BindFieldsExplicitly();

    descriptor.Field(s => s.StartTime).Type<DefaultSortEnumType>();
    descriptor.Field(s => s.EndTime).Type<DefaultSortEnumType>();
  }
}
