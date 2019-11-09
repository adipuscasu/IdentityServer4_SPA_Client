import { Component, OnInit, Input, Output, EventEmitter, HostBinding, DoCheck } from '@angular/core';
import * as moment from 'moment';
import { TranslateService } from '@ngx-translate/core';
import { _ } from 'ag-grid-community';
import { GridColumnType, GridTable, GridService } from '../grid.service';

@Component({
  selector: 'app-ap-grid',
  templateUrl: './ap-grid.component.html',
  styleUrls: ['./ap-grid.component.scss']
})
export class ApGridComponent implements OnInit, DoCheck {
  private _oldRows: Array<any>;
  public columnDefinitions: Array<Column> = [];
  public gridColumnType: typeof GridColumnType = GridColumnType;
  @Input() public rows: Array<any>;
  @Input() public table: GridTable;
  @Input() public actionCallbacks: Array<{ key: string, callback: Function }>;
  @Output() public selected: EventEmitter<any> = new EventEmitter<any>();
  @HostBinding('class') public classes: string = 'w-100 col-12';
  constructor(
      private readonly _gridService: GridService,
      private readonly _translateService: TranslateService
  ) { }

  public ngOnInit() {
      this.columnDefinitions = this._gridService.getColumnConfig(this.table);
  }

  public ngDoCheck() {
      if (_.isEqual(this.rows, this._oldRows))
          return;

      this._oldRows = this.rows;

      this.setIdNumeric();
  }

  private setIdNumeric() {
      if (_.isNil(this.rows) || _.isEmpty(this.rows))
          return;

      _.forEach(this.rows, r => {
          if (!r.id)
              return;

          r.Id = _.parseInt(r.id);
      });
  }

  public getHeader(item: any, columnDefinition: IColumn) {
      if (!item)
          return '';

      if (!columnDefinition)
          return '';

      return this._translateService.instant(columnDefinition.Name);
  }

  public getValue(item: any, columnDefinition: IColumn) {
      if (!item)
          return '';

      if (!columnDefinition)
          return '';

      return _.get(item, columnDefinition.Field) || '-';
  }

  public getDateValue(item: any, columnDefinition: IColumn) {
      if (!item)
          return '';

      if (!columnDefinition)
          return '';

      const fieldValue = _.get(item, columnDefinition.Field);
      const format = _.get(columnDefinition, 'DateOptions.Format') || 'DD.MM.YYYY HH:mm';

      return moment(fieldValue.value).format(format);
  }

  public onClick(button: ColumnAction, item: any) {
      const functionName = button.FunctionName;

      const callback = _.find(this.actionCallbacks, a => a.key === functionName);

      if (!callback)
          return;

      callback.callback(item);
  }

  public onItemSelect(item: any) {
      this.selected.emit(item);
  }

}
