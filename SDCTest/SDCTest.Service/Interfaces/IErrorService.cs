using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDCTest.Model.Models;

namespace SDCTest.Service.Interfaces
{
    public interface IErrorService
    {
        void Create(Error error);
        void Save();
    }
}
