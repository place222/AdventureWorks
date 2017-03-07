using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities.Person;

namespace DAL.Repositories
{
    public interface IContactTypeRepository
    {
        Task<IEnumerable<ContactType>> GetContactTypeAsync();
        Task AddContactTypeAsync(ContactType entity);
        Task UpdateContactTypeAsync(ContactType entity);
        Task DeleteContactTypeAsync(ContactType entity);
    }
}
