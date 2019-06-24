import { Component, OnInit, Input} from '@angular/core';
import { AppComponent } from '../app.component'
import {User} from '../user';
import {LoginService} from '../login.service';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgForm } from '@angular/forms';

const httpOptions ={
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
@Injectable({
  providedIn: 'root'
})

export class LoginComponent implements OnInit {
  public loginURL:string = "login/UserLogin";
  user: User;
  public LoggedInUID:string;
  LoggedIn: boolean;

  constructor(
    private LoginService:LoginService,
    public http: HttpClient,
    private appcomponent: AppComponent,
    ) {
      this.CheckUser();
     }
    CheckUser():void{
      if(localStorage.getItem("uid")!=null){
        this.LoggedIn = true;
      }else{
        this.LoggedIn = false;
      }
    }
    LogOutUser():void{
      localStorage.removeItem("uid");
      this.CheckUser();
    }
    LoginUser(): void {
      //construct JSON object
      var User = JSON.stringify(this.user);
      console.log(User);
    
     this.LoginService.LoginUserHTTP(this.loginURL,User)
     .subscribe((HttpResponse) => {
        console.log(HttpResponse);
        if(HttpResponse.status==202)
        {
          this.LoggedIn = true;         
          localStorage.setItem("uid", HttpResponse.body.toString())
          this.LoggedInUID=HttpResponse.body.toString();
        }
     }
     )
    }

  ngOnInit() {
    this.user = new User();
  }
}
