import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MyService } from '../my-service';
import { Router } from '@angular/router';
import { Products } from '../models/products';
import { ShoppingDetails } from '../models/shopping-details';
import { RouterModule } from '@angular/router';
@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, HttpClientModule,RouterModule],
  templateUrl: './shopping-cart.html',
  styleUrls: ['./shopping-cart.css']
})
export class CartComponent {
 serverBaseUrl: string = 'https://localhost:7228';
  cartItems: any[] = [];
  totalAmount: number = 0;
  message: string = '';

  constructor(public myService: MyService, public router: Router) {
    this.loadCart();
  }

  loadCart() {
    this.cartItems = this.myService.getCartItems();
    this.calculateTotal();
  }

  calculateTotal() {
    this.totalAmount = this.myService.calculateTotal();
  }

  addToCart(product: Products) {
    this.myService.addToCart(product);
    this.loadCart();
  }

  removeFromCart(productId: number) {
    this.myService.removeFromCart(productId);
    this.loadCart();
  }

  clearCart() {
    this.myService.clearCart();
    this.loadCart();
  }

  submitOrder() {
    
    // 1. בדיקה אם המשתמש מחובר (חובה לפני כל גישה ל-user)
    const user = this.myService.getUserLocal();
    
    if (!user) {
      this.message = 'עלייך להתחבר לפני שליחת הזמנה.';
      this.router.navigate(['/login']);
      return;
    }
    
    
    if (!user.customerCode || user.customerCode <= 0) {
        this.message = 'שגיאת נתונים: קוד הלקוח אינו חוקי. אנא התחבר מחדש.';
        this.router.navigate(['/login']);
        return;
    }
    
    console.log('CustomerCode שנשלח:', user.customerCode);
    this.message = '';
 
    const customerNameToSend = user.fullName ;

    // בדיקה על מגבלת הזמנה
    if (!this.myService.isOrderValid()) {
      this.message = 'לא ניתן לבצע הזמנה מעל 5,000 ₪. אנא הסר פריטים';

      return;
    }

    // בניית אובייקט ההזמנה הנשלח לשרת
    const today = new Date();
  
    const formattedDate = today.toISOString().split('T')[0];
    
    const order = {
      shoppingCode: 0, 
      customerCode: user.customerCode,
      CustomerName: customerNameToSend,
      orderDate: formattedDate,
      totalAmount: this.totalAmount,
      remark: "ההזמנה נשלחה",
      // שימי לב: ודאי שה-DTO ב-C# מכיל מאפיין `Products` או `ShoppingItems`
      // products: this.cartItems // החזרתי את זה לתשומת לבך
    };

    

this.myService.placeOrder(order).subscribe({
      next: (res: any) => {
          // *** התיקון בשורה הבאה: שימוש ב-Optional Chaining (?. ) ***
        this.message = res?.message || 'ההזמנה בוצעה בהצלחה!';
        
        // ודא שאת מבצעת clearCart רק אם ההזמנה הצליחה
        if (this.message === 'ההזמנה בוצעה בהצלחה!') {
 alert('תודה על הזמנתך! ההזמנה בוצעה בהצלחה.');         
            this.clearCart();
            setTimeout(() => this.router.navigate(['/']), 2000);
        }
      },
      // התיקון לבלוק ה-error כבר בוצע:
      error: (err) => {
          this.message = err.error?.message || err.error?.title || err.message || 'שגיאה בשליחת ההזמנה. בדוק את קוד הלקוח ואת חיבור השרת.';
      }
    });
  }

 
}