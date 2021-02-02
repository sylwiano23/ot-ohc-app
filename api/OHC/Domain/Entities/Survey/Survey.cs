using Domain.Entities.Survey.Helpers;
using Domain.Enums;
using System;

namespace Domain.Entities.Survey
{
    public class Survey
    {
        public int Id { get; private set; }
        public FactorTypeEnum FactorType { get; private set; }
        public string FactorName { get; private set; }
        public DateTime Date { get; private set; }
        public string Performer { get; private set; }
        public string Position { get; private set; }
        public string Place { get; private set; }
        public string Interpretation { get; private set; }
        public string Result { get; private set; }
        public DateTime? NextSurveyDate { get; private set; }
        public bool IsSurveySuspend { get; private set; }
        public string NormValue { get; private set; }
        public string Device { get; private set; }
        public string DeviceKind { get; private set; }
        public string MarkedParameter { get; private set; }
        public string IdentificationSurveyMethod { get; private set; }
        public string DescriptionSurveyMethod { get; private set; }
        public string IntermediateZoneH { get; private set; }
        public string IntermediateZoneE { get; private set; }
        public string RiskZoneE { get; private set; }
        public string RiskZoneH { get; private set; }
        public string DengerousZoneE { get; private set; }
        public string DengerousZoneH { get; private set; }
        public string Exposure { get; private set; }

        public static Survey CreateNew(SurveyProperties surveyProperties)
        {
            Survey survey = new Survey()
            {
                FactorType = surveyProperties.FactorType,
                FactorName = surveyProperties.FactorName,
                Date = surveyProperties.Date,
                Performer = surveyProperties.Performer,
                Result = surveyProperties.Result,
                Position = surveyProperties.Position,
                Place = surveyProperties.Place,
                Interpretation = surveyProperties.Interpretation,
                NormValue = surveyProperties.NormValue,
                Device = surveyProperties.Device,
                DeviceKind = surveyProperties.DeviceKind,
                NextSurveyDate = surveyProperties.NextSurveyDate,
                IsSurveySuspend = surveyProperties.IsSurveySuspend,
                MarkedParameter = surveyProperties.MarkedParameter,
                IdentificationSurveyMethod = surveyProperties.IdentificationSurveyMethod,
                DescriptionSurveyMethod = surveyProperties.DescriptionSurveyMethod,
                IntermediateZoneE = surveyProperties.IntermediateZoneE,
                IntermediateZoneH = surveyProperties.IntermediateZoneH,
                RiskZoneE = surveyProperties.RiskZoneE,
                RiskZoneH = surveyProperties.RiskZoneH,
                DengerousZoneE = surveyProperties.DengerousZoneE,
                DengerousZoneH = surveyProperties.DengerousZoneH,
                Exposure = surveyProperties.Exposure
            };

            return survey;
        }

        public void ChangeDetails(SurveyProperties surveyProperties)
        {
            FactorType = surveyProperties.FactorType;
            FactorName = surveyProperties.FactorName;
            Date = surveyProperties.Date;
            Performer = surveyProperties.Performer;
            Result = surveyProperties.Result;
            Position = surveyProperties.Position;
            Place = surveyProperties.Place;
            Interpretation = surveyProperties.Interpretation;
            NormValue = surveyProperties.NormValue;
            Device = surveyProperties.Device;
            DeviceKind = surveyProperties.DeviceKind;
            NextSurveyDate = surveyProperties.NextSurveyDate;
            IsSurveySuspend = surveyProperties.IsSurveySuspend;
            MarkedParameter = surveyProperties.MarkedParameter;
            IdentificationSurveyMethod = surveyProperties.IdentificationSurveyMethod;
            DescriptionSurveyMethod = surveyProperties.DescriptionSurveyMethod;
            IntermediateZoneE = surveyProperties.IntermediateZoneE;
            IntermediateZoneH = surveyProperties.IntermediateZoneH;
            RiskZoneE = surveyProperties.RiskZoneE;
            RiskZoneH = surveyProperties.RiskZoneH;
            DengerousZoneE = surveyProperties.DengerousZoneE;
            DengerousZoneH = surveyProperties.DengerousZoneH;
            Exposure = surveyProperties.Exposure;
        }        
    }
}