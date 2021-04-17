using ComputersApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputersApi.Models
{
    public class Computer
    {
        public string Id { get; set; }
        public ComputerType ComputerType { get; set; }
        public string Brand { get; set; }
        public string Processor { get; set; }
    }
}
