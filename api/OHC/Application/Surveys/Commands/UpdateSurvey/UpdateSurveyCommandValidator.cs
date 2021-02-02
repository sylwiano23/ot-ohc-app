using Domain.Enums;
using FluentValidation;

namespace Application.Surveys.Commands.UpdateSurvey
{
    public class UpdateSurveyCommandValidator : AbstractValidator<UpdateSurveyCommand>
    {
        public UpdateSurveyCommandValidator()
        {
            RuleFor(p => p.FactorName).NotEmpty();
            RuleFor(p => p.FactorType).NotEmpty();
            RuleFor(p => p.Date).NotEmpty();
            RuleFor(p => p.Place).NotEmpty();
            RuleFor(p => p.Result).NotEmpty();
            RuleFor(p => p.Position).NotEmpty();

            //Chemical
            RuleFor(p => p.Interpretation).NotEmpty().When(p => p.FactorType == FactorTypeEnum.Chemical.ToString());
            RuleFor(p => p.Performer).NotEmpty().When(p => p.FactorType == FactorTypeEnum.Chemical.ToString());

            // Biological
            RuleFor(p => p.IdentificationSurveyMethod).NotEmpty().When(p => p.FactorType == FactorTypeEnum.Biological.ToString());
            RuleFor(p => p.MarkedParameter).NotEmpty().When(p => p.FactorType == FactorTypeEnum.Biological.ToString());
            RuleFor(p => p.DescriptionSurveyMethod).NotEmpty().When(p => p.FactorType == FactorTypeEnum.Biological.ToString());

            // Dust
            RuleFor(p => p.NormValue).NotEmpty().When(p => p.FactorType == FactorTypeEnum.Dust.ToString());
            RuleFor(p => p.Interpretation).NotEmpty().When(p => p.FactorType == FactorTypeEnum.Dust.ToString());
            RuleFor(p => p.Performer).NotEmpty().When(p => p.FactorType == FactorTypeEnum.Dust.ToString());

            //Physical
            RuleFor(p => p.NormValue).NotEmpty().When(p => p.FactorType == FactorTypeEnum.Physical.ToString());
            RuleFor(p => p.Interpretation).NotEmpty().When(p => p.FactorType == FactorTypeEnum.Physical.ToString());
            RuleFor(p => p.Performer).NotEmpty().When(p => p.FactorType == FactorTypeEnum.Physical.ToString());

            // Elektromagnetic field
            RuleFor(p => p.RiskZoneE).NotEmpty().When(p => p.FactorType == FactorTypeEnum.ElectromagneticField.ToString());
            RuleFor(p => p.RiskZoneH).NotEmpty().When(p => p.FactorType == FactorTypeEnum.ElectromagneticField.ToString());
            RuleFor(p => p.DengerousZoneE).NotEmpty().When(p => p.FactorType == FactorTypeEnum.ElectromagneticField.ToString());
            RuleFor(p => p.DengerousZoneH).NotEmpty().When(p => p.FactorType == FactorTypeEnum.ElectromagneticField.ToString());
            RuleFor(p => p.IntermediateZoneE).NotEmpty().When(p => p.FactorType == FactorTypeEnum.ElectromagneticField.ToString());
            RuleFor(p => p.IntermediateZoneH).NotEmpty().When(p => p.FactorType == FactorTypeEnum.ElectromagneticField.ToString());
            RuleFor(p => p.Exposure).NotEmpty().When(p => p.FactorType == FactorTypeEnum.ElectromagneticField.ToString());
            RuleFor(p => p.DeviceKind).NotEmpty().When(p => p.FactorType == FactorTypeEnum.ElectromagneticField.ToString());
            RuleFor(p => p.Device).NotEmpty().When(p => p.FactorType == FactorTypeEnum.ElectromagneticField.ToString());
            RuleFor(p => p.Interpretation).NotEmpty().When(p => p.FactorType == FactorTypeEnum.ElectromagneticField.ToString());
            RuleFor(p => p.Performer).NotEmpty().When(p => p.FactorType == FactorTypeEnum.ElectromagneticField.ToString());

            // Lighting
            RuleFor(p => p.DeviceKind).NotEmpty().When(p => p.FactorType == FactorTypeEnum.Lighting.ToString());
            RuleFor(p => p.Interpretation).NotEmpty().When(p => p.FactorType == FactorTypeEnum.Lighting.ToString());
            RuleFor(p => p.Performer).NotEmpty().When(p => p.FactorType == FactorTypeEnum.Lighting.ToString());
        }

    }
}
