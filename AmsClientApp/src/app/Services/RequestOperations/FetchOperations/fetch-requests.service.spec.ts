/* eslint-disable no-undef */
/* eslint-disable import/no-unresolved */
import { TestBed } from '@angular/core/testing';

import { FetchRequestsService } from './fetch-requests.service';

describe('FetchRequestsService', () => {
  let service: FetchRequestsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FetchRequestsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
