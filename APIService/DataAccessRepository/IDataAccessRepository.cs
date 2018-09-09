using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIService.Models;

namespace APIService.DataAccessRepository
{
    public interface IDataAccessRepository
    {
        string LoadJsonFromFile(string value);
    }
}
