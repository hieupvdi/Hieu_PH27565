using AppData.Context;
using AppData.IRepositories;
using AppData.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Repositories
{
    public class NhanVienRepositories<T> : INhanVienRepositories<T> where T : class
    {
        NhanvienContext context;
        DbSet<T> dbset; // Tạo mới vì dùng generic không trỏ tới
        // một dbset cụ thể
        public NhanVienRepositories()
        {
        }
        public NhanVienRepositories(NhanvienContext context, DbSet<T> dbset)
        {
            this.context = context;
            this.dbset = dbset;
        }

        public bool CreateItem(T item)
        {
            try
            {
                dbset.Add(item);
                context.SaveChanges(); return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteItem(T item)
        {
            try
            {
                dbset.Remove(item);
                context.SaveChanges(); return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<T> GetAllItem()
        {
            return dbset.ToList();
        }
        public T GetById(Guid id)
        {
            return dbset.Find(id);
        }

        public bool UpdateItem(T item)
        {
            try
            {
                dbset.Update(item);
                context.SaveChanges(); return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
