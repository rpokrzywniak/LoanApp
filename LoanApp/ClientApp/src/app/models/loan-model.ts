import { MatTableDataSource } from "@angular/material";
import { Amortization } from "./amortization-model";
import { Schedule } from "./schedule-model";

export class Loan extends Schedule {
  name: string;
  interestRate: number;
  amount: number;
  period: number;
  amortizationMethod: number;
  amortization: MatTableDataSource<Amortization>;
}
