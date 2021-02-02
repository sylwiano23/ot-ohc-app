import { Injectable } from "@angular/core";

import { BehaviorSubject } from "rxjs";
import { finalize } from "rxjs/operators";

import { IResponseSuccess, IResponseError } from "@app/core/interfaces/response.interface";

import { PositionResource } from "@app/modules/position/resources/resource";
import {
  Position,
  IPositionForm,
  IIssueForm,
  PositionPayload
} from "@app/modules/position/interfaces/position.interface";

export const POSITIONS_MOCK_DATA = [
  {
    id: 25,
    name: "Lakiernik"
  },
  {
    id: 26,
    name: "Mechanik"
  }
];

export const POSITION_MOCK_DATA: Position = {
  name: "",
  physical_factors: [],
  dust: [],
  chemical_agents: [],
  biological_factors: [],
  other_hazardous_factors: [],
  total_hazardous_factors: 0
};

@Injectable()
export class PositionService {
  //region Properties

  positions = new BehaviorSubject<Position[]>([]);
  currentPositions = this.positions.asObservable();

  position = new BehaviorSubject<Position>(null);
  currentPosition = this.position.asObservable();

  //endregion

  //region Events

  //endregion

  constructor(private positionResource: PositionResource) {}

  //region Accessors

  //endregion

  //region Behaviors

  /**
   * @inheritDoc
   */
  public getPositions(callback: Function) {
    return this.positionResource
      .list()
      .pipe(finalize(() => callback()))
      .subscribe(
        response => {
          this.positions.next(response.positions);
        },
        error => {}
      );
  }

  /**
   * @inheritDoc
   */
  public get(id: number, params?: { with_values: string }) {
    return this.positionResource.get(id, params);
  }

  /**
   * @inheritDoc
   */
  public create(data: PositionPayload) {
    return this.positionResource.create(data);
  }

  /**
   * @inheritDoc
   */
  public update(data: PositionPayload) {
    return this.positionResource.update(data);
  }

  /**
   * @inheritDoc
   */
  public delete(id: number) {
    return this.positionResource.delete(id);
  }

  /**
   * @inheritDoc
   */
  public issueCertificate(data: IIssueForm) {
    return this.positionResource.issueCertificate(data);
  }

  //endregion
}
