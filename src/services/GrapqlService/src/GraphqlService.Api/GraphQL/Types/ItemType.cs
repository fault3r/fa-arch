using System;
using GraphqlService.Api.Domain.Entities;

namespace GraphqlService.Api.GraphQL.Types
{
    public class ItemType : ObjectType<Item>
    {
        protected override void Configure(IObjectTypeDescriptor<Item> descriptor)
        {
            descriptor.Field(p => p.Id).Type<NonNullType<IdType>>();
            descriptor.Field(p => p.Name).Type<NonNullType<StringType>>();
        }
    }
}