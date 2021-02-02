export class Position {
  id?: number;
  name?: string = "";
  description?: string = "";
  dust?: number[] = [];
  physical_factors?: number[] = [];
  chemical_agents?: number[] = [];
  biological_factors?: number[] = [];
  other_hazardous_factors?: number[] = [];
  total_hazardous_factors?: number;
}

export interface IIssueForm {
  positionId: number;
  name: string;
  surname: string;
  peselNumber: string;
  certificateType: string;
  sexType: string;
  street: string;
  houseNumber: string;
  city: string;
}

export interface IPositionForm {
  id?: number;
  name: string;
  description: string;
  pesel: string;
  position: string;
  physical_factors: number[];
  dust: number[];
  chemical_agents: number[];
  biological_factors: number[];
  other_hazardous_factors: number[];
  total_hazardous_factors: number;
}

export class PositionFactors {
  Dust: number[] = [];
  Physical: number[] = [];
  Biological: number[] = [];
  Chemical: number[] = [];
  Other: number[] = [];
}

export class PositionView extends Position {
  name: string = "";
  description: string = "";
  factors: PositionFactors = new PositionFactors();
}

export class PositionPayload {
  id?: number;
  name: string;
  description: string = "";
  factorsListIds: number[];

  constructor(source: IPositionForm) {
    this.id = source.id;
    this.name = source.name;
    this.description = source.description;
    this.factorsListIds = [
      ...source.dust,
      ...source.physical_factors,
      ...source.biological_factors,
      ...source.chemical_agents,
      ...source.other_hazardous_factors
    ];
  }
}
