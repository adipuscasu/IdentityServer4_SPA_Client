import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UserComponent } from './user/user.component';
import { UsersComponent } from './users.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { TranslateModule } from '@ngx-translate/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [UserComponent, UsersComponent],
  imports: [
    CommonModule,
    FontAwesomeModule,
    TranslateModule.forChild(),
    FormsModule,
    ReactiveFormsModule,
    UsersRoutingModule,
    SharedModule
  ],
  entryComponents: [
    UsersComponent
  ]
})
export class UsersModule { }
