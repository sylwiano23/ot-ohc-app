import { PipeTransform, Pipe } from "@angular/core";

@Pipe({
  name: "map"
})
export class Mapping implements PipeTransform {
  transform(value, mappingFunction: Function) {
    return mappingFunction(value);
  }
}
