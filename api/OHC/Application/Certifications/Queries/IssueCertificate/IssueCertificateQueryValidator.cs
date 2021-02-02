using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Certifications.Queries.IssueCertificate
{
    public class IssueCertificateQueryValidator : AbstractValidator<IssueCertificateQuery>
    {
        public IssueCertificateQueryValidator()
        {
            RuleFor(ic => ic.Name).NotEmpty();
            RuleFor(ic => ic.PositionName).NotEmpty();
            RuleFor(ic => ic.Surname).NotEmpty();
            RuleFor(ic => ic.PositionId).NotEmpty();
            RuleFor(ic => ic.SexType).NotEmpty();
            RuleFor(ic => ic.CertificateType).NotEmpty();
            RuleFor(ic => ic.HouseNumber).NotEmpty();
            RuleFor(ic => ic.City).NotEmpty();
            RuleFor(ic => ic.Street).NotEmpty();
        }
    }
}
