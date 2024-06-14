using Crud.Db;
using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Dao;

public class Generics<T> where T : class
{
    protected CrudContext Context { get; }

    public Generics(CrudContext context)
    {
        Context = context;
    }

    public void OnCreate(T obj)
    {
        Context.Set<T>().Add(obj);
        Context.SaveChanges();
    }

    public IEnumerable<T> ListAll()
    {
        return Context.Set<T>().ToList();
    }
    public T? GetBy(Func<T, bool> condition)
    {
        return Context.Set<T>().FirstOrDefault(condition);
    }

    public void OnUpdate(T obj)
    {
        Context.Set<T>().Update(obj);
        Context.SaveChanges();
    }
    public void OnDelete(T obj)
    {
        Context.Set<T>().Remove(obj);
        Context.SaveChanges();
    }
}
