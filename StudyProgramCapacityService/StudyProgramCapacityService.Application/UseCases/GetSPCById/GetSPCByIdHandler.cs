using MediatR;

namespace StudyProgramCapacityService.Application.UseCases.GetSPCById
{
    internal class GetSPCByIdHandler(ISPCManager capacityManager, GetSPCByIdMapper mapper) : IRequestHandler<GetSPCByIdRequest, GetSPCByIdResponse>
    {
        public async Task<GetSPCByIdResponse> Handle(GetSPCByIdRequest request, CancellationToken cancellationToken)
        {;
            var capacity = await capacityManager.Get(request.Id) ?? throw new StudyProgramCapacityNotFoundException();
            return mapper.Map(capacity,request.Id);
        }
    }
}
