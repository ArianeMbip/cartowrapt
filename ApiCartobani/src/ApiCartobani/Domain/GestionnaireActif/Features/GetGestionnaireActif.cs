namespace ApiCartobani.Domain.GestionnaireActif.Features;

using ApiCartobani.Domain.GestionnaireActif.Dtos;
using ApiCartobani.Domain.GestionnaireActif.Services;
using SharedKernel.Exceptions;
using MapsterMapper;
using MediatR;

public static class GetGestionnaireActif
{
    public sealed class Query : IRequest<GestionnaireActifDto>
    {
        public readonly Guid Id;

        public Query(Guid id)
        {
            Id = id;
        }
    }

    public sealed class Handler : IRequestHandler<Query, GestionnaireActifDto>
    {
        private readonly IGestionnaireActifRepository _gestionnaireActifRepository;
        private readonly IMapper _mapper;

        public Handler(IGestionnaireActifRepository gestionnaireActifRepository, IMapper mapper)
        {
            _mapper = mapper;
            _gestionnaireActifRepository = gestionnaireActifRepository;
        }

        public async Task<GestionnaireActifDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _gestionnaireActifRepository.GetById(request.Id, cancellationToken: cancellationToken);
            return _mapper.Map<GestionnaireActifDto>(result);
        }
    }
}