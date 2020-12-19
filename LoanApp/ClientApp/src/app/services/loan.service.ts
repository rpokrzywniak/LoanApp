import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigurationService } from './configuration.service';
import { switchMap } from 'rxjs/operators';
import { Loan } from '../models/loan-model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoanService {

  constructor(private configurationService: ConfigurationService, private http: HttpClient) { }

  getLoanTypes(): Observable<Loan[]> {
    return this.configurationService.baseUrl.pipe(switchMap(baseUrl => this.http.get<Loan[]>(baseUrl + 'loan')));
  }

}
