import { Component, OnInit, Input} from '@angular/core';
import {User} from '../User';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.pug',
  styleUrls: ['./sign-up.component.styl']
})
export class SignUpComponent implements OnInit {
  user: User
  constructor() { }

  ngOnInit() {
    this.user = new User();
  }

}
