using App.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.EditConatct
{
    public interface IEditConatctService
    {
        ResultDto Execute(EditContactDto editContactDto);
    }
}
