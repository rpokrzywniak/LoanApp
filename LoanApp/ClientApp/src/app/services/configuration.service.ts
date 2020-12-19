import { Inject, Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {

  public baseUrl = new ReplaySubject<string>();

  constructor(@Inject('BASE_URL') baseUrl: string) {
    this.baseUrl.next(baseUrl);
  }
}
