using Core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class DBFactory
    {
        public static ProfileViewerDBContext GetDB()
        {
            return new ProfileViewerDBContext();
        }
    }
}
