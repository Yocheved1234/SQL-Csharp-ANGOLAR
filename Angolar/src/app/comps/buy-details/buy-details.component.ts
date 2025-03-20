import { Component } from '@angular/core';
import { BuyService } from '../../services/Buy.service';
import { ActivatedRoute, Router } from '@angular/router';
import { BuyD } from '../../classes/BuyD';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-buy-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './buy-details.component.html',
  styleUrl: './buy-details.component.css'
})
export class BuyDetailsComponent {
  constructor(private route: ActivatedRoute, public B: BuyService, public R: Router) {

    // מציאת המוצרים להצגה מהשרת
    this.route.params.subscribe(data => {
      this.Id = data['id']
    })
  }

Id: number = 0;
allB: Array<BuyD> = new Array<BuyD>();

// בקשרה שיעזה עם פתיחת העמוד
ngOnInit() {
  this.get();
}

// מציאת המוצרים של ההזמנה להצגה 
get() {
  this.B.ByBuyId(this.Id).subscribe(
    d => {
      console.log(d);
      this.allB = d;
    },
  );
}
}
