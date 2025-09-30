using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API_Note.DataModel.Notes;
using Project_API_Note.Dto;
using Project_API_Note.Model;

namespace Project_API_Note.Data
{
    public static class NotesData
    {
        public static async Task<List<NotesDto>> List(NotesFilterDataModel filter, ApplicationDbContext _db)
        {
            var list = await _db.LSNOTEs.ToListAsync();
            return list.Select(s =>
            new NotesDto()
            {
                Id = s.ID,
                Content = s.CONTENT,
                Title = s.TITLE,
                CreatedAt = s.CREATED_AT,
                UpdatedAt = s.UPDATED_AT
            }).ToList();
        }
        public static async Task<NotesDto> Create(NotesDataModel model, ApplicationDbContext _db)
        {
            var data = new LSNOTE();
            data.TITLE = model.Title;
            data.CONTENT = model.Content;
            data.CREATED_AT = DateTime.Now;
            _db.LSNOTEs.Add(data);
            await _db.SaveChangesAsync();
            return MappingData(data);
        }
        public static async Task<NotesDto> Update(NotesDataModel model, ApplicationDbContext _db)
        {
            var data = await _db.LSNOTEs.FirstOrDefaultAsync(s => s.ID == model.Id);
            data.TITLE = model.Title;
            data.CONTENT = model.Content;
            data.UPDATED_AT = DateTime.Now;
            await _db.SaveChangesAsync();
            return MappingData(data);
        }
        public static async Task<bool> Delete(Guid id, ApplicationDbContext _db)
        {
            var data = await _db.LSNOTEs.FirstOrDefaultAsync(s => s.ID == id);
            _db.LSNOTEs.Remove(data);
            await _db.SaveChangesAsync();
            return true;
        }

        private static NotesDto MappingData(LSNOTE obj)
        {
            var data = new NotesDto();
            data.Id = obj.ID;
            data.Content = obj.CONTENT;
            data.Title = obj.TITLE;
            data.CreatedAt = obj.CREATED_AT;
            data.UpdatedAt = obj.UPDATED_AT;
            return data;
        }

    }
}
