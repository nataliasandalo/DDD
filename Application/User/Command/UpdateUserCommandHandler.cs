using Application.User.DTO;
using FluentValidation;
using Infrastructure.Interface.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Exceptions;


namespace Application.User.Command
{
    public class UpdateUserCommand : IRequest<int>
    {
        public UpdateUserDTO Model { get; }
        public UpdateUserCommand(UpdateUserDTO model)
        {
            this.Model = model;
        }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<UpdateUserDTO> _validator;

        public UpdateUserCommandHandler(IUnitOfWork repository, IValidator<UpdateUserDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            UpdateUserDTO model = request.Model;

            var result = _validator.Validate(model);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            var entity = _repository.Users.Find(o => o.Id == request.Model.Id).FirstOrDefault();
            entity.Name = model.Name;
            entity.Lastname = model.Lastname;
            entity.Birthday = model.Birthday;
            entity.Vatnumber = model.Vatnumber;
            entity.Email = model.Email;

            await _repository.CommitAsync();

            return entity.Id;
        }
    }
}
