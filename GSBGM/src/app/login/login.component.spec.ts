import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './login.component';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { LoginService } from '../login.service';
describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  class MockLogin{
    isLoggedIn= true;
    user={username: 'test',password: 'word'};
  }
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule,HttpClientTestingModule],
      providers: [LoginService],
      declarations: [ LoginComponent ]
    })
    .compileComponents();

  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('check branch CheckUser()',()=>{
    localStorage.setItem("uid", "test");
  });
  it('check branch CheckUser()2',()=>{
    localStorage.clear();
  });

});
