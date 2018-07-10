using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicApp.Services.Handlers
{
    public interface IHandlerFactory {
        Dictionary<Type, Func<object, Task<object>>> GetHandlers();
    }
}