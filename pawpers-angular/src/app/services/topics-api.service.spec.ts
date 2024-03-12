import { TestBed } from '@angular/core/testing';

import { TopicsAPIService } from './topics-api.service';

describe('TopicsAPIService', () => {
  let service: TopicsAPIService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TopicsAPIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
