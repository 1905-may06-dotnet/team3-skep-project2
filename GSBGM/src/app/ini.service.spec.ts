import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { IniService } from './ini.service';

describe('IniService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports:[HttpClientTestingModule],
    providers:[IniService]
  }));

  it('should be created', () => {
    const service: IniService = TestBed.get(IniService);
    expect(service).toBeTruthy();
  });
});
