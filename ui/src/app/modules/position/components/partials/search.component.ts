import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { FormControl } from "@angular/forms";

import { map, startWith, debounceTime } from "rxjs/operators";

import { PositionService } from "@app/modules/position/services/service";
import { Position } from "@app/modules/position/interfaces/position.interface";

/**
 * Component for display position screen
 */
@Component({
  selector: "position-search",
  templateUrl: "search.component.html"
})
export class PositionSearchComponent implements OnInit {
  @Output()
  onSearchComplete: EventEmitter<Position[]> = new EventEmitter();

  searchControl = new FormControl();
  positions: Position[] = [];

  constructor(private positionService: PositionService) {
    this.positionService.currentPositions.subscribe(positions => {
      this.positions = positions;

      this.onSearchComplete.emit(positions);
    });
  }

  ngOnInit() {
    this.searchControl.valueChanges
      .pipe(
        startWith(""),
        debounceTime(500),
        map(value => this._filter(value))
      )
      .subscribe(filteredPositions => {
        this.onSearchComplete.emit(filteredPositions);
      });
  }

  private _filter(value: string): Position[] {
    const filterValue = value.toLowerCase();

    return this.positions.filter(option => option.name.toLowerCase().includes(filterValue));
  }
}
