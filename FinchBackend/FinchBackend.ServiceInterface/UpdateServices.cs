using FinchBackend.ServiceModel;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace FinchBackend.ServiceInterface
{
    [Authenticate]
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
                        db.InsertOrReplace(request.Protest.Payment.Debtor, this);
                    }

                    db.InsertOrReplace(request.Protest.Payment, this);
                }

                db.Update(request.Protest.Prepare(this));
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
