using AutoMapper;
using MediatR;
using MyGuides.Domain.Entities.Sections.Repository;
using MyGuides.Domain.Entities.Sections.Results;
using MyGuides.Notifications.Context;

namespace MyGuides.Domain.Entities.Sections.Commands.AddSection
{
    public class AddSectionCommandHandler : IRequestHandler<AddSectionCommand, SectionResult>
    {
        private readonly IMapper _mapper;
        private readonly ISectionRepository _sectionRepository;
        private readonly INotificationService _notificationService;

        public AddSectionCommandHandler(IMapper mapper, ISectionRepository sectionRepository, INotificationService notificationService)
        {
            _mapper = mapper;
            _sectionRepository = sectionRepository;
            _notificationService = notificationService;
        }


        public Task<SectionResult> Handle(AddSectionCommand request, CancellationToken cancellationToken)
        {
            //validar se as conquistas não estão em outra seção

            //buscar as conquistas pelo id
            //salvar a seção
            //atualizar o sectionId das conquistas
            //atualizar as conquistas
            //no retorno, devolver 201
            throw new NotImplementedException();
        }
    }
}
