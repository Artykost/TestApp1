using System;
using System.Collections.Generic;
using TestApp1.Domain.Entity;

namespace TestApp1
{
    public class UserStatistics
    {
        public Guid Query { get; set; }
        public int Percent { get; set; }
        public Result Result { get; set; }
    }
}
