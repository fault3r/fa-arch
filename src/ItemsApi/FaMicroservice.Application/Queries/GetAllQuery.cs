using System;
using FaMicroservice.Application.DTOs;
using MediatR;

namespace FaMicroservice.Application.Queries
{
    public class GetAllQuery : IRequest<ServiceResult> {}
}