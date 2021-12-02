using App.DataBase;
using System.Collections.Generic;
using System.Linq;

namespace App.Services.GetListContact
{
    public class GetListContactService : IGetListContactService
    {
        private readonly IDataBaseContext dataBaseContext;

        public GetListContactService(IDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public List<ContactListDto> Execute(string searchKey=null)
        {
            var contactQuery = dataBaseContext.Contacts.AsQueryable();

            if (!string.IsNullOrEmpty(searchKey))
            {
                contactQuery = contactQuery.Where(x => x.Name.Contains(searchKey)
                || x.LastName.Contains(searchKey)
                || x.PhoneNumber.Contains(searchKey)
                ||x.Company.Contains(searchKey));
            }

            var contacts = contactQuery.Select(x => new ContactListDto
            {
                Id = x.Id,
                FullName = $"{x.Name} {x.LastName}",
                PhoneNumber = x.PhoneNumber
            }).ToList();

            return contacts;
        }
    }
}
