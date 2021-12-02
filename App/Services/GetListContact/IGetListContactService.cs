using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.GetListContact
{
    public interface IGetListContactService
    {
        List<ContactListDto> Execute(string searchKey=null);
    }
}
