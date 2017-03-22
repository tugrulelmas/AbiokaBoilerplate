using AbiokaBoilerplate.ApplicationService.DTOs;
using System.Collections.Generic;

namespace AbiokaBoilerplate.ApplicationService.Abstractions
{
    public interface IMenuService : ICrudService<MenuDTO>
    {
        IEnumerable<MenuDTO> Filter(string text);
    }
}