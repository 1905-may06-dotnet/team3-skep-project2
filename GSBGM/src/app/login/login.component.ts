import { Component, OnInit, Input} from '@angular/core';
import {User} from '../user';
import {LoginService} from '../login.service';
import { UpdateService } from '../update.service';
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
  public LoggedInUser;
  LoggedIn: boolean;
  IdentityCheck:boolean;

  constructor(
    private UpdateService:UpdateService,
    private LoginService:LoginService,
    public http: HttpClient,
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
    localStorage.removeItem("username");
    localStorage.removeItem("UserInfo");
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
        localStorage.setItem("username",this.user.Username);       
        localStorage.setItem("uid", HttpResponse.body.toString());
        this.LoggedInUser=HttpResponse.body.toString();
        this.GetUserInfo();
        this.IdentityCheck=true;
      }
      else{this.IdentityCheck=false;}
    }
    )
    console.log(this.IdentityCheck);
  }
  GetUserInfo():void{
    this.user.Username = localStorage.getItem("username");
    var User = JSON.stringify(this.user);
    this.UpdateService.UpdateUserHTTPPost("GetUserInfo",User)
     .subscribe((HttpResponse) => {
        if(HttpResponse.status==200){
          localStorage.setItem("UserInfo", JSON.stringify(HttpResponse.body));
        }
     })
  }
  ngOnInit() {
    this.user = new User();
  }
}
