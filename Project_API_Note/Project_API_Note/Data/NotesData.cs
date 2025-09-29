using Microsoft.AspNetCore.Mvc;
using Project_API_Note.DataModel;
using Project_API_Note.Dto;

namespace Project_API_Note.Data
{
    public static class NotesData
    {
        public static List<NotesDto> List(NotesFilterDataModel filter, ApplicationDbContext _db)
        {
            var list = _db.LSNOTEs.ToList();
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

    }
}
