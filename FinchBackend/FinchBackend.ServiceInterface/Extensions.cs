using ServiceStack;
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
        public static long InsertOrReplace<T>(this System.Data.IDbConnection db, T poco, Service service)
            where T : ServiceModel.Types.BaseEntity
        {
            try
            {
                return db.Insert(poco.Prepare(service));
            }
            catch
            {
                return db.Update(poco.Prepare(service));
            }
        }

        static long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long) timeSpan.TotalSeconds;
        }

        public static T Prepare<T>(this T poco, Service service) where T : ServiceModel.Types.BaseEntity
        {
            var session = service.GetSession();
            poco.OwnerId = session.UserAuthId;
            
            if (poco.CreatedTimestamp.HasValue)
            {
                poco.UpdatedTimestamp = UnixTimeNow();
            }
            else
            {
                poco.CreatedTimestamp = UnixTimeNow();
            }

            return poco;
        }
    }
}
