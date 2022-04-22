import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CountryVatRateInfoService {

  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }


  getCountries() {
    return this.http.get(this.baseUrl + 'countries');
  }

  getCountryRates(id: number) {
    return this.http.get(this.baseUrl + 'countries/getRates/' + id);
  }
}
