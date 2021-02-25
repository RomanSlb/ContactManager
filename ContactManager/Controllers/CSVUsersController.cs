using ContactManager.Models;
using CsvHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    public class CSVUsersController : Controller
    {
        [HttpGet]
        public IActionResult Index(List<CSVUser> cSVUsers = null)
        {
            cSVUsers = cSVUsers == null ? new List<CSVUser>() : cSVUsers;
            return View(cSVUsers);
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            var cSVUsers = this.GetCSVUserList(file.FileName);

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    while (reader.Peek() >= 0)
                    {
                        String textRow = reader.ReadLine();

                        if (textRow.Contains("Name"))
                        {
                            continue;
                        }

                        String[] arrayData = textRow.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        bool.TryParse(arrayData[2], out bool isMarried);
                        DateTime.TryParse(arrayData[1], out DateTime dateTime);
                        decimal.TryParse(arrayData[4], out decimal decimalData);



                        cSVUsers.Add(new CSVUser
                        {
                            Name = arrayData[0],
                            DateOfBirth = dateTime,
                            Married = isMarried,
                            Phone = arrayData[3],
                            Salary = decimalData
                        });

                   /*     CSVUser csvUser = new CSVUser
                        {
                            Name = arrayData[0],
                            DateOfBirth = dateTime,
                            Married = isMarried,
                            Phone = arrayData[3],
                            Salary = decimalData
                        };
                   */
                     //   db.CSVUsers.AddRange(cSVUsers);


                    }

                }
            }
            return Index(cSVUsers);
        }
             private List<CSVUser> GetCSVUserList(string fileName)
             {
                 List<CSVUser> cSVUsers = new List<CSVUser>();
                 return cSVUsers;
             }

        }

    }
        
      
