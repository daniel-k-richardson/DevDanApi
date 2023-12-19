using AutoMapper;
using DevDanApi.Domain.Common;
using DevDanApi.Domain.Entities;

namespace DevDanApi.Features.Blogs.CreateBlog;

public class CreateBlog : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Blog, CreateBlog>().ReverseMap();
        }
    }
}
