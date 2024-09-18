using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using ORM_Dapper;

//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection connection = new MySqlConnection(connString);

var departmentRepo = new DepartmentRepository(connection);

var departments = departmentRepo.GetAllDepartments();

foreach (var dept in departments)
{
    Console.WriteLine($"Name : {dept.Name} | ID: {dept.DepartmentID}");
    
}
var repo = new DapperProductRepository(connection);

var products = repo.GetAllProducts();

foreach (var prod in products)
{
    Console.WriteLine($"{prod.ProductID} {prod.Name}");
}
