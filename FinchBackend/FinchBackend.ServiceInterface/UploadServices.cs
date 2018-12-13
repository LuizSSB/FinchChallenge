using FinchBackend.ServiceModel;
using FinchBackend.ServiceModel.Types;
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
    [Authenticate]
    public class UploadServices : Service
    {
        public IDbConnectionFactory DbConnection { get; set; }

        public void Post(ProtestFileUpload request)
        {
            var fixedContents = "\"" +
                request.TextContents.Trim()
                    .Replace("	", "\"	\"")
                    .Replace("\n", "\"\n\"") +
                "\"";
            var rawData = ServiceStack.Text.CsvSerializer.DeserializeFromString<List<Protesto>>(fixedContents);
            var transformedData = rawData.Select(d => d.ToInternalStructure());

            using (var db = DbConnection.Open())
            {
                foreach (var protest in transformedData)
                {
                    db.InsertOrReplace(protest.Payment.Debtor, this);
                    db.InsertOrReplace(protest.Payment, this);
                    db.InsertOrReplace(protest, this);
                }
            }
        }
    }
}
