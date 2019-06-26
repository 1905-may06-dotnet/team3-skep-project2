import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { Observer, Observable, fromEventPattern, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class IniService {
  
  baseUrl:string="http://gsbgma.azurewebsites.net/api/Ini/";
  
  constructor(public http: HttpClient) { }
  
  IniHTTP(URL:string,result?:any): Observable<HttpResponse<string>> {
    return this.http.get(this.baseUrl+URL, {headers: new HttpHeaders({'Content-Type': 'application/json'}), observe: 'response'})
    .pipe(
      catchError(this.handleError('LoginUser',result))
    );  
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
