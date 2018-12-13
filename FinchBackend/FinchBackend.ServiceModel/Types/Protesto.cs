using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinchBackend.ServiceModel.Types
{
    public class Protesto
    {
        public long CodigoBanco { get; set; }
        public long CodigoInterno { get; set; }
        public string NomeCredor { get; set; }
        public long NumeroTitulo { get; set; }
        public int Parcela { get; set; }
        public string NomeDevedor { get; set; }
        public string CPF_CNPJ_Devedor { get; set; }
        public string Endereco_Devedor { get; set; }
        public string Bairro_Devedor { get; set; }
        public string Cidade_Devedor { get; set; }
        public string CEP_Devedor { get; set; }
        public string UF_Devedor { get; set; }
        public string Cidade_Praca_Pagamento { get; set; }
        public string UF_Praca_Pagamento { get; set; }
        public string ValorTitulo { get; set; }
        public string ValorProtestar { get; set; }
        public string DataEmissao { get; set; }
        public string DataVencimento { get; set; }
        public string TipoDocumento { get; set; }
        public string Operacao { get; set; }
        public string Valor1Parcela { get; set; }
        public int? QtdeParcelaContrato { get; set; }

        static readonly CultureInfo SystemCulture = new CultureInfo("pt-BR");
        static double DoubleFromString(string value)
        {
            return Convert.ToDouble(value, SystemCulture);
        }

        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        static long TimestampFromString(string value)
        {
            var date = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            TimeSpan elapsedTime = date - Epoch;
            return (long) elapsedTime.TotalSeconds;
        }

        public PaymentProtest ToInternalStructure() => new PaymentProtest
        {
            InternalId = CodigoInterno,
            Value = DoubleFromString(ValorProtestar),
            PaymentTitleNumber = NumeroTitulo,
            Payment = new Payment
            {
                BankId = CodigoBanco,
                Value = DoubleFromString(ValorTitulo),
                City = Cidade_Praca_Pagamento,
                CreditorName = NomeCredor,
                DocumentType = TipoDocumento,
                EmissionDateTimestamp = TimestampFromString(DataEmissao),
                ExpirationDateTimestamp = TimestampFromString(DataVencimento),
                FirstInstallmentValue = string.IsNullOrEmpty(Valor1Parcela)
                    ? null : (double?) DoubleFromString(Valor1Parcela),
                NumberOfInstallments = QtdeParcelaContrato,
                Operation = Operacao,
                StateCode = UF_Praca_Pagamento,
                TitleNumber = NumeroTitulo,
                DebtorDocument = CPF_CNPJ_Devedor,
                Debtor = new Debtor
                {
                    Address = Endereco_Devedor,
                    StateCode = UF_Devedor,
                    Document = CPF_CNPJ_Devedor,
                    City = Cidade_Devedor,
                    Name = NomeDevedor,
                    Neighborhood = Bairro_Devedor,
                    ZipCode = CEP_Devedor
                }
            }
        };
    }
}
