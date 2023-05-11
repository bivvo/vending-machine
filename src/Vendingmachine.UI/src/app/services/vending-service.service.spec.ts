import { TestBed } from '@angular/core/testing';

import { VendingServiceService } from './vending-service.service';

describe('VendingServiceService', () => {
  let service: VendingServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VendingServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
