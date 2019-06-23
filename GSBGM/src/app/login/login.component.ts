import { Component, OnInit, Input} from '@angular/core';
import {User} from '../user';
import {LoginService} from '../login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  user: User

  constructor(private LoginService:LoginService) { }

  ngOnInit() {
    this.user = new User();
    this.user.Username = "bob";
  }
}
