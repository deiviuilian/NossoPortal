using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NossoPortal
{
    public class Conexao : IDisposable
    {
        public NpgsqlConnection Connection { get; set; }

        public Conexao()
        {
            Connection = new NpgsqlConnection("Server=localhost;Database=nossoportal;User Id=postgres;Password=Dev040404@;");
            Connection.Open();
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
        
    }
}

