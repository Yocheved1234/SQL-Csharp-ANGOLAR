import { Directive, ElementRef, HostListener, Input, OnInit } from '@angular/core';
import { ProdService } from './services/Product.service';

@Directive({
  selector: '[appAddtocart]',
  standalone: true
})
export class AddtocartDirective{
  @Input() productId?: number;
  constructor(public er: ElementRef, public p: ProdService) { }
  myElement: ElementRef | undefined;

  @HostListener('click')
  addColor() {
    console.log(this.productId);
    console.log(this.p.quantities);

    if(this.productId!=undefined) {
      console.log(this.p.quantities[this.productId]);
    }
    
    if(this.productId==undefined || this.p.quantities[this.productId] !=0)  {
      this.er.nativeElement.style.color = 'yellow'; 
    }

  }
}
