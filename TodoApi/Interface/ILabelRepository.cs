using TodoApi.DTO;
using TodoApi.Models;

namespace TodoApi.Interface
{
    public interface ILabelRepository
    {
        ICollection<Label> GetLabels();
        Task<Label> GetLabelById(int id);
        Task<Label> CreateLabel(LabelDto labelDto);
        Task<Label> UpdateLabel(int id,LabelDto labelDto);
        Task<Label> DeleteLabel(int id);
    }
}
