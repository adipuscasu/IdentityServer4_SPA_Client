import { Component, OnInit } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { ICellRendererParams } from 'ag-grid-community';
import * as _ from 'lodash';

@Component({
  selector: 'isspa-icon-cell-renderer',
  templateUrl: './icon-cell-renderer.component.html',
  styleUrls: ['./icon-cell-renderer.component.scss']
})
export class IconCellRendererComponent implements ICellRendererAngularComp {
  private _params: ICellRendererParams;
  private _column: IColumn;

  public active: boolean = false;
  public trueIcon: Array<string> = ['fas', 'check-circle'];
  public falseIcon: Array<string> = ['fas', 'ban'];
  public trueIconColor: string = 'text-success';
  public falseIconColor: string = 'text-danger';

  constructor() { }

  public agInit(params: ICellRendererParams) {
      this._params = params;

      this.active = !!this._params.value;
      this._column = _.get(params, 'columnDefinition');

      this.processColumnSettings();
  }

  private processColumnSettings() {
      if (!this._column)
          return;

      if (!this._column.BooleanOptions)
          return;

      this.trueIcon = this._column.BooleanOptions.TrueIcon || null;
      this.falseIcon = this._column.BooleanOptions.FalseIcon || null;
      this.trueIconColor = this._column.BooleanOptions.TrueIconColor || '';
      this.falseIconColor = this._column.BooleanOptions.FalseIconColor || '';

  }

  public refresh(params: any): boolean {
      this._params = params;

      this.active = !!this._params.value;

      return true;
  }

}
