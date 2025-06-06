using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Cliente.Migrations;

namespace  Cliente.Intrastruture.Services
{
    public class OperacaoCommandStore
    {
        private readonly Context _context;
        
        public OperacaoCommandStore(Context context)
        {
            _context = context;
        }
}
}
