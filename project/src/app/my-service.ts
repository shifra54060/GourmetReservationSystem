import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, of, tap } from 'rxjs';
import { Products } from './models/products';
import { Category } from './models/category';
import { Customers } from './models/customers';
import { Table } from './models/table';

@Injectable({
  providedIn: 'root',
})
export class MyService {
  private STORAGE_KEY = 'customer';

  // ----- כתובות שרת -----
  private baseUrl = "https://localhost:7228";
  private tablesApi = `${this.baseUrl}/api/Table`;
  private customersApi = `${this.baseUrl}/api/Customer`;
  private productsApi = `${this.baseUrl}/api/Products`;
  private categoriesApi = `${this.baseUrl}/api/Category`;
  private ordersApi = `${this.baseUrl}/api/Shopping`;
  private shoppingDetailApi = `${this.baseUrl}/api/ShoppingDetail`;

  // ----- סל -----
  cartItems: any[] = [];

  // ----- לוקאפ cache -----
  private categoriesCache: Category[] = [];
  private tablesCache: Table[] = [];

  constructor(private http: HttpClient) {
    const savedCart = localStorage.getItem('cart');
    if (savedCart) this.cartItems = JSON.parse(savedCart);
  }

  // -------------------------------------------------------
  //                לקוחות
  // -------------------------------------------------------
  register(user: Customers): Observable<Customers> {
    return this.http.post<Customers>(`${this.customersApi}/ByCustomer`, user);
  }

  login(email: string): Observable<Customers> {
    return this.http.get<Customers>(`${this.customersApi}/ByEmail/${email}`);
  }

  saveUserLocal(user: Customers) {
    localStorage.setItem(this.STORAGE_KEY, JSON.stringify(user));
  }

  getUserLocal(): Customers | null {
    const data = localStorage.getItem(this.STORAGE_KEY);
    return data ? JSON.parse(data) : null;
  }

  isLoggedIn(): boolean {
    return this.getUserLocal() !== null;
  }

  logout() {
    localStorage.removeItem(this.STORAGE_KEY);
  }

  // -------------------------------------------------------
  //                סל קניות
  // -------------------------------------------------------
  addToCart(product: Products) {
    const existing = this.cartItems.find(item => item.productCode === product.productCode);
    if (existing) existing.quantity++;
    else this.cartItems.push({ ...product, quantity: 1 });
    this.saveCart();
  }

  removeFromCart(productCode: number) {
    const index = this.cartItems.findIndex(item => item.productCode === productCode);
    if (index > -1) {
      const item = this.cartItems[index];
      if (item.quantity > 1) item.quantity--;
      else this.cartItems.splice(index, 1);
    }
    this.saveCart();
  }

  clearCart() {
    this.cartItems = [];
    this.saveCart();
  }

  getCartItems(): any[] {
    return this.cartItems;
  }

  calculateTotal(): number {
    return this.cartItems.reduce((sum, item) => sum + (item.price * item.quantity), 0);
  }

  isOrderValid(): boolean {
    return this.calculateTotal() <= 5000;
  }

  private saveCart() {
    localStorage.setItem('cart', JSON.stringify(this.cartItems));
  }

  placeOrder(order: any): Observable<any> {
    return this.http.post<any>(this.ordersApi, order);
  }

  //   placeshoppingDetail(shoppingDetail: any): Observable<any> {
  //   return this.http.post<any>(this.shoppingDetailApi, shoppingDetail);
  // }

  // -------------------------------------------------------
  //                מוצרים וקטגוריות
  // -------------------------------------------------------
  getProducts(): Observable<Products[]> {
    return this.http.get<Products[]>(this.productsApi);
  }

  getByCategory(categoryCode: number): Observable<Products[]> {
    return this.http.get<Products[]>(`${this.productsApi}/ByCategoryCode/${categoryCode}`);
  }

  // -------------------------------------------------------
  //                טבלאות לוקאפ
  // -------------------------------------------------------
  loadCategories(): Observable<Category[]> {
    // כאן אנחנו בודקים אם כבר יש נתונים שמורים במטמון
    if  (this.categoriesCache.length > 0) {
      // אם כן, אין צורך לעשות קריאה לשרת. פשוט מחזירים את הנתונים מהמטמון
      return of(this.categoriesCache);
    }
    return this.http.get<Category[]>(this.categoriesApi).pipe(
      tap(data => this.categoriesCache = data)
    );
  }

  loadTables(): Observable<Table[]> {
    if (this.tablesCache.length > 0) {
      return of(this.tablesCache);
    }
    return this.http.get<Table[]>(this.tablesApi).pipe(
      tap(data => this.tablesCache = data)
    );
  }

  updateTableStatus(tableId: number, isOccupied: boolean): Observable<void> {
    let params = new HttpParams()
      .set('tableId', tableId.toString())
      .set('isOccupied', isOccupied.toString());

    return this.http.post<void>(`${this.tablesApi}/ByStatusAndId`, null, { params });
  }
}
