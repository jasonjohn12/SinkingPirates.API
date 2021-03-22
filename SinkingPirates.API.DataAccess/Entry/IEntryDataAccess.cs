using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SinkingPirates.API.Models;

namespace SinkingPirates.API.DataAccess
{
    public interface IEntryDataAccess
    {
        Task<List<Entry>> GetAllStudentEntries(List<int> StudentIds);
    }
}
