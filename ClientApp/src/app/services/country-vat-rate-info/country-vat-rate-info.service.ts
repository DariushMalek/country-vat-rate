import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CountryRate } from 'src/app/models/country-rate.model';
import { Country } from 'src/app/models/country.model';

@Injectable({
  providedIn: 'root'
})
export class CountryVatRateInfoService {

  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }


  getCountries(inMemory: boolean) {
    if (inMemory) {
      return this.getInMemoryCountries();
    } else {
      return this.http.get(this.baseUrl + 'countries');
    }
  }

  getCountryRates(id: number, inMemory: boolean) {
    if (inMemory) {
      return this.getInMemoryCountryRates(id);
    } else {
      return this.http.get(this.baseUrl + 'countries/getRates/' + id);
    }
  }

  getInMemoryCountries() {
    const countriesObservable = new Observable(observer => {
      setTimeout(() => {
        observer.next(countries);
      }, 10);
    });
    return countriesObservable;
  }

  getInMemoryCountryRates(id: number,) {
    const countryRatesObservable = new Observable(observer => {
      setTimeout(() => {
        observer.next(countryRates.filter(n=> n.countryId == id));
      }, 10);
    });
    return countryRatesObservable;
  }
}

const countries: Country[] = [{
  id: 1,
  countryName: 'Austria',
  isDefault: true
},
{
  id: 2,
  countryName: 'Germany',
  isDefault: false
},
{
  id: 3,
  countryName: 'United Kingdom',
  isDefault: false
}];

const countryRates: CountryRate[] = [{
  id: 1,
  rateTitle: '10%',
  rate: 10,
  countryId: 1
},
{
  id: 2,
  rateTitle: '13%',
  rate: 13,
  countryId: 1
},
{
  id: 3,
  rateTitle: '20%',
  rate: 20,
  countryId: 1
},
{
  id: 4,
  rateTitle: '5%',
  rate: 5,
  countryId: 2
},
{
  id: 5,
  rateTitle: '7%',
  rate: 7,
  countryId: 2
},
{
  id: 6,
  rateTitle: '16%',
  rate: 16,
  countryId: 2
},
{
  id: 7,
  rateTitle: '19%',
  rate: 19,
  countryId: 2
},
{
  id: 8,
  rateTitle: '5%',
  rate: 5,
  countryId: 3
},
{
  id: 9,
  rateTitle: '20%',
  rate: 20,
  countryId: 3
}
]
