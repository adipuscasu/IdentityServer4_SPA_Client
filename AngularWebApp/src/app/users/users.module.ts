import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UserComponent } from './user/user.component';
import { UsersComponent } from './users.component';


@NgModule({
  declarations: [UserComponent, UsersComponent],
  imports: [
    CommonModule,
    UsersRoutingModule,
  ],
  entryComponents: [
    UsersComponent
  ]
})
export class UsersModule { }
