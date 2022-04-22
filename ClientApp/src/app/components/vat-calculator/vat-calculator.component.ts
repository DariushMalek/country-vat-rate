import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs';
import { CountryRate } from 'src/app/models/country-rate.model';
import { Country } from 'src/app/models/country.model';
import { CountryVatRateInfoService } from 'src/app/services/country-vat-rate-info/country-vat-rate-info.service';

@Component({
  selector: 'app-vat-calculator',
  templateUrl: './vat-calculator.component.html',
  styleUrls: ['./vat-calculator.component.css']
})
export class VatCalculatorComponent implements OnInit {

  countries: Country[] = [];
  rates: CountryRate[] = [];
  currentRate: any;

  constructor(private countryVatRateInfoService: CountryVatRateInfoService) { }

  ngOnInit(): void {
    this.getCountries();
  }

  getCountries(){
    this.countryVatRateInfoService.getCountries().subscribe({
      next: (data: any) => this.countries = data,
      error: (err) => console.log(err) 
    })
  }

  getCountrRate(id: number){
    this.countryVatRateInfoService.getCountryRates(id).subscribe({
      next: (data: any) => this.rates = data,
      error: (err) => console.log(err) 
    })
  }

  countrySelectedChange(event: { id: number; }){
    this.getCountrRate(event.id);
  }
}
