import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigurationService } from './configuration.service';
import { switchMap } from 'rxjs/operators';
import { Loan } from '../models/loan-model';
import { Observable } from 'rxjs';
import { AmortizationSchedule } from '../models/amortization-schedule-model';
import { AmortizationMethod } from '../models/amortization-method-interface';

@Injectable({
  providedIn: 'root'
})
export class LoanService {
  private readonly loanUrl = 'loan';
  private readonly amortizationUrl = `${this.loanUrl}/amortization`

  constructor(private configurationService: ConfigurationService, private http: HttpClient) { }

  getLoanTypes(): Observable<Loan[]> {
    return this.configurationService.baseUrl.pipe(switchMap(baseUrl => this.http.get<Loan[]>(baseUrl + this.loanUrl)));
  }

  getAmortizationMethods(): Observable<AmortizationMethod[]> {
    return this.configurationService.baseUrl.pipe(switchMap(baseUrl => this.http.get<AmortizationMethod[]>(baseUrl + this.amortizationUrl)));
  }

  calculateLoan(loan: Loan): Observable<AmortizationSchedule> {
    return this.configurationService.baseUrl.pipe(switchMap(baseUrl => this.http.post<AmortizationSchedule>(baseUrl + this.loanUrl, loan)));
  }
}
