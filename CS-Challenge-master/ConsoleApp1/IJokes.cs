using System;
using System.Collections.Generic;
using System.Text;

namespace JokeGenerator
{
    interface IJokes
    {
         int GetNumberOfJokes();
         bool IsRandomNameSelected();
         Tuple<string, string> GetName();
    }
}
