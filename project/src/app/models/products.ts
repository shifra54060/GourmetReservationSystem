  export class Products {
  productCode: number;
  name: string;
  categoryCode: number;
  categoryName: string;
  description: string;
  price: number;
  imageUrl: string;
  size?: string;
  isVegan?: boolean;
  isGlutenFree?: boolean;
             
   constructor(productCode:number,name:string, categoryCode:number,categoryName:string,description:string,price:number,
    imageUrl:string ,isVegan:boolean, isGlutenFree: boolean,size:string){
        this.productCode = productCode;
        this.name = name;  
        this.categoryCode = categoryCode;
        this.categoryName=categoryName
        this.description = description;
        this.price = price;
        this.imageUrl = imageUrl;
        this.isVegan = isVegan;
        this.isGlutenFree = isGlutenFree;
        this.size = size;
   }
}
