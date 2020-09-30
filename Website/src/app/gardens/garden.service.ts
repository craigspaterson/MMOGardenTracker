import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpHeaders,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';

import { Garden } from './garden';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class GardenService {
  // private url = 'api/gardens';
  private url: string = environment.gardenTrackerServiceUrl + 'api/gardens';

  constructor(private http: HttpClient) {}

  getGardens(): Observable<Garden[]> {
    return this.http
      .get<Garden[]>(this.url, httpOptions)
      .pipe(catchError(this.handleError));
  }

  getGardenByGardenId(gardenId: number): Observable<Garden> {
    return this.http
      .get<Garden>(this.url + `/${gardenId}`, httpOptions)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` + `body was: ${error.error}`
      );
    }
    // return an observable with a user-facing error message
    return throwError('Something bad happened; please try again later.');
  }
}
