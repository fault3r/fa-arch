using System;
using GraphqlService.Api.GraphQL.Models;

namespace GraphqlService.Api.GraphQL.Queries
{
    public class Query
    {
        private readonly IList<Message> messages = [
            new Message(1, "you don't know what I did!"),
            new Message(2, "one ring to rule them all."),
            new Message(3, "you have been told many lies."),
            new Message(4, "it requires to create a new world."),
            new Message(5, "what do you know of darkness."),
            new Message(6, "who's been transformed by darkness."),
            new Message(7, "I've been awake since the breaking of the first filence."),
        ];

        public IEnumerable<Message> Messages => messages;
    }
}