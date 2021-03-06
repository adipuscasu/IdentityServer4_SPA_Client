import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { RegisterComponent } from './register';
import { AuthGuard } from './core/auth/auth.guard';
import { UsersComponent } from './users/users.component';


const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard], pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthGuard] },
  { path: 'unauthorized', component: UnauthorizedComponent },
  { path: 'forbidden', component: UnauthorizedComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'users', component: UsersComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
