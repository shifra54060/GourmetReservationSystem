import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MyService } from '../my-service';
import { Customers } from '../models/customers';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './register.html',
  styleUrls: ['./register.css'],
})
export class Register {

  registerForm: FormGroup;
  submitted = false;

  constructor(private fb: FormBuilder, public myService: MyService) {
    this.registerForm = this.fb.group({
      fullName: ['', [Validators.required, Validators.minLength(3)]],
      phoneNumber: ['', [Validators.required, Validators.pattern('^[0-9]{9,10}$')]],
      email: ['', [Validators.required, Validators.email]],
      address: ['', Validators.required],
      birthDate: ['', Validators.required]

    });
  }

  // גישה נוחה לשדות
  get f() { return this.registerForm.controls; }

  submitForm() {
    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }
    const birthDateValue = this.registerForm.value.birthDate;
    // ממיר את התאריך למחרוזת ISO ומקצץ כדי לקבל רק את חלק התאריך
    const dateString = new Date(birthDateValue).toISOString().split('T')[0];
    const user = new Customers(
      0, // יוחלף בקוד מהשרת
      this.registerForm.value.fullName,
      this.registerForm.value.phoneNumber,
      this.registerForm.value.address,
      this.registerForm.value.email,
      dateString
    );

    this.myService.register(user).subscribe({
      next: (savedUser) => {
        this.myService.saveUserLocal(savedUser);
        alert('נרשמת בהצלחה!');
        this.registerForm.reset();
        this.submitted = false;
      },
      error: () => alert('שגיאה בהרשמה')
    });
  }
}
