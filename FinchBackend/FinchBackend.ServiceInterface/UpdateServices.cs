using FinchBackend.ServiceModel;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinchBackend.ServiceInterface
{
    // [Authenticated]
    public class UpdateServices : Service
    {
        public IDbConnectionFactory DbConnection { get; set; }

        public void Put(UpdateProtest request)
        {
            using (var db = DbConnection.Open())
            {
                if (request.UpdatesReferences && request.Protest.Payment != null)
                {
                    if (request.Protest.Payment.Debtor != null)
                    {
                        db.InsertOrReplace(request.Protest.Payment.Debtor);
                    }

                    db.InsertOrReplace(request.Protest.Payment);
                }

                db.Update(request.Protest);
            }
        }

        public void Put(UpdatePayment request)
        {
            using (var db = DbConnection.Open())
            {
                db.Update(request.Payment);
            }
        }

        public void Put(UpdateDebtor request)
        {
            using (var db = DbConnection.Open())
            {
                db.Update(request.Debtor);
            }
        }
    }
}
