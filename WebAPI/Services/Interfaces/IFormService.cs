using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Services.Interfaces
{
    public interface IFormService
    {
        Task<List<Form>> GetAllAsync();
        Task<Form> GetById(Guid id);
        Task CreateAsync(FormDto dto);
        Task MarkAsReaded(Form form);
        Task MarkAsAnswered(Form form);
        Task Delete(Form form);
    }
}
