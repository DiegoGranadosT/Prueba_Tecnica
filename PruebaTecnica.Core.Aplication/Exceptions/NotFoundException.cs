using System;

namespace PruebaTecnica
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key)
            : base($"{name} ({key}) no fué encontrado")
        {
        }
    }
}
