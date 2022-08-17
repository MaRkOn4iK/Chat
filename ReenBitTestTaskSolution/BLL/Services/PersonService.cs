using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PersonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(PersonModel model)
        {
            Person? mapped = _mapper.Map<Person>(model);
            await _unitOfWork.PersonRepository.AddAsync(mapped);
            await _unitOfWork.SaveAsync();

        }

        public async Task DeleteAsync(int modelId)
        {
            await _unitOfWork.PersonRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PersonModel>> GetAllAsync()
        {
            IEnumerable<Person>? unmapped = _unitOfWork.PersonRepository.GetAll();
            return _mapper.Map<IEnumerable<PersonModel>>(unmapped);

        }

        public async Task<PersonModel> GetByIdAsync(int id)
        {
            Person? unmapped = await _unitOfWork.PersonRepository.GetByIdAsync(id);
            return _mapper.Map<PersonModel>(unmapped);

        }

        public async Task UpdateAsync(PersonModel model)
        {
            Person? mapped = _mapper.Map<Person>(model);

            _unitOfWork.PersonRepository.Update(mapped);
        }
    }
}
