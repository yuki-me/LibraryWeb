using AutoMapper;
using LibraryWebAPI.Dto;
using LibraryWebAPI.Model;

namespace LibraryWebAPI.Helper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Books, BooksDto>();
            CreateMap<BooksDto, Books>();
            CreateMap<IssueBook, IssueBookDto>();
            CreateMap<IssueBookDto, IssueBook>();
            CreateMap<ReturnBook, ReturnBookDto>();
            CreateMap<ReturnBookDto, ReturnBook>();
            CreateMap<Status, StatusDto>();
            CreateMap<StatusDto, Status>();
            CreateMap<Students, StudentsDto>();
            CreateMap<StudentsDto, Students>();
            CreateMap<Users, UsersDto>();
            CreateMap<UsersDto, Users>();
        }
    }
}
