export class Table{
     tableId: number;
  tableNumber: number;
  seats: number;
  isOccupied: boolean;

  constructor(tableId: number, tableNumber: number, seats: number, isOccupied: boolean){
    this.tableId = tableId;
    this.tableNumber = tableNumber;
    this.seats = seats;
    this.isOccupied = isOccupied;
  }
}