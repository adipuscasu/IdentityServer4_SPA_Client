import { Component, OnInit, HostBinding, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { FormGroup, FormBuilder } from '@angular/forms';
import { GridTable } from '../_components/grid/grid.service';
import { BootstrapBreakpoints } from '../core/css-breakpoints';
import { TitleService } from '../_services/title.service';
import { Router } from '@angular/router';
import { UserService } from '../_services/user.service';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'isspa-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit, OnDestroy {
  private readonly _destroy$: Subject<void> = new Subject<void>();
  @HostBinding('class') public classes: string = 'd-flex flex-column h-100';
  public users: Array<IUser> = new Array<IUser>();
  public searchFormGroup: FormGroup;
  public gridTable: typeof GridTable = GridTable;
  public listReady: boolean = false;
  public bootstrapBreakpoint: typeof BootstrapBreakpoints = BootstrapBreakpoints;


  constructor(
    private readonly _titleService: TitleService,
    private readonly _router: Router,
    private readonly _userService: UserService,
    private readonly _formBuilder: FormBuilder,

  ) {
    this.initSearchFormGroup();
    this.getUsers();

  }

  ngOnInit() {
    this._titleService.setTitle({ title: 'USER.USER_LIST' });
    this.onChanges();
  }

  private onChanges(): void {
    this.searchFormGroup.controls['includeDeactivated']
      .valueChanges.pipe(takeUntil(this._destroy$))
      .subscribe(() => {
        this.getUsers();
      });
  }


  public ngOnDestroy() {
    this._destroy$.next();
    this._destroy$.complete();
    this._destroy$.unsubscribe();
  }

  public async getUsers() {
    this.listReady = false;
    const includeDeactivated = this.searchFormGroup.controls['includeDeactivated'].value;
    const freeText = this.searchFormGroup.controls['freeText'].value;

    this.users = await this._userService.getAll(freeText, includeDeactivated).toPromise();

    this.listReady = true;
  }

  private initSearchFormGroup() {
    this.searchFormGroup = this._formBuilder.group({
      freeText: [''],
      includeDeactivated: [false]
    });
  }
}
