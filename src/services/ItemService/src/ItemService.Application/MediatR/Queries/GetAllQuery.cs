using System;
using ItemService.Application.DTOs;
using MediatR;

namespace ItemService.Application.MediatR.Queries
{
    public class GetAllQuery : IRequest<ServiceResult> {}
}