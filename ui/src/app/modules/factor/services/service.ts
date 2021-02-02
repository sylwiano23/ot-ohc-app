import { Injectable } from "@angular/core";

import { BehaviorSubject } from "rxjs";

import { IResponseSuccess, IResponseError } from "@app/core/interfaces/response.interface";

import { FactorResource } from "@app/modules/factor/resources/resource";
import { Factor, IFactorForm, IHashFactors } from "@app/modules/factor/interfaces/factor";
import { FactorTypeEnum } from "@app/core/interfaces/types.interface";

export const FACTOR_TYPES_NAMES: { [key: string]: string } = {
  Dust: "Pyły",
  Chemical: "Czynniki chemiczne",
  Biological: "Czynniki biologiczne",
  Physical: "Czynniki fizyczne",
  Other: "Inne czynniki niebezpieczne"
};

export const FACTOR_TYPES: string[] = ["Dust", "Chemical", "Biological", "Physical", "Other"];

export const FACTORS_MOCK_DATA: any = {
  Dust: [
    {
      id: 1,
      type_key: "dust",
      name: "Pył fifo"
    },
    {
      id: 6,
      type_key: "dust",
      name: "Pył kifo"
    }
  ],
  Chemical: [
    {
      id: 7,
      type_key: "chemical_agents",
      name: "Kontakt ze smarami i olejami maszynowymi – właściwości drażniące dla skóry"
    }
  ],
  Biological: [
    {
      id: 8,
      type_key: "biological_factors",
      name: "Kontakt z bakteriami, wirusami, pasożytami"
    }
  ],
  Physical: [
    {
      id: 9,
      type_key: "physical_factors",
      name: "Narażenie na hałas – brak przekroczeń NDN (<85 dB)"
    }
  ],
  Other: [
    {
      id: 10,
      type_key: "other_hazardous_factors",
      name: "Obsługa komputera – ponad 4 godz/zmianę roboczą"
    },
    {
      id: 11,
      type_key: "other_hazardous_factors",
      name: "Kierowanie samochodem służbowym - kat. B"
    }
  ]
};

@Injectable()
export class FactorService {
  //region Properties

  factors = new BehaviorSubject<IHashFactors>({
    Dust: [],
    Chemical: [],
    Biological: [],
    Physical: [],
    Other: []
  });
  currentFactors = this.factors.asObservable();

  factor = new BehaviorSubject<Factor>(null);
  currentFactor = this.factor.asObservable();

  //endregion

  //region Events

  //endregion

  constructor(private factorResource: FactorResource) {}

  //region Accessors

  //endregion

  //region Behaviors

  /**
   * @inheritDoc
   */
  public list(typeKey: string) {
    return this.factorResource.list({ factorType: typeKey });
  }

  /**
   * @inheritDoc
   */
  public get(id: number) {
    return this.factorResource.get(id);
  }

  /**
   * @inheritDoc
   */
  public create(factor: IFactorForm) {
    return this.factorResource.create(factor);
  }

  /**
   * @inheritDoc
   */
  public update(factor: IFactorForm) {
    return this.factorResource.update(factor);
  }

  /**
   * @inheritDoc
   */
  public delete(id: number) {
    return this.factorResource.delete(id);
  }

  /**
   * @inheritDoc
   */
  public getFactorLabel(typeKey: string, id: number) {
    let factors = this.factors.getValue();
    let searchedFactor = factors[typeKey].find(factor => factor.id === id);
    return searchedFactor ? searchedFactor.name : "?";
  }

  public loadAllFactors() {
    FACTOR_TYPES.forEach(factorType => {
      this.list(FactorTypeEnum[factorType]).subscribe(response => {
        this.factors.next(Object.assign(this.factors.value, { [factorType]: response.factors }));
      });
    });
  }

  //endregion
}
