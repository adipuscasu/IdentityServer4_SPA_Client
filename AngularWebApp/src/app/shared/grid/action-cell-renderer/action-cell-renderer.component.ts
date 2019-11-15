import { Component, HostBinding } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { ICellRendererParams } from 'ag-grid-community';
import * as _ from 'lodash';

@Component({
  selector: 'isspa-action-cell-renderer',
  templateUrl: './action-cell-renderer.component.html',
  styleUrls: ['./action-cell-renderer.component.scss']
})
export class ActionCellRendererComponent implements ICellRendererAngularComp {
  private _gridContext: { onActionTriggered: (functionName: string, row: any) => {} };
  private _row: any;
  private _column: IColumn;
  public buttons: Array<IColumnAction>;

  @HostBinding('class') public classes: string = 'd-flex w-100 justify-content-center';
  constructor() { }

  public agInit(params: ICellRendererParams) {
      this._row = params.data;

      this._gridContext = _.get(params, 'context.component');
      this._column = _.get(params, 'columnDefinition');

      this.initColumnDefinition();
  }
  private initColumnDefinition() {
      this.buttons = this._column.Actions;
  }

  public refresh() {
      return false;
  }

  public onClick(button: IColumnAction) {
      if (!this._gridContext)
          return;

      this._gridContext.onActionTriggered(button.FunctionName, this._row);
  }

}
