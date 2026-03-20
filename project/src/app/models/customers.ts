export class Customers {
   customerCode:number;
   fullName: string;
   phoneNumber:string;
    address:string ;
   email:string;
   birthDate:string;
   constructor( customerCode:number, fullName: string,  phoneNumber:string,address:string,email:string,birthDate:string){
    this.customerCode=customerCode;
    this.fullName=fullName;
    this.phoneNumber=phoneNumber;
    this.address=address;
    this.email=email;
    this.birthDate=birthDate
   }

}
