import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../classes/Product';
import { ProdService } from '../../services/Product.service';
import { Router, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { DolarPipe } from '../../dolar.pipe';



@Component({
  selector: 'app-big-product',
  standalone: true,
  imports: [RouterOutlet,CommonModule,DolarPipe],
  templateUrl: './big-product.component.html',
  styleUrls: ['./big-product.component.css']
})

export class BigProductComponent {

  constructor(private route: ActivatedRoute, public p: ProdService,public R: Router) {
    // מציאת המוצר במערך המוצרים
    this.p.getS().subscribe(
      d => {
        this.allP = d;
        console.log(this.allP);

        this.route.params.subscribe(data => {
          this.id = data['id'];
          let c = this.allP.find(x => x.id == this.id);
          console.log("Product found:", c);
          if (c)
            this.current = c;
        });
      },
      err => { console.log("error " + err.message); }
    );
  }

  id: number = 0;
  current: Product = new Product();
  allP: Array<Product> = new Array<Product>();

  // פונקציה להוספה
  increment(product: Product) {
    if (!this.p.quantities[product.id]) {
      this.p.quantities[product.id] = 0;
    }
    this.p.quantities[product.id]++;
    this.p.sum++;
  }
  
  // פונקציה לכפתור המינוס
  decrement(product: Product) {
    if (this.p.quantities[product.id] > 0) {
      this.p.quantities[product.id]--;
      this.p.sum--;
    }
  }

  // פונקציה לחזור 
  back(){    
    this.R.navigate(['product']);
  }
}

