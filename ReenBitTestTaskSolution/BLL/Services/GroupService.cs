using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(GroupModel model)
        {
            Group? mapped = _mapper.Map<Group>(model);
            await _unitOfWork.GroupRepository.AddAsync(mapped);
            await _unitOfWork.SaveAsync();

        }

        public async Task DeleteAsync(int modelId)
        {
            await _unitOfWork.GroupRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<GroupModel>> GetAllAsync()
        {
            IEnumerable<Group>? unmapped = _unitOfWork.GroupRepository.GetAll();
            return _mapper.Map<IEnumerable<GroupModel>>(unmapped);

        }

        public async Task<GroupModel> GetByIdAsync(int id)
        {
            Group? unmapped = await _unitOfWork.GroupRepository.GetByIdAsync(id);
            return _mapper.Map<GroupModel>(unmapped);

        }

        public async Task UpdateAsync(GroupModel model)
        {
            Group? mapped = _mapper.Map<Group>(model);

            _unitOfWork.GroupRepository.Update(mapped);
        }
    }
}
