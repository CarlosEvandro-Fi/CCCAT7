﻿using ECommerce.Checkout.Infrastructure.Database;

namespace ECommerce.Checkout.Infrastructure.Database;

[Obsolete("Implementar")]
public class PgPromiseAdapter : IConnection
{
    public async Task Close()
    {
        await Task.CompletedTask;
    }

    public async Task<T> Query<T>(String statement, params Object[] parameters)
    {
        throw new NotImplementedException();
    }
}
