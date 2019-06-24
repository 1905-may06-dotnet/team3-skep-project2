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
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})


export class SignUpComponent implements OnInit {
  public UsernameValidationURL = "login/validate";
  public CreateAccountURL = "login/create";
  user: User;
  UserExist: boolean = false;
  LoggedIn: boolean = false;
  notLoggedIn: boolean = true;
  public LoggedInUID:string;
  constructor(
    private LoginService:LoginService,
    public http: HttpClient
  ) { }


  ValidateUser():void{
    var User = JSON.stringify({"Username":this.user.Username});  
    //console.log(this.user.Username);
    this.LoginService.LoginUserHTTP(this.UsernameValidationURL,User)
    .subscribe((HttpResponse) => {
       console.log(HttpResponse.status);
       if(HttpResponse.status!=202)
       {
        this.UserExist = true;
        console.log(this.UserExist)
       }
       else{this.UserExist = false;}
    }
    )
  }


  CreateAccount(): void {
    //construct JSON object
    var User = JSON.stringify({
      "Username":this.user.Username,
      "Password":this.user.Password,
      "DateOfBirth":this.user.DateOfBirth,
      "Email":this.user.Email,
      "AllowEN":this.user.AllowEN
    });
    console.log(User);
   this.LoginService.LoginUserHTTP(this.CreateAccountURL,User)
   .subscribe((HttpResponse) => {
      console.log(HttpResponse);
      if(HttpResponse.status==201)
      {
        this.LoggedIn = true;
        this.notLoggedIn=false;         
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
