import { Amortization } from "./amortization-model";
import { Schedule } from "./schedule-model";

export class AmortizationSchedule extends Schedule{
  amortizationSchedule: Amortization[];
}
