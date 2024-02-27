using CryptoPro.Adapter.CryptCP;
using CryptoPro.Adapter.CryptCP.Types;
using SSP_API.Types.Xsd;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace SSP_API.Tests
{
    public class SspClientTests
    {
        readonly ISspClient _client = default!;

        public SspClientTests() 
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var certificates = new X509Certificate2Collection();

            using (var myCertsStore = new X509Store(
                storeName: StoreName.My,
                storeLocation: StoreLocation.CurrentUser))
            {
                myCertsStore.Open(OpenFlags.ReadOnly);

                certificates.Add(
                    myCertsStore.Certificates
                    .Where(cert => cert.Thumbprint == "75A164E52AF7AA241D8DB68D1266F6E90B95DC3C")
                    .FirstOrDefault()!);

                myCertsStore.Close();
            }

            var cryptCP = new CryptCP(
                    new CryptCpConfiguration(@"C:\Service\CRYPTCP.x64.EXE"));

            _client = new SspClient(
                new SspClientOptions(
                    clientCertificates: certificates,
                    testApi: true),
                cryptCP);
        }

        static SspRequest GetSspRequest()
        {
            var guid = Guid.NewGuid().ToString();

            var sspRequest = new SspRequest(
                requestId: guid,
                abonent: new AbonentSspRequest()
                {
                    LegalEntity = new AbonentSspRequestInfoLegalEntity()
                    {
                        Inn = "0000000000",
                        Ogrn = "111111111111"
                    }
                },
                request: new RequestSspInfo(
                    source: new SourceInfoRequest()
                    {
                        LegalEntitySource = new LegalEntitySource()
                        {
                            Inn = "0000000000",
                            Ogrn = "111111111111",
                            FullName = "ЗАКРЫТОЕ АКЦИОНЕРНОЕ ОБЩЕСТВО \"ПЕТРУШКА\"",
                            AbbreviatedName = "ЗАО \"ПЕТРУШКА\"",
                            UserType = CreditHistoryUserType.Item2
                        }
                    },
                    subject: new SubjectInfo(
                        fullNames: [new(
                            lastName: "Иванов",
                            name: "Иван",
                            middleName: "Иванович")],
                        identityDocuments: [new(
                            series: "0000",
                            number: "000000",
                            dateIssue: new DateTime(1989, 12, 27),
                            citizen: "643",
                            codeIdentityDocument: IdentityDocumentType.Item21)],
                        birthDate: new DateTime(1970, 1, 1)),
                    consent: new ConsentInfo()
                    {
                        Granted = new ConsentGranted()
                        {
                            LegalEntity = new LegalEntityInfo()
                            {
                                Fullname = "ЗАКРЫТОЕ АКЦИОНЕРНОЕ ОБЩЕСТВО \"ПЕТРУШКА\"",
                                Inn = "0000000000",
                                Ogrn = "111111111111"
                            }
                        },
                        DateIssue = new DateTime(2024, 1, 1),
                        ConsentExpiration = ConsentExpirationType.Item3,
                        BasisTransfer = GroundTransferringConsentAssigneeType.Item1,
                        Contract = new ConsentAgreement(new DateTime(2024, 1, 1)),
                        Hash = "782ab733efff636352635261faee32236af3263cb2b340986ba635239834fcef",
                        Purpose = [new(TargetCodeType.Item1)]
                    },
                    purposes: [new(TargetCodeType.Item1)],
                    amountObligations: new AmountObligations(
                        value: 20000,
                        currency: Types.Enums.CurrencyType.RUB)),
                requestType: RequestPaymentsInfoRequestType.OneBureau);


            return sspRequest;
        }

        [Fact]
        public async void SendRequest()
        {
            var sspRequest = GetSspRequest();

            var directory = $@"C:\Ssp\OUT\{sspRequest.RequestId}";

            Directory.CreateDirectory(directory);

            var requestResult = await _client.SendRequestAsync(
                sspRequest, 
                directoryToSaveFiles: directory,
                signCriterias: new CriteriasSearchCertificates(
                    thumbprint: "75a124e52af7ea241d8db60d7347f7e85b96df3c"),
                verifySignCriterias: new CriteriasSearchCertificates(
                    storeName: StoreName.AddressBook,
                    thumbprint: "1073a6e390a3faa29de75f6a68cca19e7e2f6a22"));

            Assert.NotNull(requestResult);
            Assert.Equal(
                expected: sspRequest.RequestId,
                actual: requestResult.RequestId.RequestId);
        }

        [Fact]
        public async void GetAnswer()
        {
            var answerId = "494722a1-703d-4079-8d71-edc3051e6057";

            var directory = $@"C:\Ssp\IN\{answerId}";

            Directory.CreateDirectory(directory);

            var sspInfo = await _client.GetAnswerAsync(
                answerId,
                directoryToSaveFiles: directory,
                verifySignCriterias: new CriteriasSearchCertificates(
                    storeName: StoreName.AddressBook,
                    thumbprint: "1073a6e390a3faa29de75f6a68cca19e7e2f6a22"));

            Assert.NotNull(sspInfo);
            Assert.Equal(answerId, sspInfo.AnswerId);
        }
    }
}
