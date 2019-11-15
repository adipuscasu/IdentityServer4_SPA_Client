import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';
import { Role } from '../permissions/permissions.service';
import { AuthService } from 'src/app/core/auth/auth.service';

@Directive({
  selector: '[isspaRoleContentDisplay]'
})
export class RoleContentDisplayDirective {
  @Input('isspaRoleContentDisplay')
  private readonly role: Role;

  constructor(
      private readonly _templateRef: TemplateRef<any>,
      private readonly _viewContainerRef: ViewContainerRef,
      private readonly _authService: AuthService
  ) {

  }

  public ngOnInit() {
      // if no role is provided -> maybe we need to show it for all roles
      if (!this.role) {
          this._viewContainerRef.createEmbeddedView(this._templateRef);
          return;
      }

      const loggedUser = this._authService.currentUserValue;
      const loggedUserRole = loggedUser.group.progId as Role;

      if (loggedUserRole === this.role)
          this._viewContainerRef.createEmbeddedView(this._templateRef);
      else
          this._viewContainerRef.clear();
  }
}
