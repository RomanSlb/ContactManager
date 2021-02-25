using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class CSVUser
    {
        [Index(0)]
        public string Name { get; set; }
        [Index(1)]
        public DateTime DateOfBirth { get; set; }
        [Index(2)]
        public bool Married { get; set; }
        [Index(3)]
        public string Phone { get; set; }
        [Index(4)]
        public decimal Salary { get; set; } 

    }
}
