import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Product } from "../classes/Product";


@Injectable({
    providedIn: 'root'
})
export class ProdService {
    constructor(public server: HttpClient) { }
// יבואי הלא מוגרלים
    getS(): Observable<Array<Product>> {
        return this.server.get<Array<Product>>('https://localhost:7085/api/Product')
    }
// יבואי המוגרלים
    getW(): Observable<Array<Product>> {
        return this.server.get<Array<Product>>('https://localhost:7085/api/Product/Rafuld')
    }
// יבואי לפי קוד מוצר
    getById(id: string): Observable<Array<Product>> {
        return this.server.get<Array<Product>>('https://localhost:7085/api/Product/' + id)
    }   
// סינונים
    filterItems(minPrice?: number, categoryName?: string): Observable<Array<Product>> {
        console.log(minPrice, categoryName);
        const url = `https://localhost:7085/api/Product/Filter!?minPrice=${minPrice !== null && minPrice !== undefined ? minPrice : ''}&CategoryName=${categoryName || ''}`;
        return this.server.get<Array<Product>>(url);
    }
    
    quantities: { [key: number]: number } = {};
    sum: number = 0;

    P: boolean = false;
    T: boolean = false;
}

