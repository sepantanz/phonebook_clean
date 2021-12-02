using App.DataBase;
using App.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.EditConatct
{
    public class EditContactService : IEditConatctService
    {
        private readonly IDataBaseContext dataBaseContext;

        public EditContactService(IDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public ResultDto Execute(EditContactDto editContactDto)
        {
            var contact = dataBaseContext.Contacts.Find(editContactDto.Id);
            if (contact == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "مخاطب یافت نشد"
                };
            }

            contact.Update(editContactDto.Name, editContactDto.LastName, editContactDto.PhoneNumber,
                editContactDto.Company, editContactDto.Description);

            dataBaseContext.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "اطلاعات مخاطب با موفقیت ویرایش شد"
            };
        }
    }
}
