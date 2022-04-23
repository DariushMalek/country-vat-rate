import { Injectable } from '@angular/core';
import { Amounts } from 'src/app/models/amounts.model';

@Injectable({
  providedIn: 'root'
})
export class VatCalculatorService {

  constructor() { }

  calcByVat(vat: number, vatRate: number): Amounts {
    const net = (100 * vat) / vatRate;
    return <Amounts>{
      gross: net + vat,
      net: net,
      vat: vat
    };
  }

  calcByGross(gross: number, vatRate: number): Amounts {
    const net = Math.round(gross / (1 + vatRate / 100)) ;
    return <Amounts>{
      gross: gross,
      net: net,
      vat: gross - net
    };
  }

  calcByNet(net: number, vatRate: number): Amounts {
    const vat = (net * vatRate) / 100;
    return <Amounts>{
      gross: net + vat,
      net: net,
      vat: vat
    };
  }  
}
