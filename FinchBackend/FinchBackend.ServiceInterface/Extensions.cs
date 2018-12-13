using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinchBackend.ServiceInterface
{
    public static class Extensions
    {
        public static void InsertOrReplace<T>(this System.Data.IDbConnection db, T poco)
        {
            try
            {
                db.Insert(poco);
            }
            catch
            {
                db.Update(poco);
            }
        }
    }
}
