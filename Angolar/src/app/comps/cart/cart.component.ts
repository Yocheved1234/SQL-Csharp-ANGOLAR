import { Component, OnInit } from '@angular/core';
import { ProdService } from '../../services/Product.service';
import { CommonModule } from '@angular/common';
import { Product } from '../../classes/Product';
import { UserService } from '../../services/User.service';
import Swal from 'sweetalert2';
import { BuyService } from '../../services/Buy.service';
import { DolarPipe } from '../../dolar.pipe';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, DolarPipe, RouterOutlet],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  quantities: { [key: number]: number } = {};
  allP: Array<Product> = new Array<Product>();
  allSum: number = 0;

  constructor(public p: ProdService, public u: UserService
    , public B: BuyService,public R: Router) {
    this.p.getS().subscribe(
      d => {
        this.allP = d;
        this.calculateAllSum(); // חישוב סכום לאחר קבלת המוצרים
      },
      err => { console.log("error " + err.message); }
    );
  }

  ngOnInit() {
    this.quantities = this.p.quantities;

    this.calculateAllSum();
  }


  getProduct(productId: string) {
    return this.allP.find(x => x.id == productId)!;
  }

  // חישוב הסכום
  sumAll(productId: string, umount: number) {
    const product = this.getProduct(productId);
    return product ? (product.price * umount) : 0;
  }

  calculateAllSum() {
    this.allSum = Object.keys(this.quantities).reduce((sum, key) => {
      return sum + this.sumAll(key, this.quantities[+key]);
    }, 0);
  }

  // הוספת מוצר
  increment(product: Product) {
    if (!this.p.quantities[product.id]) {
      this.p.quantities[product.id] = 0;
    }
    this.p.quantities[product.id]++;
    this.p.sum++;
    this.allSum += product.price
  }

  // הורדת מוצר
  decrement(product: Product) {
    if (this.p.quantities[product.id] > 0) {
      this.p.quantities[product.id]--;
      this.p.sum--;
      this.allSum -= product.price

    }
    if (this.p.quantities[product.id] === 0) {
      delete this.p.quantities[product.id];
    }
  }
  Discount: any;
  // שליחה לתשלום לשרת פעמיים גם להנחה, וגם להוספה בשרת
  toPay() {
    if (this.u.currentUser != undefined) {
      this.B.Discount(this.allSum, this.p.sum)
        .subscribe(data => {
          this.Discount = data;

          Swal.fire({
            title: `Final price: ${this.Discount}$!`,
            text: `Original price: ${this.allSum}$\nYou saved ${this.allSum-this.Discount}$`,
            icon: 'question',
            showCancelButton: true,
            confirmButtonText: 'yes',
            cancelButtonText: 'no'
          }).then((result) => {
            if (result.isConfirmed) {
              this.B.AddOrder(this.u.currentUser.id, this.quantities, this.allSum)
              .subscribe(data => { console.log(data); });
              Swal.fire('payment went threw!', '', 'success');
              this.R.navigate(['']);
              this.p.quantities=[];
              this.p.sum =0;
            } else {
              Swal.fire('Payment canceld', '', 'info');
            }
          });
        });
    }
    else {
      Swal.fire({
        title: 'Login Required',
        text: "You need to log in for to final you order!!!",
        icon: 'warning',
        confirmButtonText: 'OK'
      });
    }
    console.log(this.u.currentUser);
  }

}
