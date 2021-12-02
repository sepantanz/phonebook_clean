using App.DataBase;
using App.Dto;
using Domain.Entities;

namespace App.Services.AddNewContact
{
    public class AddNewContactService : IAddNewContactService
    {
        private readonly IDataBaseContext dataBaseContext;

        public AddNewContactService(IDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public ResultDto Execute(AddNewContactDto newContact)
        {

            if (string.IsNullOrEmpty(newContact.PhoneNumber))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "شماره موبایل اجباری می باشد. لطفا شماره موبایل را هم وارد کنید"
                };
            }

            Contact contact =
                new Contact(newContact.Name, newContact.LastName, newContact.Description,
                newContact.PhoneNumber, newContact.Company);


            dataBaseContext.Contacts.Add(contact);
            dataBaseContext.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = $" مخاطب {contact.Name} {contact.LastName} با موفقیت در دیتابیس ذخیره شد",
            };
        }
    }
}
