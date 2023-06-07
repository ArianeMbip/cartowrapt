namespace ApiCartobani.Domain.Users.Features;

using ApiCartobani.Domain.Users;
using ApiCartobani.Domain.Users.Dtos;
using ApiCartobani.Domain.Users.Services;
using ApiCartobani.Services;
using SharedKernel.Exceptions;
using ApiCartobani.Domain;
using HeimGuard;
using MapsterMapper;
using MediatR;

public static class UpdateUser
{
    public sealed class Command : IRequest<bool>
    {
        public readonly Guid Id;
        public readonly UserForUpdateDto UpdatedUserData;

        public Command(Guid id, UserForUpdateDto updatedUserData)
        {
            Id = id;
            UpdatedUserData = updatedUserData;
        }
    }

    public sealed class Handler : IRequestHandler<Command, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHeimGuardClient _heimGuard;

        public Handler(IUserRepository userRepository, IUnitOfWork unitOfWork, IHeimGuardClient heimGuard)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _heimGuard = heimGuard;
        }

        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            await _heimGuard.MustHavePermission<ForbiddenAccessException>(Permissions.CanUpdateUsers);

            var userToUpdate = await _userRepository.GetById(request.Id, cancellationToken: cancellationToken);

            userToUpdate.Update(request.UpdatedUserData);
            _userRepository.Update(userToUpdate);
            return await _unitOfWork.CommitChanges(cancellationToken) >= 1;
        }
    }
}