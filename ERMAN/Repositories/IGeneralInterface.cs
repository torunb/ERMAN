﻿namespace ERMAN.Repositories
{
    public interface IGeneralInterface<T, X> where T : class
    {
        void Add(X entity);

        T Remove(int id);

        T Get(int id);

        //IEnumerable<T> GetAll();

        T Update(X entity);
    }
}
