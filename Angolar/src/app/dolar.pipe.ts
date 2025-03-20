import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'dolar',
  standalone: true
})
export class DolarPipe implements PipeTransform {
    transform(value: any){
        return '$'+ value;
    }  
}
