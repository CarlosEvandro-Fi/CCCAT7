using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaLib
{
    public class Connection
    {
    }

    public class PgPromiseAdapter : Connection
    {
        public async Task Close()
        {
            await Task.CompletedTask;
        }
    }
}
