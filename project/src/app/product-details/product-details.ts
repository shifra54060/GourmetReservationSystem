import { Component, OnInit, ChangeDetectorRef } from '@angular/core'; 
import { CommonModule, NgFor, CurrencyPipe } from '@angular/common';
import { MyService } from '../my-service';
import { Products } from '../models/products';
import { ActivatedRoute } from '@angular/router';// שזה האובייקט שמחזיק את המידע על ה־URL הנוכחי
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-details',
  standalone: true,
  imports: [CommonModule, NgFor, CurrencyPipe],
  templateUrl: './product-details.html',
  styleUrl: './product-details.css',
})
export class ProductDetails implements OnInit { 
 serverBaseUrl: string = 'https://localhost:7228';
  product: Products | undefined; 
  
  constructor(
    private router: Router,
    public myService: MyService, 
    private route: ActivatedRoute,
    private cdr: ChangeDetectorRef 
  ) {}

  ngOnInit(): void {
  // מפה (Map) של כל הפרמטרים מתוך ה־URL.
    this.route.paramMap.subscribe(params => {
      const productId = +(params.get('productId') ?? 0); 
      
      if (productId > 0) {
        this.loadProductDetails(productId);
      } else {
        this.product = undefined;
        this.cdr.detectChanges(); // רענון למקרה של ID לא חוקי
      }
    });
  }

  loadProductDetails(id: number) {
    console.log('1. --- החלה טעינת פרטים עבור ID:', id);
    
    this.myService.getProducts().subscribe({
        next: (data: Products[]) => {
            console.log('2. --- נתונים מהשרת הגיעו בהצלחה. סך הכל מוצרים:', data.length);
            console.log('3. --- רשימת הנתונים שהתקבלה:', data);
            
            // השוואה בטוחה: המרת productCode למספר לפני ההשוואה
            this.product = data.find(p => Number(p.productCode) === id); 
            
            if (!this.product) {
                console.warn(`4. --- אזהרה: לא נמצא מוצר עם קוד: ${id}.`);
            } else {
                console.log('5. --- הצלחה! המוצר נמצא.');
            }
            
            this.cdr.detectChanges(); // ⬅️ כפה רענון של התצוגה לאחר מציאת המוצר
        },
        error: (err) => {
            console.error('B. --- כשל קריטי ב-API (קוד שגיאה:', err.status, ')', err);
            this.product = undefined; 
            this.cdr.detectChanges(); // רענן לאחר שגיאה
        }
    });
  }
goBack() {
  this.router.navigate(['/product-list']);
}
}