using AutoMapper;
using Core.Infrastruture.RepositoryPattern.Repository;
using DataLayer.Models;
using Domain.DTOs;
using Domain.Helper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class TransactionTypeService(IRepository<TransactionType> _transactionTypeRepository,IMapper _mapper , IChangeLogService _changeLogService) : ITransactionTypeService
    {
        public async Task<TransactionTypeResult> CreateAsync(TransactionTypeDto transactionTypeDto)
        {
            var result = new TransactionTypeResult();
            if (_transactionTypeRepository.Find(n => n.Name.ToLower() == transactionTypeDto.Name.ToLower()) != null)
                return Helper.Helper.CreateErrorResult<TransactionTypeResult>(HttpStatusCode.BadRequest, ErrorEnum.Existed("Transaction type"));
            TransactionType transactionType = _mapper.Map<TransactionType>(transactionTypeDto);
            _changeLogService.SetCreateChangeLogInfo(transactionType);
            await _transactionTypeRepository.AddAsync(transactionType);
            result.TransactionType = transactionTypeDto;
            result.SuccessMessage = MessageEnum.Created(typeof(TransactionType).Name);
            result.StatusCode = HttpStatusCode.Created;
            return result;
        }

        public async Task<TransactionTypeResult> DeleteAsync(int id)
        {
            var result = new TransactionTypeResult();
            var transactionType = await _transactionTypeRepository.GetByIdAsync(id);
            if (transactionType == null)
                return Helper.Helper.CreateErrorResult<TransactionTypeResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Transaction type"));
            if (transactionType.IsDeleted == true)
                return Helper.Helper.CreateErrorResult<TransactionTypeResult>(HttpStatusCode.BadRequest, "Transaction type already Deleted");
            transactionType.IsDeleted = true;
            _changeLogService.SetDeleteChangeLogInfo(transactionType);
            await _transactionTypeRepository.UpdateAsync(transactionType);
            result.SuccessMessage = MessageEnum.Deleted(typeof(TransactionType).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetTransactionTypeResult> GetAllAsync()
        {
            var result = new GetTransactionTypeResult();
            var transactionTypes = await _transactionTypeRepository.GetAllAsync();
            if (!transactionTypes.Any())
                return Helper.Helper.CreateErrorResult<GetTransactionTypeResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundAny("Transaction type"));
            var transactionTypeDto = _mapper.Map<List<GetTransactionTypeDto>>(transactionTypes);
            result.TransactionTypes = transactionTypeDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(TransactionType).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<GetTransactionTypeResult> GetAsync(int id)
        {
            var result = new GetTransactionTypeResult();
            var transactionType = await _transactionTypeRepository.GetByIdAsync(id);
            if (transactionType==null)
                return Helper.Helper.CreateErrorResult<GetTransactionTypeResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Transaction type"));
            var transactionTypeDto = _mapper.Map<GetTransactionTypeDto>(transactionType);
            result.TransactionType = transactionTypeDto;
            result.SuccessMessage = MessageEnum.Getted(typeof(TransactionType).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }

        public async Task<TransactionTypeResult> UpdateAsync(int id, TransactionTypeDto transactionTypeDto)
        {
            var result = new TransactionTypeResult();
            var transactionType = await _transactionTypeRepository.GetByIdAsync(id);
            if (transactionType == null)
                return Helper.Helper.CreateErrorResult<TransactionTypeResult>(HttpStatusCode.NotFound, ErrorEnum.NotFoundMessage("Transaction type"));
            _mapper.Map(transactionTypeDto, transactionType);
            _changeLogService.SetUpdateChangeLogInfo(transactionType);
            await _transactionTypeRepository.UpdateAsync(transactionType);
            result.TransactionType = transactionTypeDto;
            result.SuccessMessage = MessageEnum.Updated(typeof(TransactionType).Name);
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }
    }
}
