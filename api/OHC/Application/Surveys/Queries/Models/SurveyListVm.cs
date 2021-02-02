using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Surveys.Queries.Models
{
    public class SurveysListVm
    {
        public SurveysListVm()
        {
            Surveys = new List<SurveyDto>();
        }

        public List<SurveyDto> Surveys { get; set; }
    }
}
