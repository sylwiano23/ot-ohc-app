export class Factor {
  id?: number;
  type_key: string = "";
  name: string = "";
}

export interface IFactorForm {
  id?: number;
  value: string;
}

export interface IHashFactors {
  [key: string]: Factor[];
}
