using App.DataBase;
using App.Dto;

namespace App.Services.DeleteContact
{
    public class DeleteContactService : IDeleteContactService
    {
        private readonly IDataBaseContext dataBaseContext;

        public DeleteContactService(IDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public ResultDto Execute(int contactId)
        {
            var contact = dataBaseContext.Contacts.Find(contactId);
            if (contact != null)
            {
                dataBaseContext.Contacts.Remove(contact);
                dataBaseContext.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "مخاطب با موفقیت حذف شد."
                };
            }
            return new ResultDto
            {
                IsSuccess = false,
                Message = "مخاطب یافت نشد"
            };
        }
    }
}
