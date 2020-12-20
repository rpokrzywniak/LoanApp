import { Component, ElementRef, Input, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { MatPaginator } from '@angular/material';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Loan } from '../models/loan-model';

@Component({
  selector: 'app-amortization-schedule',
  templateUrl: './amortization-schedule.component.html',
  styleUrls: ['./amortization-schedule.component.css']
})
export class AmortizationScheduleComponent implements OnInit {
  @Input()
  selectedLoanType: Loan;

  displayedColumns: string[] = ['period', 'startingBalance', 'interest', 'principal', 'remainingBalance'];
  private unsubscribe$ = new Subject<void>();

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChildren("matTable") table: QueryList<ElementRef>;

  constructor() { }

  ngOnInit() {

  }

  ngAfterViewInit() {
    this.selectedLoanType.amortization.paginator = this.paginator;
  }

  ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
