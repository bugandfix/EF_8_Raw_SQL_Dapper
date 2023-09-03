using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Dapper;
using EF_8_Raw_SQL_Dapper.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EF_8_Raw_SQL_Dapper
{
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class DataBaseOperations
    {
        UniverSityDBContext db;
        public DataBaseOperations()
        {
            db = new UniverSityDBContext();
        }

        [Benchmark(Baseline = true)]
        public async Task<List<Student>> GetStudents()
        {
            return await db.Students.ToListAsync();
            //return await db.Students.AsNoTracking().ToListAsync();
        }

        [Benchmark]
        public async Task<List<Student>> GetStudentsWithRawSQL()
        {
            FormattableString query = $"SELECT [ID],[Name],[Family],[Age],[Address],[Phone],[Gender] FROM [DBForDotNet8].[dbo].[Students]";
            return await db.Database.SqlQuery<Student>(query).ToListAsync();
            //return await db.Database.SqlQuery<Student>(query).AsNoTracking().ToListAsync();            
        }

        [Benchmark]
        public async Task<List<Student>> GetStudentsWithDapper()
        {
            string query = $"SELECT [ID],[Name],[Family],[Age],[Address],[Phone],[Gender] FROM [DBForDotNet8].[dbo].[Students]";
            SqlConnection DapperConnection = new SqlConnection(Infra.ConnectionString);
            var result = await DapperConnection.QueryAsync<Student>(query);
            return result.ToList();
        }
    }
}
