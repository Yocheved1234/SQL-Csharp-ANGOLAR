import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { ProductComponent } from './comps/product/product.component';
import { LogInComponent } from './comps/log-in/log-in.component';
import { SingInComponent } from './comps/sing-in/sing-in.component';
import { WinnersComponent } from './comps/winners/winners.component';
import { ProdService } from './services/Product.service';
import { UserService } from './services/User.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,RouterLink,],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  constructor(public p: ProdService,public u:UserService) { }
  
  
  title = 'Project';
}