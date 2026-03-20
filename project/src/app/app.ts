import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MyService } from './my-service';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  userFirstLetter: string | null = null;

  constructor(private myService: MyService) {
    this.loadUser();
  }

  // טוען את המשתמש ושם את האות הראשונה שלו
  loadUser() {
    const user = this.myService.getUserLocal();
    if (user && user.fullName) {
      this.userFirstLetter = user.fullName.charAt(0).toUpperCase();
    }
  }

  // התנתקות
  logout() {
    this.myService.logout();
    this.userFirstLetter = null;
  }
}
