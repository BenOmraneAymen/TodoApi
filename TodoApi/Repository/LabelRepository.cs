using TodoApi.Models;
using TodoApi.Data;
using TodoApi.Interface;
using Microsoft.EntityFrameworkCore;
using TodoApi.DTO;

namespace TodoApi.Repository
{
    public class LabelRepository : ILabelRepository
    {
        private readonly DataContext _context;
        public LabelRepository(DataContext context)
        {
            this._context = context;
        }
        public ICollection<Label> GetLabels()
        {
            return _context.Labels.ToList();
        } 

        public async Task<Label> GetLabelById(int id)
        {
            return await _context.Labels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Label> CreateLabel(LabelDto labelDto)
        {
            Label label = new Label
            {
                Name = labelDto.Name,
                Description = labelDto.Description,
            };
            await _context.Labels.AddAsync(label);
            _context.SaveChanges();
            return label;
        }

        public async Task<Label> UpdateLabel(int id,LabelDto label)
        {
            Label oldLabel = await _context.Labels.FirstOrDefaultAsync(x=> x.Id == id);
            if (oldLabel != null)
            {
                oldLabel.Name = label.Name;
                oldLabel.Description = label.Description;
                await  _context.SaveChangesAsync();
            }

            return oldLabel;
        }

        public async Task<Label> DeleteLabel(int id)
        {
            Label oldLabel = await _context.Labels.FirstOrDefaultAsync(y => y.Id == id);

            if(oldLabel != null)
            {
            _context.Labels.Remove(oldLabel);
            await _context.SaveChangesAsync();
            }
            return oldLabel;
        }
    }
}
