﻿using Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        //IDbContextTransaction : EntityFrameworkCore kütüphanesine ihtiyaç vardır.
        Task<IDbContextTransaction> BeginTransactionAsync();
        public IProductResository ProductRepository { get; }
    }
}
