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
  public loginURL = "http://gsbgma.azurewebsites.net/api/login/validate";
  user: User;
  UserExist: boolean = false;
  constructor(
    private LoginService:LoginService,
    public http: HttpClient
  ) { }


  ValidateUser():void{
    var User = JSON.stringify({"Username":this.user.Username});  
    //console.log(this.user.Username);
    this.LoginService.LoginUserHTTP(this.loginURL,User)
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


  ngOnInit() {
    this.user = new User();
  }

}
