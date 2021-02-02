export class Survey {
  id?: number;
  type_key: string = "";
  name: string = "";
  date: string | Date = "";
  nextSurveyDate: string | Date = null;
  isSurveySuspend: boolean = false;

  position?: string;
}

export interface ISurveyForm {
  id?: number;
  value: string;
  date?: string | Date;
  nextSurveyDate?: string | Date;
}

export interface IHashSurveys {
  [key: string]: Survey[];
}

export const SURVEY_TYPES_PROPERTIES: { [key: string]: string[] } = {
  Dust: [
    "factorName",
    "date",
    "place",
    "performer",
    "result",
    "normValue",
    "interpretation",
    "deviceKind",
    "position",
    "nextSurveyDate",
    "isNormExceeded",
    "isSurveySuspend",
    "isSurveyUsed"
  ],
  Chemical: [
    "factorName",
    "date",
    "place",
    "performer",
    "result",
    "interpretation",
    "deviceKind",
    "position",
    "nextSurveyDate",
    "isSurveySuspend",
    "isSurveyUsed"
  ],
  Biological: [
    "factorName",
    "date",
    "place",
    "markedParameter",
    "identificationSurveyMethod",
    "result",
    "descriptionSurveyMethod",
    "deviceKind",
    "position",
    "nextSurveyDate",
    "isSurveySuspend",
    "isSurveyUsed"
  ],
  Physical: [
    "factorName",
    "date",
    "place",
    "performer",
    "result",
    "normValue",
    "interpretation",
    "deviceKind",
    "position",
    "nextSurveyDate",
    "isNormExceeded",
    "isSurveySuspend",
    "isSurveyUsed"
  ],
  Lighting: [
    "factorName",
    "date",
    "place",
    "performer",
    "result",
    "interpretation",
    "deviceKind",
    "position",
    "nextSurveyDate",
    "isSurveySuspend",
    "isSurveyUsed"
  ],
  Other: ["factorName", "position", "isSurveyUsed"],
  ElectromagneticField_LIST_HEADER: [
    "factorName",
    "date",
    "place",
    "performer",

    "intermediate_zone",

    "risk_zone",

    "danger_zone",

    "exposure",
    "device",
    "deviceKind",
    "position",
    "nextSurveyDate",
    "isSurveySuspend",
    "isSurveyUsed"
  ],
  ElectromagneticField_LIST_BODY: [
    "factorName",
    "date",
    "place",
    "performer",

    "intermediateZoneE",
    "intermediateZoneH",

    "riskZoneE",
    "riskZoneH",

    "dengerousZoneE",
    "dengerousZoneH",

    "exposure",
    "device",
    "deviceKind",
    "position",
    "nextSurveyDate",
    "isSurveySuspend",
    "isSurveyUsed"
  ],
  ElectromagneticField_FORM: [
    "factorName",
    "date",
    "place",
    "performer",
    "interpretation",
    "result",
    "position",

    "exposure",
    "device",
    "deviceKind",
    "nextSurveyDate",
    "isSurveySuspend",
    "isSurveyUsed"
  ]
};

export const SURVEY_TYPES_PROPERTIES_TRANSLATIONS: { [key: string]: string } = {
  factorName: "Nazwa czynnika",
  date: "Data pomiaru",
  place: "Miejsce pomiaru",
  performer: "Wykonujący pomiar",
  result: "Wynik pomiaru",
  normValue: "Norma",
  interpretation: "Interpretacja pomiaru",
  position: "Stanowisko",
  nextSurveyDate: "Kolejne badanie",

  placeDetail: "Miejsce pomiaru czynnika",

  sample: "Próbka",
  markedParameter: "Oznaczany parametr",
  identificationSurveyMethod: "Identyfikacja metody badawaczej",
  descriptionSurveyMethod: "Opis metody badawczej",

  intermediate_zone: "Strefa pośrednia",
  intermediateZoneE: "E",
  intermediateZoneH: "H",
  risk_zone: "Strefa zagrożenia",
  riskZoneE: "E",
  riskZoneH: "H",
  danger_zone: "Strefa niebezpieczna",
  dengerousZoneE: "E",
  dengerousZoneH: "H",

  isNormExceeded: "Czy przekroczono normę?",
  isSurveySuspend: "Czy zaprzestano badań?",
  isSurveyUsed: "Czy użyć tego badania?",

  exposure: "Narażenie",
  device: "Urządzenie",
  deviceKind: "Typ urządzenie"
};

export const SURVEY_TYPES_NAMES: { [key: string]: string } = {
  Dust: "Pyły",
  Chemical: "Czynniki chemiczne",
  Biological: "Czynniki biologiczne",
  Physical: "Czynniki fizyczne",
  Lighting: "Oświetlenie czynnik uciążliwy",
  ElectromagneticField: "Pole elektromagnetyczne",
  Other: "Inne czynniki niebezpieczne"
};
