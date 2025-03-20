import { Injectable } from "@angular/core";
import { catchError, Observable, throwError } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Buy } from "../classes/Buy";
import { ProdService } from "./Product.service";


@Injectable({
    providedIn: 'root'
})
export class BuyService {
    constructor(public server: HttpClient, public P: ProdService) { }
// הוספת המוצר
    AddOrder(id: number, buy: Record<number, number>, sum: number): Observable<number> {
        let buyString = JSON.stringify(buy);
        console.log(encodeURIComponent(buyString));
        const url = `https://localhost:7085/api/BuyControllers/HandelBuy/${id}?buy=${encodeURIComponent(buyString)}&sum=${sum}`;
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        });

        return this.server.post<number>(url, { buy: buyString, sum }, { headers }).pipe(
            catchError(error => {
                console.error('Error occurred:', error);
                return throwError(() => new Error('Something went wrong!'));
            })
        );
    }
// הנחה
    Discount(sum: number, umount: number): Observable<number> {
        const url = `https://localhost:7085/api/BuyControllers/getDiscount?sum=${sum}&umount=${umount}`;
        return this.server.get<number>(url); 
    }
// יבואי לפי קוד מוצר
    ById(id: any): Observable<Array<Buy>> {
        const url = `https://localhost:7085/api/BuyControllers/${id}`;
        return this.server.get<Array<Buy>>(url); 
    }
// יבואי לפי קוד קניה
    ByBuyId(id: any): Observable<Array<Buy>> {
        const url = `https://localhost:7085/api/BuyDetailControllers/${id}`;
        return this.server.get<Array<Buy>>(url); 
    }
}
