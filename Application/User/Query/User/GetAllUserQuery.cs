using Application.User.DTO;
using AutoMapper;
using Infrastructure.Interface.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Query.User
{
    public class GetAllUserQuery : IRequest<IEnumerable<UserDTO>>
    {
    }

    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllUserQueryHandler(
                IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> Handle(
                GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.Users.GetAll());
            return _mapper.Map<IEnumerable<UserDTO>>(entities);
        }
    }
}
