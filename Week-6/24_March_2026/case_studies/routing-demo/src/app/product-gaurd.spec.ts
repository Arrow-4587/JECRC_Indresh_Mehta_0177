import { TestBed } from '@angular/core/testing';

import { ProductGaurdService } from './product-gaurd.service';

describe('ProductGaurd', () => {
  let service: ProductGaurdService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductGaurdService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
