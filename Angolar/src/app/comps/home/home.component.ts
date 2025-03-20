import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';


@Component({
    selector: 'app-home',
    standalone: true,
    imports: [RouterOutlet],
    templateUrl: './home.component.html',
    styleUrl: './home.component.css'
})

export class HomeComponent {
      constructor(public R: Router) {}
    
    enterLottery() {
        this.R.navigate(['product']);

    }

}

