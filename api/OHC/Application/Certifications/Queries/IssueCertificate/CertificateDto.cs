using Domain.Enums;
using System.Collections.Generic;

namespace Application.Certifications.Queries.IssueCertificate
{
    public class CertificateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PeselNumber { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public CertificateTypeEnum CertificateType{ get; set; }
        public SexTypeEnum SexType { get; set; }
        public string PositionName { get; set; }
        public string Description { get; set; }
        public Dictionary<FactorTypeEnum, List<string>> Factors { get; set; }
    }
}
