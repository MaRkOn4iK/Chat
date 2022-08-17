using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(MessageModel model)
        {
            Message? mapped = _mapper.Map<Message>(model);
            await _unitOfWork.MessageRepository.AddAsync(mapped);
            await _unitOfWork.SaveAsync();

        }

        public async Task DeleteAsync(int modelId)
        {
            await _unitOfWork.MessageRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<MessageModel>> GetAllAsync()
        {
            IEnumerable<Message>? unmapped = _unitOfWork.MessageRepository.GetAll();
            return _mapper.Map<IEnumerable<MessageModel>>(unmapped);

        }

        public async Task<MessageModel> GetByIdAsync(int id)
        {
            Message? unmapped = await _unitOfWork.MessageRepository.GetByIdAsync(id);
            return _mapper.Map<MessageModel>(unmapped);

        }

        public async Task UpdateAsync(MessageModel model)
        {
            Message? mapped = _mapper.Map<Message>(model);

            _unitOfWork.MessageRepository.Update(mapped);
        }
    }
}
