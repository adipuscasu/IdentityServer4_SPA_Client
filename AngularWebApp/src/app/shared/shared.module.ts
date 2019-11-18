import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InViewportModule } from 'ng-in-viewport';

import { GridComponent } from './grid/grid.component';
import { GridService } from './grid/grid.service';
import { IconCellRendererComponent } from './grid/icon-cell-renderer/icon-cell-renderer.component';
import { ActionCellRendererComponent } from './grid/action-cell-renderer/action-cell-renderer.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ClickStopPropagationDirective } from './directives/click-stop-propagation.directive';
import { RoleContentDisplayDirective } from './directives/role-content-display.directive';
import { PermissionsService } from './permissions/permissions.service';
import { TranslateModule } from '@ngx-translate/core';
import { BreakpointDirective } from './directives/breakpoint.directive';
import { AgGridModule } from 'ag-grid-angular';



@NgModule({
  declarations: [
    GridComponent,
    IconCellRendererComponent,
    ActionCellRendererComponent,
    IconCellRendererComponent,
    ActionCellRendererComponent,
    ClickStopPropagationDirective,
    RoleContentDisplayDirective,
    BreakpointDirective
  ],
  imports: [
    CommonModule,
    InViewportModule,
    AgGridModule,
    FontAwesomeModule,
    TranslateModule.forChild(),

  ],
  providers: [
    GridService,
    PermissionsService
  ],
  exports: [
    GridComponent,
    RoleContentDisplayDirective,
    ClickStopPropagationDirective,
    BreakpointDirective,

  ]
})
export class SharedModule { }
