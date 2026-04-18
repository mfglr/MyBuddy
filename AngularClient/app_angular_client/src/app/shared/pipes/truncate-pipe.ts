import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'truncate',
})
export class TruncatePipe implements PipeTransform {
  transform(value: string,  maxLength: number = 15): string {
    return value.length <= maxLength ? value: `${value.substring(0, maxLength)}...`;
  }
}
