using App.DataBase;
using App.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.GetContactDetails
{
    public class GetContactDetailsService : IGetContactDetailsService
    {
        private readonly IDataBaseContext dataBaseContext;

        public GetContactDetailsService(IDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public ResultDto<GetConatctDetailsDto> Execute(int id)
        {
            var contact = dataBaseContext.Contacts.Find(id);
            if (contact == null)
            {
                return new ResultDto<GetConatctDetailsDto>()
                {
                    IsSuccess = false,
                    Message = "مخاطب یافت نشد.",
                    Data = null
                };
            }

            var data = new GetConatctDetailsDto
            {
                Id = id,
                Name = contact.Name,
                LastName = contact.LastName,
                Company = contact.Company,
                Description = contact.Description,
                PhoneNumber = contact.PhoneNumber,
                CreateAt = contact.CreateAt
            };

            return new ResultDto<GetConatctDetailsDto>
            {
                Data = data,
                IsSuccess = true
            };
        }
    }
}
