import { TestBed } from '@angular/core/testing';

import { IniService } from './ini.service';

describe('IniService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: IniService = TestBed.get(IniService);
    expect(service).toBeTruthy();
  });
});
