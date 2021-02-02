import { PipeTransform, Pipe } from "@angular/core";

@Pipe({
  name: "sortDirection"
})
export class SortDirection implements PipeTransform {
  transform(sort: string, propName: string) {
    if (sort.replace("-", "") === propName) {
      if (sort.includes("-")) {
        return "icon-sort-down";
      } else {
        return "icon-sort-up";
      }
    }

    return "icon-sort";
  }
}
