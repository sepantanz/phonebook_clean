using App.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.GetContactDetails
{
    public interface IGetContactDetailsService
    {
        ResultDto<GetConatctDetailsDto> Execute(int conatctId);
    }
}
