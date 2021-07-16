import { TestBed } from '@angular/core/testing';

import { LogisticApiService } from './logistic-api.service';

describe('LogisticApiService', () => {
  let service: LogisticApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LogisticApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
