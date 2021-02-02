using Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Certifications.Queries.IssueCertificate
{
    public class IssueCertificateQuery : IRequest<IssueCertificateQueryVm>
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PeselNumber { get; set; }
        public string CertificateType { get; set; }
        public string SexType { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
