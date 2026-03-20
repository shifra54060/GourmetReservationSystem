import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
// OnInit – ממשק שמאפשר לקומפוננטה להריץ קוד כשהיא נטענת.
// ChangeDetectorRef – מאפשר להכריח את אנגולר לעדכן את ה־HTML כשמשנים נתונים ידנית.
import { CommonModule, CurrencyPipe } from '@angular/common';
import { MyService } from '../my-service';
import { Router } from '@angular/router';
import { Products } from '../models/products';
import { Category } from '../models/category';

@Component({
    selector: 'app-product-list',
    standalone: true,
    imports: [
        CommonModule,
        CurrencyPipe
    ],
    templateUrl: './product-list.html',
    styleUrls: ['./product-list.css'],
})
export class ProductList implements OnInit {

    serverBaseUrl: string = 'https://localhost:7228';
    products: Products[] = [];// products – כל המוצרים מהשרת
    filteredProducts: Products[] = []; // filteredProducts – המוצרים לאחר סינון
    categories: Category[] = []; // רשימת הקטגוריות מהשרת
    sizes: string[] = [];// רשימת המידות הקיימות בפועל במוצרים
    sortAscending = true;//   מצב מיון המחירים (עולה/יורד).


    currentCategoryCode: number = 0;
    currentCategoryName: string = '';
    categoryImages: any = {

        0: '/assets/home/all.webp',
        9: '/assets/home/salat.jpg',
        10: '/assets/home/fish.jpg',
        11: '/assets/home/food.jpg',
        12: '/assets/home/morning.jpg',
        13: '/assets/home/milk.jpg',
        14: '/assets/home/tevon.jpg',
        16: '/assets/home/desert.webp',
        15: '/assets/home/drink.jpg',
        //   זה המיפוי של קודי הקטגוריות לתמונות הרקע המתאימות.
    };



    constructor(
        public myService: MyService,
        private router: Router,
        private cdr: ChangeDetectorRef // זה בשביל שינוי הdom  ידני כמו רענון
    ) { }
    // דברים שמתרחשים כשעמוד נטען
    ngOnInit(): void {
        this.loadProducts();
        this.loadCategories();
    }

    loadCategories() {
        this.myService.loadCategories().subscribe({
            next: (data: Category[]) => {
                // וודא שהנתונים הם מערך
                this.categories = Array.isArray(data) ? data : [];

                this.cdr.detectChanges(); // detectChanges() – גורם ל־HTML להתעדכן מייד
            },
        });
    }

    loadProducts() {
        this.myService.getProducts().subscribe({
            next: (data: Products[]) => {
                const receivedProducts = Array.isArray(data) ? data : [];
                this.products = receivedProducts;
                this.filteredProducts = [...this.products];// יצירת העתק של כל המוצרים כדי להציג אותם במסך.
                //     Array.from- ממיר את ה־Set בחזרה למערך רגיל שניתן לעבוד איתו.   new Set -יוצר מבנה נתונים שמוחק כפילויות
                this.sizes = Array.from(new Set(this.products.map(p => p.size ?? "")));
                this.cdr.detectChanges();
            },
        });
    }

    // event הוא אובייקט שמכיל את כל המידע על האירוע שהתרחש (change).
    filterByCategory(event: Event) {
        const categoryCode = +(event.target as HTMLSelectElement).value;
        this.currentCategoryCode = categoryCode;

        const selectedCat = this.categories.find(c => c.categoryCode === categoryCode);
        this.currentCategoryName = selectedCat ? selectedCat.name : '';

        this.cdr.detectChanges();

        if (categoryCode === 0) {
            this.filteredProducts = [...this.products];
            this.cdr.detectChanges();
            return;
        }

        this.myService.getByCategory(categoryCode).subscribe({
            next: (data) => {
                this.filteredProducts = Array.isArray(data) ? data : [];
                this.cdr.detectChanges();
            },
        });
    }

    filterBySize(event: Event) {
        const size = (event.target as HTMLSelectElement).value;
        if (size === 'All') {
            this.filteredProducts = [...this.products];
            return;
        }
        this.filteredProducts = this.products.filter(p => p.size === size);
        this.cdr.detectChanges();
    }

    sortByPrice() {
        this.sortAscending = !this.sortAscending;
        this.filteredProducts.sort((a, b) =>
            this.sortAscending ? a.price - b.price : b.price - a.price
        );
        this.cdr.detectChanges();
    }

    goToDetails(productId: number) {
        this.router.navigate(['/product-details', productId]);
    }

    // ----------------- פונקציה להחזרת תמונה לפי קטגוריה -----------------
    getCategoryImage(): string {

        return this.categoryImages[this.currentCategoryCode] || '/assets/home/home (11).webp';
    }

}