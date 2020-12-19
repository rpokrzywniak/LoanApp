import { Component } from '@angular/core';
import { Loan } from '../models/loan-model';
import { LoanService } from '../services/loan.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  loanTypes: Loan[];
  selectedLoanType: string;
  amountValue: number;
  paymackValue: number;

  constructor(private loanService: LoanService) { }

  ngOnInit() {
    this.loanService.getLoanTypes().subscribe(result => this.loanTypes = result);
  }

  formatLabel(value: number) {
    if (value === 1000000) {
      return Math.round(value / 1000000) + 'kk';
    }
    else if (value >= 1000) {
      return Math.round(value / 1000) + 'k';
    }

    return value;
  }
}
