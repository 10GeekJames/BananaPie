using BookADatesModule.Api.Common.Interfaces;

namespace BookADatesModuleServices
{
    public class BookADatesServiceWrapperService
    {
        public IBookADatesService _roomService;
        public IBookADatesService BookADatesService { get => _roomService; set {_roomService = value;} }
    }
}