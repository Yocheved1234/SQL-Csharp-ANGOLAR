import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { User } from '../../classes/User';
import { UserService } from '../../services/User.service';
import Swal from 'sweetalert2';
import { Router, RouterOutlet } from '@angular/router';
import { IconButtonComponent } from '../icon-button/icon-button.component';

@Component({
  selector: 'app-log-in',
  standalone: true,
  imports: [HttpClientModule, FormsModule,RouterOutlet,IconButtonComponent],
  templateUrl: './log-in.component.html',
  styleUrl: './log-in.component.css'
})
export class LogInComponent {
  f: User = new User();
  title = 'Project';
  
  constructor(public U: UserService, public R: Router) { }
  ngOnInit(): void {
  }
  allS: Array<User> = new Array<User>()

  // בדיקות תקינות גם בשרת וגם בפרונטאנד
  Check(form: NgForm): void {
    if (form.valid!) {
      console.log(this.f.nameU);
      this.U.CkechEmail(this.f).subscribe(
        d => {
          if (d) {
            Swal.fire({
              title: 'Welcome!',
              text: "Hi " + this.f.nameU + "!",
              icon: 'success',
              confirmButtonText: 'OK'
            });
            this.U.currentUser = d;            
            this.R.navigate(['./product'])
          }
          if (this.f.nameU != null && d == null) {
            Swal.fire({
              title: 'Login Required',
              text: "You email is not recugnised plese sine in",
              icon: 'warning',
              confirmButtonText: 'OK'
            });
             this.R.navigate(['./singin'])
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
  onSignIn(): void {
    this.R.navigate(['./singin'])
  }

}
