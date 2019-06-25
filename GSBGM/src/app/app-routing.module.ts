import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { ProfileComponent } from './profile/profile.component';

import { FormsModule } from '@angular/forms';
const routes: Routes = [
  { path: '', redirectTo: '/signUp', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'signUp', component: SignUpComponent },
  { path: 'profile', component: ProfileComponent}
];

@NgModule({
  declarations: [],
  imports: [ RouterModule.forRoot(routes),FormsModule ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
