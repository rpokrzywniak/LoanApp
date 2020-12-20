import { Component, ViewChild } from '@angular/core';
import { Amortization } from '../models/amortization-model';
import { Loan } from '../models/loan-model';
import { LoanService } from '../services/loan.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatTabGroup } from '@angular/material';
import { AmortizationMethod } from '../models/amortization-method-interface';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  loanTypes: Loan[];
  amortizationMethods: AmortizationMethod[];
  selectedLoanType: Loan;
  maxAmount = 1000000;
  maxPeriod = 360;
  minAmount = 1;
  minPeriod = 1;

  @ViewChild("tabGroup", { static: false }) tabGroup: MatTabGroup;

  constructor(private loanService: LoanService) { }

  ngOnInit() {
    this.loanService.getLoanTypes().subscribe(result => this.loanTypes = result);
    this.loanService.getAmortizationMethods().subscribe(result => {
      this.amortizationMethods = result;
    });
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

  checkAmount() {
    if (this.selectedLoanType.amount > this.maxAmount) {
      this.selectedLoanType.amount = this.maxAmount;
    }
    else if (this.selectedLoanType.amount < this.minAmount) {
      this.selectedLoanType.amount = this.minAmount;
    }

    this.selectedLoanType.amount = +this.selectedLoanType.amount.toFixed();
  }

  checkPeriod() {
    if (this.selectedLoanType.period > this.maxPeriod) {
      this.selectedLoanType.period = this.maxPeriod;
    }
    else if (this.selectedLoanType.period < this.minPeriod) {
      this.selectedLoanType.period = this.minPeriod;
    }

    this.selectedLoanType.period = +this.selectedLoanType.period.toFixed();
  }

  calculateLoan() {
    this.selectedLoanType.amortization = null;
    this.loanService.calculateLoan(this.selectedLoanType).subscribe(amortization => {
      this.selectedLoanType.amortization = new MatTableDataSource<Amortization>(amortization.amortizationSchedule);
      this.selectedLoanType.monthlyPayment = amortization.monthlyPayment;
      this.selectedLoanType.totalInterest = amortization.totalInterest;
      this.selectedLoanType.total = amortization.total;
      this.tabGroup.selectedIndex = this.selectedLoanType.amortizationMethod + 1;
    });
  }

  setDefaultAmortizationMethod() {
    this.selectedLoanType.amortizationMethod = 0;
    if (!this.selectedLoanType.amount) {
      this.selectedLoanType.amount = this.minAmount;
    }
    if (!this.selectedLoanType.period) {
      this.selectedLoanType.period = this.minPeriod;
    }
  }

  resetAmortization() {
    this.selectedLoanType.amortization = null;
  }
}
