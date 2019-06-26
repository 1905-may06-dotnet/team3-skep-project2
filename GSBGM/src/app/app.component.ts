import { Component,OnInit } from '@angular/core';
import {IniService} from './ini.service';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { game, location} from './models';

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
      console.log(HttpResponse.body);
      if(HttpResponse.status==200)
      {
        localStorage.setItem("Games",JSON.stringify(HttpResponse.body));
      }
    })
  }

  GetAllLocations():void{
    this.IniService.IniHTTP("GetAllLocations")
    .subscribe((HttpResponse) => {
      console.log(HttpResponse.body);
      if(HttpResponse.status==200)
      {
        localStorage.setItem("Locations",JSON.stringify(HttpResponse.body));
      }
    })
  }
  
  ngOnInit() {
    this.GetAllGames();
    this.GetAllLocations();
  };
}
