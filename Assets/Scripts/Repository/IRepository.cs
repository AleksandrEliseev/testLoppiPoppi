using System;
using System.Collections.Generic;

namespace Repository
{
    public interface IRepository
    {
      void SaveStringValue(string key, string value);
      string LoadStringValue(string key, string defaultValue = "");
    }

}