using App.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.AddNewContact
{
    public interface IAddNewContactService
    {
        ResultDto Execute(AddNewContactDto addNewContactDto);
    }
}
