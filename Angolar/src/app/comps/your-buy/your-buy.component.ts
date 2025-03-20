import { Component, OnInit } from '@angular/core';
import { BuyService } from '../../services/Buy.service';
import { CommonModule } from '@angular/common'; // הוסף את המודול הזה
import { UserService } from '../../services/User.service';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-your-buy',
  standalone: true,
  imports: [CommonModule,RouterOutlet], // הוסף כאן את CommonModule
  templateUrl: './your-buy.component.html',
  styleUrls: ['./your-buy.component.css']
})
export class YourBuyComponent implements OnInit {
  constructor(public B: BuyService,public u:UserService, public R: Router) { }
  
  allB: Array<any> = new Array<any>();
  allSum: number = 0;

  ngOnInit() { 
    this.get(); 
  }

  // יבואי מהשרת
  get() {
    this.B.ById(this.u.currentUser.id).subscribe(
      d => {  
        console.log(d);     
        this.allB = d;
      },
    );    
  }
  // להצגת פרטי הקניה
  more(id: number) {
    console.log(id);
      this.R.navigate(['yourBuy', 'buy-details', id]);
  }
  
}
