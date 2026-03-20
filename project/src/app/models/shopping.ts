import { Data } from "@angular/router";

export class Shopping {
    shoppingCode:number;
    customerCode:number;
    customerName:string;
    orderDate:Data;
    totalAmount:number;
    remark:string;
    constructor(shoppingCode:number,customerCode:number,customerName:string,orderDate:Data, totalAmount:number,remark:string)
    {
this.shoppingCode=shoppingCode;
this.customerCode=customerCode;
this.customerName=customerName;
this.orderDate=orderDate;
this.totalAmount=totalAmount;
this.remark=remark

    }
}
