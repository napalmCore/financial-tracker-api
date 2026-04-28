using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ITransactionTypeService
    {
        Task<bool> TransactionTypeExists(int typeId);
    }
}
