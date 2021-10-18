using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Domain.Interfaces.Services;

namespace WarehouseManagement.Service
{
    public class ProductUnitService : IProductUnitService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductUnitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<ProductUnit>> GetAll()
        {
            return await _unitOfWork.Repository<ProductUnit>().GetAllAsync();
        }

        public async Task<ProductUnit> GetOne(int unitId)
        {
            return await _unitOfWork.Repository<ProductUnit>().FindAsync(unitId);
        }

        public async Task Update(ProductUnit unitInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var unitRepos = _unitOfWork.Repository<ProductUnit>();
                var unit = await unitRepos.FindAsync(unitInput.Id);
                if (unit == null)
                    throw new KeyNotFoundException();

                unit.Title = unit.Title;

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Add(ProductUnit unitInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var unitRepos = _unitOfWork.Repository<ProductUnit>();
                await unitRepos.InsertAsync(unitInput);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int unitId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var unitRepos = _unitOfWork.Repository<ProductUnit>();
                var unit = await unitRepos.FindAsync(unitId);
                if (unit == null)
                    throw new KeyNotFoundException();

                await unitRepos.DeleteAsync(unit);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }
    }
}