using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DataAccess;
using Microsoft.Extensions.Configuration;
using SinkingPirates.API.Models;

namespace SinkingPirates.API.DataAccess
{
    public class EntryDataAccess : BaseRepository, IEntryDataAccess
    {
        public EntryDataAccess(IConfiguration configuration) : base(configuration, "SQLite")
        {
        }

        public async Task<List<Entry>> GetAllStudentEntries(List<int> studentIds)
        {
            var query = @"SELECT * FROM Entries WHERE StudentId IN @StudentIds";
            DynamicParameters _params = new DynamicParameters(new
            {
                StudentIds = studentIds
            });

            var entries = await QueryAsync<Entry>(query, param: _params);
            return entries;
        }
    }
}
