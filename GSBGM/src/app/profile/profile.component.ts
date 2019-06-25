import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { FormsModule } from '@angular/forms';
import { UpdateService } from '../update.service';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  user:User;
  username:string;
  email:string;
  phone: string;
  password: string;
  constructor(
    private UpdateService:UpdateService,
    public http: HttpClient,
  ) { }
  ngOnInit() {
    this.user = new User();
    this.user.Username = localStorage.getItem("username");
  }
  UpdateUserName():void{
    this.user.New = this.username;
    this.user.Username = localStorage.getItem("username");
    var User = JSON.stringify(this.user);
    console.log(User)
    this.UpdateService.UpdateUserHTTP("UpdateUserName",User)
     .subscribe((HttpResponse) => {
        console.log(HttpResponse);
        if(HttpResponse.status==202){
          localStorage.setItem("username", this.username)
        }
     })
  }
  UpdateEmail():void{
    this.user.New = this.email;
    this.user.Username = localStorage.getItem("username");
    var User = JSON.stringify(this.user);
    console.log(User)
    this.UpdateService.UpdateUserHTTP("UpdateUserEmail",User)
     .subscribe((HttpResponse) => {
        console.log(HttpResponse);
        if(HttpResponse.status==202){
          console.log("good")
        }
     })
  }
  UpdatePhone():void{
    this.user.New = this.phone;
    this.user.Username = localStorage.getItem("username");
    var User = JSON.stringify(this.user);
    console.log(User)
    this.UpdateService.UpdateUserHTTP("UpdateUserPhone",User)
     .subscribe((HttpResponse) => {
        console.log(HttpResponse);
        if(HttpResponse.status==202){
          console.log("good")
        }
     })
  }
}
