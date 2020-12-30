import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpHeaders,
  HttpParams,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';

import { Crop } from './crop';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  params: new HttpParams({})
};

@Injectable({
  providedIn: 'root'
})
export class CropService {
  // private url = 'api/crops';
  private url: string = environment.gardenTrackerServiceUrl + 'api/crops';

  constructor(private http: HttpClient) { }

  getCrops(): Observable<Crop[]> {
    return this.http
      .get<Crop[]>(this.url, httpOptions)
      .pipe(catchError(this.handleError));
  }

  getCropByCropId(cropId: number): Observable<Crop> {
    return this.http
      .get<Crop>(this.url + `/${cropId}`, httpOptions)
      .pipe(catchError(this.handleError));
  }

  postCrop(crop: Crop): Observable<Crop> {
    return this.http
      .post<Crop>(this.url, crop, httpOptions)
      .pipe(catchError(this.handleError));
  }

  putCrop(cropId: number, crop: Crop): Observable<Crop> {
    return this.http
      .put<Crop>(this.url + `/${cropId}`, crop, httpOptions)
      .pipe(catchError(this.handleError));
  }

  deleteCrop(cropId: number): Observable<{}> {
    return this.http
      .delete(this.url + `/${cropId}`, httpOptions)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error(`An error occurred: ${error.error.message}`);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` + `body was: ${error.error}`
      );
    }

    console.log(`The error status: ${error.status}`);
    console.log(`The error message: ${error.message}`);
    console.table(error);

    // return an observable with a user-facing error message
    return throwError('Something bad happened; please try again later.');
  }
}
