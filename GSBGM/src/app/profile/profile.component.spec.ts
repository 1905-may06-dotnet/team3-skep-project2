import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ProfileComponent } from './profile.component';
import { FormsModule } from '@angular/forms';
import { UpdateService } from '../update.service';

describe('ProfileComponent', () => {
  let component: ProfileComponent;
  let fixture: ComponentFixture<ProfileComponent>;
  let spyService= jasmine.createSpyObj('UpdateService',['UpdateUserHTTP']);
  
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule,HttpClientTestingModule],
      providers:[{provide:UpdateService,useValue:spyService}],
      declarations: [ ProfileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('spy on side effects of void on email',()=>{
    spyOn(console,'error');
    component.UpdateEmail();
    expect(console.error).not.toHaveBeenCalledWith();
  });
  it('spy on side effects of void on Phone',()=>{
    spyOn(console,'error');
    component.UpdatePhone();
    expect(console.error).not.toHaveBeenCalledWith();
  });
  it('spy on side effects of void on EN',()=>{
    spyOn(console,'error');
    component.UpdateAllowEN();
    expect(console.error).not.toHaveBeenCalledWith();
  });
  it('spy on side effects of void PN',()=>{
    spyOn(console,'error');
    component.UpdateAllowPN();
    expect(console.error).not.toHaveBeenCalledWith();
  });
});
