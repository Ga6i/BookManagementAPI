using BookManagerApp.DTO.v1;

namespace BookManagerApp.DTO.v2
{
    public class RestDTO<T> 
    {
        public T Data { get; set; } = default!;
        public List<LinkDTO> Links { get; internal set; }
    }
}
