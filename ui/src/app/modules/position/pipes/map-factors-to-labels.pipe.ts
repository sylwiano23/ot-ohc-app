import { PipeTransform, Pipe } from "@angular/core";

@Pipe({
  name: "mapFactorsToLabels"
})
export class MappingFactorsToLabels implements PipeTransform {
  transform(value, typeKey: string, mappingFunction: Function) {
    return mappingFunction(typeKey, value);
  }
}
