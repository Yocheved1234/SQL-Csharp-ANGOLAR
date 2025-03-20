import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ProdService } from '../../services/Product.service';
import { Product } from '../../classes/Product';
import { UserService } from '../../services/User.service';
import { User } from '../../classes/User';
import { catchError, forkJoin, of } from 'rxjs';

@Component({
  selector: 'app-winners',
  standalone: true,
  imports: [HttpClientModule, FormsModule],
  templateUrl: './winners.component.html',
  styleUrl: './winners.component.css'
})
export class WinnersComponent {
constructor(public p: ProdService, public u: UserService) { }
  
  ngOnInit(): void {
    this.get();

  }

  allT:Array<any> = [];
  allP: Array<Product> = new Array<Product>();
  allN: Array<any> = new Array<any>();

  // יבואי מהשרת את כל המוצאים שכבר הוגרלו
  get() {
    this.p.getW().subscribe(
      d => {  
        console.log(d);     
        this.allP = d;
  
        if (Array.isArray(d) && d.length > 0) {
          d.forEach(element => {
            this.u.getById(element.winner).subscribe(
              detail => { 
                console.log(detail);
                var nameUser = detail;
                this.allN.push(nameUser);
              }
            );
          });
        } else {
          console.log("No data available");
        }
      },
    );    
  }
}
