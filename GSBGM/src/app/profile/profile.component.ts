import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { FormsModule } from '@angular/forms';
import { UpdateService } from '../update.service';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Location } from '../location';
import { GetUser } from '../getUser';
import { BoardGame } from '../boardgame';
import{UserCollection} from '../userCollection';
import { getDefaultService } from 'selenium-webdriver/opera';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  user:User;
  EmailU: boolean = false;
  PhoneU: boolean = false;
  AllowPNU: boolean = false;
  AllowENU: boolean = false;
  LocationU: boolean = false;
  AddGameU: boolean = false;
  newItem:UserCollection;
  LocationName:string;
  LocationList:Location[]=JSON.parse(localStorage.getItem("Locations"));
  UserInfo:GetUser=JSON.parse(localStorage.getItem("UserInfo"));
  BoardGameList:BoardGame[]=JSON.parse(localStorage.getItem("Games"));
  constructor(
    private UpdateService:UpdateService,
    public http: HttpClient,
  ) { }
  ngOnInit() {
    this.user = new User();
    this.newItem=new UserCollection
    this.GetUserInfo();
    this.LocationName=this.Convert(this.UserInfo.lid);
  }
  UpdateEmail():void{  
    this.user.Username = localStorage.getItem("username");
    var User = JSON.stringify(this.user);
    console.log(User)
    this.UpdateService.UpdateUserHTTPPut("UpdateEmail",User)
     .subscribe((HttpResponse) => {
        console.log(HttpResponse);
        if(HttpResponse.status==202){
          this.EmailU = true;
          console.log("good")
        } else {
          this.EmailU = false;
        }
     })
     this.GetUserInfo();
  }
  UpdatePhone():void{
    this.user.Username = localStorage.getItem("username");
    var User = JSON.stringify(this.user);
    console.log(User)
    this.UpdateService.UpdateUserHTTPPut("UpdatePhone",User)
     .subscribe((HttpResponse) => {
        console.log(HttpResponse);
        if(HttpResponse.status==202){
          this.PhoneU = true;
          console.log("good")
        } else {
          this.PhoneU = false;
        }
     })
     this.GetUserInfo();
  }
  UpdateAllowEN():void{
    this.user.Username = localStorage.getItem("username");
    var User = JSON.stringify(this.user);
    console.log(User)
    this.UpdateService.UpdateUserHTTPPut("UpdateAllowEN",User)
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
     this.GetUserInfo();
  }
  UpdateAllowPN():void{
    this.user.Username = localStorage.getItem("username");
    var User = JSON.stringify(this.user);
    console.log(User)
    this.UpdateService.UpdateUserHTTPPut("UpdateAllowPN",User)
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
     this.GetUserInfo();
  }
  UpdateLocation():void{
    this.user.Username = localStorage.getItem("username");
    var User = JSON.stringify(this.user);
    console.log(User)
    this.UpdateService.UpdateUserHTTPPut("UpdateLocation",User)
     .subscribe((HttpResponse) => {
        console.log(HttpResponse);
        console.log(this.user.AllowEN)
        if(HttpResponse.status==202){
          console.log("good")
          this.LocationU = true;
        } else {
          this.LocationU = false;
        }
     })
     this.GetUserInfo();
     this.LocationName=this.Convert(this.UserInfo.lid);
  }

  GetUserInfo():void{
    this.user.Username = localStorage.getItem("username");
    var User = JSON.stringify(this.user);
    console.log(User);
    this.UpdateService.UpdateUserHTTPPost("GetUserInfo",User)
     .subscribe((HttpResponse) => {
        if(HttpResponse.status==200){
            localStorage.setItem("UserInfo", JSON.stringify(HttpResponse.body));
        }
     })
     this.UserInfo=JSON.parse(localStorage.getItem("UserInfo"));
     console.log("info refreshed");
  }

  AddGame():void{
    console.log("start");
    console.log(this.UserInfo.uid)
    this.newItem.Uid = 38;//this.UserInfo.uid;
    this.newItem.Gid=this.user.newGid;
    var item = JSON.stringify(this.newItem);
    console.log(item)
    this.UpdateService.UpdateUserHTTPPost("AddGames",item)
     .subscribe((HttpResponse) => {
        if(HttpResponse.status==200){
          this.AddGameU = true;
          console.log("addgame successed");
        } else {
          this.AddGameU = false;
        }
     })

  }

  Convert(i:number):string{
    this.LocationList.forEach(element => {

      if(element.lid==i)
      {      
        console.log(element.locationName);
        return element.locationName;
      }
    });
    return "";
  }

}
