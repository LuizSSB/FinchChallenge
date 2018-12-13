using FinchBackend.ServiceModel;
using FinchBackend.ServiceModel.Types;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Linq;

namespace FinchBackend.ServiceInterface
{
    // [Authenticated]
    public class SearchServices : Service
    {
        public IDbConnectionFactory DbConnection { get; set; }
        const double Sigma = 9e-3;

        public SearchProtestsResponse Get(SearchProtests request)
        {
            using(var db = DbConnection.Open())
            {
                var query = db.From<PaymentProtest>()
                    .Join<PaymentProtest, Payment>()
                    .Join<Payment, Debtor>()
                    .Limit(request.Offset, request.Limit);

                if (request.MinimumProtestValue.HasValue)
                {
                    query = query.Where(pp => pp.Value >= request.MinimumProtestValue.Value);
                }

                if (request.MaximumProtestValue.HasValue)
                {
                    query = query.Where(pp => pp.Value <= request.MaximumProtestValue.Value);
                }

                if (request.BankId.HasValue)
                {
                    query = query.Where<Payment>(p => p.BankId == request.BankId.Value);
                }

                if (!string.IsNullOrEmpty(request.DebtorName))
                {
                    var debtorName = request.DebtorName.ToLower();
                    query = query.Where<Debtor>(d => d.Name.ToLower().Contains(debtorName));
                }

                return new SearchProtestsResponse
                {
                    Protests = db.SelectMulti<PaymentProtest, Payment, Debtor>(query)
                        .Select(t => {
                            t.Item2.Debtor = t.Item3;
                            t.Item1.Payment = t.Item2;
                            return t.Item1;
                        })
                        .ToList()
                };
            }
        }

        public GetProtestResponse Get(GetProtest request)
        {
            using(var db = DbConnection.Open())
            {
                var protest = db.SingleById<PaymentProtest>(request.InternalId);
                protest.Payment = db.SingleById<Payment>(protest.PaymentTitleNumber);
                protest.Payment.Debtor = db.SingleById<Debtor>(protest.Payment.DebtorDocument);
                return new GetProtestResponse { Protest = protest };
            }
        }
    }
}
