import { TestBed } from '@angular/core/testing';

import { VatCalculatorService } from './vat-calculator.service';

describe('VatCalculatorService', () => {
  let service: VatCalculatorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VatCalculatorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('calcByVat shoud return correct amounts', () => {
    const amount = service.calcByVat(5850, 13);
    const expected = {net: 45000, gross: 50850, vat: 5850}
    expect(amount).toEqual(expected);
  });

  it('calcByGross shoud return correct amounts', () => {
    const amount = service.calcByGross(50850, 13);
    const expected = {net: 45000, gross: 50850, vat: 5850}
    expect(amount).toEqual(expected);
  });

  it('calcByNet shoud return correct amounts', () => {
    const amount = service.calcByNet(45000, 13);
    const expected = {net: 45000, gross: 50850, vat: 5850}
    expect(amount).toEqual(expected);
  });
});
