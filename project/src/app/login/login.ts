import { Component } from '@angular/core';
import { MyService } from '../my-service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  email = '';

  constructor(
    public myService: MyService,
    private router: Router
  ) {}

  login() {
    console.log("email is:", this.email);
    this.myService.login(this.email).subscribe({
      next: (user) => {
        if (user) {
          this.myService.saveUserLocal(user);
          alert("התחברת בהצלחה!");

          // ➜ הנה התיקון החשוב:
          this.router.navigate(['/']);

        } else {
          alert("אימייל לא קיים — עלייך להירשם");
          this.router.navigate(['/register']);
        }
      },
      error: (err) => {
        console.error("Error:", err);
        alert("בעיה בשרת — נסה שוב");
      }
    });
  }
}
