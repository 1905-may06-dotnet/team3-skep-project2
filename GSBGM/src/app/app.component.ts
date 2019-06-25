import { Component,OnInit } from '@angular/core';
import {IniService} from './ini.service';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'GSBGM';
  LoggedIn:boolean;
  locLog:string= localStorage.getItem("uid");
  constructor(
    private IniService:IniService,
    public http: HttpClient,
  ){};
  GetAllGames():void{
    this.IniService.IniHTTP("GetAllGames")
    .subscribe((HttpResponse) => {
      console.log(HttpResponse);
      if(HttpResponse.status==200)
      {
        localStorage.setItem("Games",HttpResponse.body);
      }
    })
  }
  GetAllLocations():void{
    this.IniService.IniHTTP("GetAllLocations")
    .subscribe((HttpResponse) => {
      console.log(HttpResponse);
      if(HttpResponse.status==200)
      {
        localStorage.setItem("Locations",HttpResponse.body);
      }
    })
  }
  ngOnInit() {};

}
