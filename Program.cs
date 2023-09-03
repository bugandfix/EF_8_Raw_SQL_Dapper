using BenchmarkDotNet.Running;
using EF_8_Raw_SQL_Dapper;
using EF_8_Raw_SQL_Dapper.Model;
using Microsoft.EntityFrameworkCore;

var StringSplitBenchmark = BenchmarkRunner.Run<DataBaseOperations>();

//UniverSityDBContext db = new UniverSityDBContext();
//var xxxx= await db.Students.ToListAsync();

//var cn = xxxx.Count;
//Console.WriteLine(cn);




