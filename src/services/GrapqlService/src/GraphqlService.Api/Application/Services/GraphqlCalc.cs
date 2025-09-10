using System;

namespace GraphqlService.Api.Application.Services
{
    public class GraphqlCalc
    {
        public string Hello() => "GraphQL Service: localhost:5008";

        public int Sum(int x, int y) => x + y;

        public int Subtraction(int x, int y) => x - y;        
    }
}