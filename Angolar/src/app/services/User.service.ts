import { Injectable } from "@angular/core";
import { catchError, Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { User } from "../classes/User";


@Injectable({
    providedIn: 'root'
})
export class UserService {
    constructor(public server: HttpClient) { }

    // בדיקה תקינות להוספת לקוח
    CkechEmail(f: User): Observable<boolean> {
        return this.server.get<boolean>("https://localhost:7085/api/User/checkUser/" + f.email);
    }
    // הוספת לקוח
    AddUser(f: User): Observable<boolean> {
        return this.server.post<boolean>("https://localhost:7085/api/User", f).pipe(
            catchError((error: HttpErrorResponse) => {
                console.error('Validation errors:', error.error.errors);
                return throwError(error);
            })
        );
    }
    // יבואי ע"י ID
    getById(id: string): Observable<Array<User>> {
        return this.server.get<Array<User>>('https://localhost:7085/api/User/' + id)
    }
    currentUser: any;
}

