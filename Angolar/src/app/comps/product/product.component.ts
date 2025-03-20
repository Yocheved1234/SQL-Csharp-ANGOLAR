import { Component, PipeTransform } from '@angular/core';
import { ProdService } from '../../services/Product.service';
import { Product } from '../../classes/Product';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { Router, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AddtocartDirective } from '../../addtocart.directive';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [HttpClientModule, FormsModule, RouterOutlet, CommonModule, CommonModule,AddtocartDirective],
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements PipeTransform{
  currentDate: Date;
  allP: Array<Product> = new Array<Product>();
  selectedCategory!: string;
  selectedPrice!: string;

  constructor(public p: ProdService, public R: Router) {
    this.currentDate = new Date();
    this.currentDate.setDate(this.currentDate.getDate() + 7);
      }

  ngOnInit(): void {
    this.get();
    console.log(this.p.T + "   " + this.p.P);
  }

  // להצגת כל המוצרים
  get() {
    this.p.getS().subscribe(
      d => {
        this.allP = d;
        if (this.p.T == true)
          this.byDate();
        if (this.p.P == true)
          this.byPrice();
      },
      err => { console.log("error " + err.message); }
    );
  }

  // לפרטים נוספים
  more(p: Product) {
    console.log(p);
    this.R.navigate(['product', 'big', p.id]);
  }

  // להוספת מוצר
  increment(product: Product) {
    if (!this.p.quantities[product.id]) {
      this.p.quantities[product.id] = 0;
    }
    this.p.quantities[product.id]++;
    this.p.sum++;
  }

  // להוריד למוצר
  decrement(product: Product) {
    if (this.p.quantities[product.id] > 0) {
      this.p.quantities[product.id]--;
      this.p.sum--;
    }
  }

  // מיון לפי מחיר
  byPrice() {
    this.allP.sort((a, b) => a.price - b.price);
    this.p.P = true;
    this.p.T = false;
  }

  // מיון לפי תאריך
  byDate() {
    this.allP.sort((a, b) => {
      const dateA = new Date(a.date);
      const dateB = new Date(b.date);
      return dateA.getTime() - dateB.getTime();
    });
    this.p.T = true;
    this.p.P = false;
  }

  // מיון לפי קטגוריה
  getSelectedValues() {
    const price = this.selectedPrice ? parseInt(this.selectedPrice, 10) : undefined;
    this.p.filterItems(price, this.selectedCategory).subscribe(
      d => {
        this.allP = d;
      },
      err => { console.log("error " + err.message); }
    );
  }

  // בדיקה האם זה בשבוע זה
  isWithinAWeek(date: string): boolean {
    const today = new Date();
    const weekFromNow = new Date(today);
    weekFromNow.setDate(today.getDate() + 7);

    const itemDate = new Date(date);
    return itemDate >= today && itemDate <= weekFromNow;
}

// הוספת הדולר ע"י פייפ
transform(value: any) {
  return value.subs
}
}
