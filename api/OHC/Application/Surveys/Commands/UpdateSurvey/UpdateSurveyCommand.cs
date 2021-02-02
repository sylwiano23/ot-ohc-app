using MediatR;
using System;

namespace Application.Surveys.Commands.UpdateSurvey
{
    public class UpdateSurveyCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string FactorType { get; set; }
        public string FactorName { get; set; }
        public DateTime Date { get; set; }
        public string Performer { get; set; }
        public string Place { get; set; }
        public string Position { get; set; }
        public string Interpretation { get; set; }
        public string Result { get; set; }
        public DateTime? NextSurveyDate { get; set; }
        public bool IsSurveySuspend { get; set; }
        public string MarkedParameter { get; set; }
        public string IdentificationSurveyMethod { get; set; }
        public string DescriptionSurveyMethod { get; set; }
        public string NormValue { get; set; }
        public string IntermediateZoneH { get; set; }
        public string IntermediateZoneE { get; set; }
        public string RiskZoneE { get; set; }
        public string RiskZoneH { get; set; }
        public string DengerousZoneE { get; set; }
        public string DengerousZoneH { get; set; }
        public string Device { get; set; }
        public string DeviceKind { get; set; }
        public string Exposure { get; set; }
    }
}
