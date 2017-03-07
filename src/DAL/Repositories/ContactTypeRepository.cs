using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities.Person;

namespace DAL.Repositories
{
    public class ContactTypeRepository : IContactTypeRepository
    {
        public Task<IEnumerable<ContactType>> GetContactTypeAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddContactTypeAsync(ContactType entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateContactTypeAsync(ContactType entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteContactTypeAsync(ContactType entity)
        {
            throw new NotImplementedException();
        }
    }
}
