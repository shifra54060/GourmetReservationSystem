import { Component, OnInit } from '@angular/core';
import { MyService } from '../my-service';
import { Table } from '../models/table';
import { CommonModule } from '@angular/common';
import {  BehaviorSubject,Observable } from 'rxjs';
// Observable — מייצג זרם נתונים אסינכרוני.
// מעדכן מידית  את הקומפוננטות כאשר יש שינוי בנתונים
import { tap } from 'rxjs/operators';
// tap – מאפשר לבצע פעולות צדדיות בזרם הנתונים מבלי לשנות אותם.
@Component({
  selector: 'app-table',
  templateUrl: './table.html',
  styleUrls: ['./table.css'],
  standalone: true,
  imports: [CommonModule]
})
export class TablesComponent implements OnInit {
// יוצר behaviorSubject שמחזיק את רשימת השולחנות.
  private tablesSubject = new BehaviorSubject<Table[]>([]);
  tables$ = this.tablesSubject.asObservable();  // ממיר את ה־BehaviorSubject ל־Observable לשימוש ב־template עם async pipe.
// שומר את השולחן שתפוס כרגע
  selectedTableId: number | null = null;

  constructor(private myService: MyService) {}

  ngOnInit(): void {
    this.loadTables();
  }

 loadTables(): void {
  this.myService.loadTables()
    .pipe(
      tap((tables: Table[]) => { // טיפוס מוצהר ל-tables
        this.tablesSubject.next(tables);

      // מציאת השולחן התפוס אם קיים
        const occupied = tables.find((t: Table) => t.isOccupied);
        this.selectedTableId = occupied ? occupied.tableId : null;
      })
    )
    .subscribe();
}


  toggleTable(table: Table): void {
    if (table.isOccupied) return;

    // עדכון שולחן נבחר
    table.isOccupied = true;
    this.myService.updateTableStatus(table.tableId, true).subscribe();

    // שחרור השולחן הקודם אם יש
    if (this.selectedTableId !== null) {
      const tables = this.tablesSubject.getValue();
      const oldTable = tables.find(t => t.tableId === this.selectedTableId);
      if (oldTable) {
        oldTable.isOccupied = false;
        this.myService.updateTableStatus(oldTable.tableId, false).subscribe();
      }
    }

    this.selectedTableId = table.tableId;

    // עדכון ה-BehaviorSubject כדי שה-template יתעדכן
    this.tablesSubject.next(this.tablesSubject.getValue());
  }
}
