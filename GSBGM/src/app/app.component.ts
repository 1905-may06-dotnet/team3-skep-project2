import { Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'GSBGM';
  LoggedIn:boolean;
  locLog:string= localStorage.getItem("uid");

}
