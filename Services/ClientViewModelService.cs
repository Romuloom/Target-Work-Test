﻿using AutoMapper;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces;
using Cadastro.Interfaces;
using Cadastro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Services
{
    public class ClientViewModelService : IClientViewModelService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientViewModelService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            _clientRepository.Delete(id);
        }

        public ClientViewModel Get(int id)
        {
            var entity = _clientRepository.Get(id);
            if (entity == null)
                return null;

            return _mapper.Map<ClientViewModel>(entity);
        }

        public IEnumerable<ClientViewModel> GetAll()
        {
            var clients = _clientRepository.GetAll();
            return clients.Select(client => new ClientViewModel
            {
                Id = client.Id,
                Name = client.Name,
                LastName = client.LastName,
                Email = client.Email,
                Ative = client.Ative,
                DataCadastro = client.DataCadastro
            });
        }

        public void Insert(ClientViewModel viewModel)
        {
            var entity = _mapper.Map<Client>(viewModel);
            entity.DataCadastro = DateTime.Now;
            _clientRepository.Insert(entity);
        }

        public void Update(ClientViewModel viewModel)
        {
            var entity = _mapper.Map<Client>(viewModel);

            _clientRepository.Update(entity);
        }
    }
}
