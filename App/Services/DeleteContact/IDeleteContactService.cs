using App.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.DeleteContact
{
    public interface IDeleteContactService
    {
        ResultDto Execute(int contactId);
    }
}
