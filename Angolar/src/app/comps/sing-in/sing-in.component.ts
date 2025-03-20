import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { User } from '../../classes/User';
import { UserService } from '../../services/User.service';
import Swal from 'sweetalert2';
import { Router, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common'; // הוסף את השורה הזו
import { IconButtonComponent } from '../icon-button/icon-button.component';

@Component({
  selector: 'app-sing-in',
  standalone: true,
  imports: [HttpClientModule, FormsModule, CommonModule, RouterOutlet,IconButtonComponent], // הוסף את CommonModule כאן
  templateUrl: './sing-in.component.html',
  styleUrls: ['./sing-in.component.css']
})
export class SingInComponent {
  f: User = new User();
  title = 'Project';

  constructor(public U: UserService, public R: Router) { }

  ngOnInit(): void { }

  allS: Array<User> = new Array<User>();

  // הוספת לקוח ובדיקות תקינות של המייל גם בפרונטאנד וגם בשרת
  Check(form: NgForm): void {
    console.log(this.f);
    if (form.valid!) {
      this.U.AddUser(this.f).subscribe(
        d => {
          if (d) {
            console.log(d);
            this.U.currentUser = d;
            Swal.fire({
              title: 'Welcome!',
              text: "Hi " + this.f.nameU + "!",
              icon: 'success',
              confirmButtonText: 'OK'
            });
            this.R.navigate(['./product'])

          }
          if (this.f.nameU != null && d == null) {
            Swal.fire({
              title: 'Login Required',
              text: "Your email is not recognized, please sign in",
              icon: 'warning',
              confirmButtonText: 'OK'
            });
          }
        },
      );
    } 
    else {
      Swal.fire({
        title: 'Missing Information!',
        text: `The following fields are missing`,
        icon: 'warning',
        confirmButtonText: 'OK'
      });
    }
  }
  onLogIn(): void {  
    this.R.navigate(['./login'])
  }
}
