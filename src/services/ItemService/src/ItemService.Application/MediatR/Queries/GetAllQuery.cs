using System;
using FaMicroservice.Application.DTOs;
using MediatR;

namespace FaMicroservice.Application.MediatR.Queries
{
    public class GetAllQuery : IRequest<ServiceResult> {}
}