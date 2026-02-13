using AutoMapper;
using PostLikeService.Domain;
using Shared.Events.PostLikeService;

namespace PostLikeService.Application.UseCases.DislikePosts
{
    internal class DislikePostsMapper : Profile
    {
        public DislikePostsMapper()
        {
            CreateMap<PostLike, PostDislikedEvent>()
                .ForCtorParam("UserId", x => x.MapFrom(x => x.Id.UserId))
                .ForCtorParam("PostId", x => x.MapFrom(x => x.Id.PostId));
        }
    }
}
