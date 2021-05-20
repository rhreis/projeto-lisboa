using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class ItemPhotosRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationContext _context;
        private DbSet<T> _dataSet;

        public ItemPhotosRepository(ApplicationContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                ItemPhotosEntity itemPhoto = await _context.ItemPhotos.SingleAsync(p => p.Id.Equals(id));
                var photoSet = _context.ItemPhotoPropertySet.Where(p => p.ItemPhotoId.Equals(itemPhoto.Id));

                foreach (var set in photoSet)
                {
                    itemPhoto.ItemPhotoPropertySet.Remove(set);
                }

                _context.Remove(itemPhoto);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                _dataSet.Add(item);
                
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<T> SelectAsync(int id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectFillAsync()
        {
            try
            {
                var result = await _context.Items
                    .Include("ItemPhotos")
                    .Include("ItemPhotos.ItemPhotoPropertySet")
                    .ToListAsync();

                return await _dataSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                if (result == null)
                    return null;
                
                _context.Entry(result).CurrentValues.SetValues(item);

                _dataSet.Update(result);

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}