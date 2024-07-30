using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.models
{
    public record Todo (Guid Id, string Title, bool Done);
  

}