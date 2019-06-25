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
  EmailU: boolean = true;
  PhoneU: boolean = true;
  AllowPNU: boolean = true;
  AllowENU: boolean = true;
  constructor(
    private UpdateService:UpdateService,
    public http: HttpClient,
  ) { }
  ngOnInit() {
    this.user = new User();
  }
  UpdateEmail():void{
    this.user.Username = localStorage.getItem("username");
    var User = JSON.stringify(this.user);
    console.log(User)
    this.UpdateService.UpdateUserHTTP("UpdateEmail",User)
     .subscribe((HttpResponse) => {
        console.log(HttpResponse);
        if(HttpResponse.status==202){
          this.EmailU = true;
          console.log("good")
        } else {
          this.EmailU = false;
        }
     })
  }
  UpdatePhone():void{
    this.user.Username = localStorage.getItem("username");
    var User = JSON.stringify(this.user);
    console.log(User)
    this.UpdateService.UpdateUserHTTP("UpdatePhone",User)
     .subscribe((HttpResponse) => {
        console.log(HttpResponse);
        if(HttpResponse.status==202){
          this.PhoneU = true;
          console.log("good")
        } else {
          this.PhoneU = false;
        }
     })
  }
  UpdateAllowEN():void{
    this.user.Username = localStorage.getItem("username");
    var User = JSON.stringify(this.user);
    console.log(User)
    this.UpdateService.UpdateUserHTTP("UpdateAllowEN",User)
     .subscribe((HttpResponse) => {
        console.log(HttpResponse);
        console.log(this.user.AllowEN)
        if(HttpResponse.status==202){
          console.log("good")
          this.AllowENU = true;
        } else {
          this.AllowENU = false;
        }
     })
  }
}
