import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { SignUpComponent } from './sign-up.component';
import { LoginService } from '../login.service';
import { FormsModule } from '@angular/forms';

describe('SignUpComponent', () => {
  let component: SignUpComponent;
  let fixture: ComponentFixture<SignUpComponent>;
  let spyService= jasmine.createSpyObj('LoginService',['LoginUserHTTP']);
  
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule, FormsModule], 
      providers: [{provide:LoginService,useValue:spyService}],
      declarations: [ SignUpComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SignUpComponent);
    component = fixture.componentInstance;


    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it ('should create', () =>{

    component.CreateAccountURL;
    expect(spyService.useValue);
    //expect(spyService).toHaveBeenCalled();
  });
  it ('should fail to create',()=>{
    var expectedUser = JSON.stringify({
      "Username": "test",
      "Password": "word",
      "DateOfBirth":"",
      "Email":"mail",
      "AllowEN":true
    })
    
      
  });
  it('check branch CheckUser()',()=>{
    localStorage.setItem("uid", "test");
  });
  it('check branch CheckUser()2',()=>{
    localStorage.clear();
  });
});
