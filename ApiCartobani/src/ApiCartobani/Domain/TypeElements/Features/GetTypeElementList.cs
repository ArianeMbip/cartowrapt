namespace ApiCartobani.Domain.TypeElements.Features;

using ApiCartobani.Domain.TypeElements.Dtos;
using ApiCartobani.Domain.TypeElements.Services;
using ApiCartobani.Wrappers;
using SharedKernel.Exceptions;
using Microsoft.EntityFrameworkCore;
using MapsterMapper;
using Mapster;
using MediatR;
using Sieve.Models;
using Sieve.Services;

public static class GetTypeElementList
{
    public sealed class Query : IRequest<PagedList<TypeElementDto>>
    {
        public readonly TypeElementParametersDto QueryParameters;

        public Query(TypeElementParametersDto queryParameters)
        {
            QueryParameters = queryParameters;
        }
    }

    public sealed class Handler : IRequestHandler<Query, PagedList<TypeElementDto>>
    {
        private readonly ITypeElementRepository _typeElementRepository;
        private readonly SieveProcessor _sieveProcessor;
        private readonly IMapper _mapper;

        public Handler(ITypeElementRepository typeElementRepository, IMapper mapper, SieveProcessor sieveProcessor)
        {
            _mapper = mapper;
            _typeElementRepository = typeElementRepository;
            _sieveProcessor = sieveProcessor;
        }

        public async Task<PagedList<TypeElementDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = _typeElementRepository.Query().AsNoTracking();

            var sieveModel = new SieveModel
            {
                Sorts = request.QueryParameters.SortOrder ?? "-CreatedOn",
                Filters = request.QueryParameters.Filters
            };

            var appliedCollection = _sieveProcessor.Apply(sieveModel, collection);
            var dtoCollection = appliedCollection
                .ProjectToType<TypeElementDto>();

            return await PagedList<TypeElementDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}