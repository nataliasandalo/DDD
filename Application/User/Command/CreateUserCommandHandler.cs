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
    public class CreateUserCommand : IRequest<int>
    {
        public CreateUserDTO Model { get; }
        public CreateUserCommand(CreateUserDTO model)
        {
            this.Model = model;
        }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateUserDTO> _validator;

        public CreateUserCommandHandler(IUnitOfWork repository, IValidator<CreateUserDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            CreateUserDTO model = request.Model;

            var result = _validator.Validate(model);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            var entity = new Domain.Entities.User
            {
                Name = model.Name,
                Lastname = model.Lastname,
                Birthday = model.Birthday,
                Vatnumber = model.Vatnumber,
                Email = model.Email,
            };

            _repository.Users.Add(entity);
            await _repository.CommitAsync();

            return entity.Id;
        }
    }
}
