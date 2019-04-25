import { HomePageComponent } from './pages/home-page/home-page.component';
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from '@angular/router';
import { LoginPageComponent } from "./pages/account/login-page/login-page.component";
import { SignupPageComponent } from "./pages/account/signup-page/signup-page.component";
import { ResetPasswordPageComponent } from "./pages/account/reset-password-page/reset-password-page.component";
import { FramePageComponent } from './pages/shared/master/frame.page';

const routes: Routes = [

  {
    path: '',
    component: FramePageComponent,
    children: [
      { path: '', component: HomePageComponent }
    ]
  },

  {
    path: 'login',
    component: LoginPageComponent
  },
  {
    path: 'signup',
    component: SignupPageComponent
  },
  {
    path: 'reset-password',
    component: ResetPasswordPageComponent
  },
  {
    path: 'tratamentos', component: FramePageComponent,
    loadChildren: './pages/tratamentos/tratamento.module#TratamentoModule'
  }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }